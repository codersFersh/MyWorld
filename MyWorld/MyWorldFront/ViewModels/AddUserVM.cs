using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWorldFront.ViewModels
{
    public class AddUserVM
    {
        //required 属性是一个布尔属性。
        //required 属性规定必需在提交表单之前填写输入字段。
        //RegularExpression:正则表达式(以下简称 Regexp)是一种字串表达的方式. 可用以指定具有某特征的所有字串.


             public int Id { get; set; } //用户ID


            [Required (ErrorMessage ="用户名不能为空值")]
            [Display(Name ="用户名")]
            public string Name { get; set; } //用户名


            [Required (ErrorMessage ="手机不能为空")]
            [Display(Name ="手机号")]
            [RegularExpression(@"^1[3458][0-9]{9}$", ErrorMessage = "请输入正确的手机号码")]
            public string PhoneNum { get; set; } //用户手机号


            [Required(ErrorMessage = "密码不能为空！")]
            [StringLength(100, ErrorMessage = "{0} 必须至少包含{2}个字符！", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "密码")]
            public string Password { get; set; }  //用户密码


            [Required(ErrorMessage = "确认密码不能为空！")]
            [DataType(DataType.Password)]
            [Display(Name = "确认密码")]
            [Compare(nameof(Password), ErrorMessage = "密码和确认密码不匹配")]
            public string ConfirmPassword { get; set; }  //确认密码


            [Display(Name = "电子邮箱")]
            [DataType(DataType.EmailAddress)]
            [EmailAddress]
            public string Email { get; set; }  // 用户邮箱

        }
    }