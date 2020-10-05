using System;
using System.Collections.Generic;

namespace MyfirstCoreApi.Models
{
    public class UserModel
    {
        public UserModel()
        {
        }

        public int totalpage { get; set; }

        public int pagenum { get; set; }

        public IEnumerable<User> users { get; set; }

        public Meta meta { get; set; }

    }

    public class User: UserBase
    {
      
        public int type { get; set; } 

        public string create_time { get; set; }

        public bool mg_state { get; set; }

        public string role_name { get; set; }

        public int id { get; set; }

        public int rid { get; set; }

    }

    public class UserBase
    {
      
        public string username { get; set; }

        public string mobile { get; set; }

        public string email { get; set; }

        public string password { get; set; }


    }

    public class UserInfo
    {
        public User data { get; set; } = new User();

        public Meta meta { get; set; } = new Meta();
    }
}
