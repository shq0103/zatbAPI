using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    }
}
