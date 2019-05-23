using GenModel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.DbHelper.IRepository
{
    public class UserDao : DaoBase<User, Int32>
    {

        public Task<User> GetUser(string username,string password)
        {
            return GetAsync("select * from [user] where (username=@username or mail=@username) and password=@password", 
                new { username, password });
        }
    }
}
