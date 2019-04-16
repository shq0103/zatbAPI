using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using zatbAPI.Models.Users;

namespace zatbAPI.DbHelper.IRepository
{
    public class AdminDao : DaoBase<Admin, Int32>
    {

        public Task<Admin> GetAdmin(string username,string password)
        {
            return GetAsync("select * from admin where username=@username and password=@password", 
                new { username, password });
        }
    }
}
