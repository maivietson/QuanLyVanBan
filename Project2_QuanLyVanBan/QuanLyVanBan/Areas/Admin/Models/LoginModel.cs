using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyVanBan.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Nhap ten dang nhap")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Nhap mat khau")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}