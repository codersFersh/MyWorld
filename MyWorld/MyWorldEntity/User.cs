using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorldEntity
{
    public class User //用户类
    {
        public int Id { get; set; } //用户ID

        public string Name { get; set; } //用户名

        public string PhoneNum { get; set; } //用户手机号

        public string Password { get; set; }  //用户密码

        public string ConfirmPassword { get; set; }  //确认密码

        public string Email { get; set; }  // 用户邮箱
    }
}
