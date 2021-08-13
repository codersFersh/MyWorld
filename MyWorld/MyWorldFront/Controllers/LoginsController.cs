using MyWorldEntity;
using MyWorldFront.ViewModels.MyWorldFront.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyWorldFront.Controllers
{
    public class LoginsController : Controller
    {
        // GET: Login

        private MyWorldDbContent db = new MyWorldDbContent();

        public ActionResult Login(string returnUrl = null)  //返回路径
        {
            //ViewBag是一个动态类型变量(dynamic)
            //ViewBag 从 Controller 向 View 传递数据

            if (string.IsNullOrEmpty(returnUrl))  //判断返回路径是否为空
                ViewBag.ReturnUrl = Url.Action("Index", "");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]

        public ActionResult Login(AdminLoginVM model, string returnUrl)
        {
            //判断实体是否通过效验

            //model的属性如果不加验证相关的特性，ModelState.IsValid会永远为true；
            //如果加了验证相关的特性，不满足验证规则时，ModelState.IsValid为false.
            if (ModelState.IsValid)
            {
                if (ValidataUser(model))
                {

                    //FormsAuthentication为Web应用程序管理Forms身份验证服务，此类不能被继承。

                    FormsAuthentication.SetAuthCookie(model.PhoneNum, false); //为提供的用户名创建一个身份验证票证，并将其添加到响应的 Cookie 集合或 URL。
                    var loginUser = db.Users.Where(p => p.PhoneNum == model.PhoneNum).FirstOrDefault();
                    var loginUserName = loginUser.Name;

                    //登录成功后把登录用户的名字和角色信息保存到会话（Session)
                    Session["loginUserName"] = loginUserName;
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "您的用账号或者密码有误，请填写正确的账号密码");

                }
            }
            if (string.IsNullOrEmpty(returnUrl))
                ViewBag.ReturnUrl = Url.Action("Index", "AdminAccount");
            else
                ViewBag.ReturnUrl = returnUrl;
            return View();
        }














        [NonAction]
        private bool ValidataUser(AdminLoginVM model)
        {
            ////为了简化操作，省略哈希运算
            // var member = (form p in db.AdminUsers
            //                where p.Name == model.Name && p.Password == model.Password
            //                select p).FirstOrDefault();

            var member = db.Users.Where(p => p.PhoneNum == model.PhoneNum && p.Password == model.Password).FirstOrDefault();

            if (member != null)
            {
                return true;  // 不采用Email验证则直接返回true就OK了
            }
            else
            {
                //ModelState.AddModelError("","您输入的账号或者密码错误！")
                return false;
            }
        }
    }
}