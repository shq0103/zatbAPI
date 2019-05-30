using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public RestfulArray<User> GetUserList(int page,int pageSize,string keyword)
        {
            string con = null;
            if (!string.IsNullOrEmpty(keyword))
            {
                con = string.Format("where username={0} or nickname={0}", keyword);
            }
            var list = new DaoBase<User, int>().GetListPaged(page, pageSize, con, null);
            return new RestfulArray<User>
            {
                data= new DaoBase<User, int>().GetListPaged(page, pageSize, con, null),
                total= new DaoBase<User, int>().RecordCount(con)
            };
        }

        /// <summary>
        /// 获取用户个人资料(admin获取任意id，user只能获取自己id随意填)
        /// </summary>
        /// <param name="id">用户id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public RestfulData<User> GetUser(int id)
        {
            var cUser = Helper.GetCurrentUser(HttpContext);
            var re = new RestfulData<User>();
            if (string.Equals(cUser.Role, "admin"))
            {
                re.data = new DaoBase<User, int>().Get(id);
            }
            else
            {
                re.data = new DaoBase<User, int>().Get(cUser.Id);
            }
            return re;
        }

 

        /// <summary>
        /// 更改用户信息
        /// </summary>
        /// <param name="user">用户</param>
        [HttpPut]
        public RestfulData PutUser([FromBody]User user)
        {
            new DaoBase<User, int>().Update(user);
            return new RestfulData
            {
                message="更新成功！"
            };
        }

        /// <summary>
        /// 删除某个用户
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            new DaoBase<User, int>().Delete(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
