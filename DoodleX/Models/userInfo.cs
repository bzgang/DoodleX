using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DoodleX.Models
{
    [Table("userInfo")]
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public string Pwd { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

    }
}