using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using zatbAPI.Utils;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    /// <summary>
    /// 文件管理
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }



        /// <summary>
        /// 上传图片
        /// </summary>
        [HttpPost("UploadImg")]
        [SwaggerResponse(200, "上传成功(data为文件id)", typeof(RestfulData))]
        public async Task<RestfulData<int>> UploadFile(IFormFile file)
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            string uploadPath = webRootPath + "/upload/";
            //如果上传路径不存在，创建路径
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            string fileExt = Path.GetExtension(file.FileName); //文件扩展名，含“.”
            string newFileName = Guid.NewGuid().ToString(); //随机生成新的文件名
            var filePath = uploadPath + newFileName + fileExt;

            // 将文件相关信息存入数据库
            int fileKey = new DaoBase<Image, int>().Insert(
                new Image
                {
                    Name = file.FileName,
                    Url = filePath
                })??0;

            // 保存文件至本地
            using (var stream = new FileStream(filePath, FileMode.Create))
            {

                await file.CopyToAsync(stream);
            }
            return new RestfulData<int>
            {
                code =  0,
                data = fileKey,
                message = "上传成功"
            };
        }

    }
}
