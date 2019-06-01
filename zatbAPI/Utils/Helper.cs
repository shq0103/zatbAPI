using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using zatbAPI.Models;

namespace zatbAPI.Utils
{
    public class Helper
    {
        public static User GetCurrentUser(HttpContext HttpContext)
        {
            User currentUser = new User();
            var httpCurrentUser = HttpContext.User;
            currentUser.Id = int.Parse(httpCurrentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid).Value);
            currentUser.Role = httpCurrentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            currentUser.Username = httpCurrentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (!string.IsNullOrEmpty(httpCurrentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value))
            {
                currentUser.Nickname = httpCurrentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

            }
            return currentUser;
        }
        /// <summary>
        /// 获取string的md5
        /// </summary>
        /// <param name="str">str</param>
        /// <returns></returns>
        public static string GetMd5(string str)
        {
            //创建MD5哈稀算法的默认实现的实例
            MD5 md5 = MD5.Create();
            //将指定字符串的所有字符编码为一个字节序列
            byte[] buffer = Encoding.Default.GetBytes(str);
            //计算指定字节数组的哈稀值
            byte[] bufferMd5 = md5.ComputeHash(buffer);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bufferMd5.Length; i++)
            {
                //x:表示将十进制转换成十六进制
                sb.Append(bufferMd5[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
