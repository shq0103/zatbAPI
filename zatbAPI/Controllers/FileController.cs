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
using zatbAPI.DbHelper.IRepository;

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
        /// <param name="file">图片</param>
        /// <param name="type">类型（1.新闻,2.活动，3.闲趣，4.打卡点，5.头像）</param>
        /// <returns></returns>
        [HttpPost("UploadImg")]
        [SwaggerResponse(200, "上传成功(data为文件id)", typeof(RestfulData))]
        public async Task<RestfulData<string>> UploadFile(IFormFile file,int type)
        {

            string webRootPath = _hostingEnvironment.WebRootPath;
            string uploadPath = webRootPath + "/upload/";
            //如果上传路径不存在，创建路径
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            string fileExt = Path.GetExtension(file.FileName); //文件扩展名，含“.”
            string newFileName = Guid.NewGuid().ToString(); //随机生成新的文件名
            var filePath = uploadPath + newFileName + fileExt;

            if (type == 5)
            {
                var cUser = Helper.GetCurrentUser(HttpContext);
                var user = new UserDao().Get(cUser.Id);
                user.Avatar = "/upload/" + newFileName + fileExt;
                new UserDao().Update(user);
            }

            // 保存文件至本地
            using (var stream = new FileStream(filePath, FileMode.Create))
            {

                await file.CopyToAsync(stream);
            }
            return new RestfulData<string>
            {
                code =  0,
                data = "/upload/"+ newFileName + fileExt,
                message = "上传成功"
            };
        }

    }
}
