using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public long? Birthday { get; set; }
        public int? Gender { get; set; }
        public string TrueName { get; set; }
        public string IdCard { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Intro { get; set; }
        public string Place { get; set; }
    }
}
