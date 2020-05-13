using DoodleX.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoodleX.utilsClass;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace DoodleX.Controllers
{
    public class homeController : Controller
    {
        // [DoodlAuthAttrbute]
        // GET: home 
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.loginFlage = "false";
            return View();
        }
        [AllowAnonymous]
        public ActionResult NoLogin()
        {
            return Redirect("/home/Login");
        }

        public ActionResult SetToken()
        {
            var payload = new Dictionary<string, object>
            {
                { "username","admin" },
                { "IP", "127.0.0.1" },
                { "Browser","IE "}
            };
            Session["token"] = JwtIdentity.SetJwtEncode(payload);
            ViewBag.token = Session["token"];
            return View("Login");
        }

        public ActionResult GetToken()
        {
            string token = "";
            if (Session["token"] != null)
                token = Session["token"].ToString();
            var status = JwtIdentity.GetJwtDecode(token);
            ViewBag.status = status;
            return View("Login");
        }
        string password = "1234QWEASDzxc..";
        string salt = "0plkjnmbhgvcf";
        public ActionResult SetEncod()
        {
            string newPwd = EncryptionTools.MD5Encoding(password);
            string newPwd_salt = EncryptionTools.MD5Encoding(password, salt);
            ViewBag.password = newPwd + "【----】" + newPwd_salt;
            Session["newPwd"] = newPwd;
            Session["newPwd_salt"] = newPwd_salt;
            return View("Login");
        }
        public ActionResult CheckLogin()
        {
            #region 加密-解密
            string aaa = EncryptionTools.Md5Encrypt(password);
            EncryptionTools.Md5Decrypt(aaa);
            #endregion


            bool isFalse = false;
            bool isFalse_salf = false;
            if (Session["newPwd"] != null)
            {

                isFalse = (Session["newPwd"].ToString() == EncryptionTools.MD5Encoding(password));
            }
            if (Session["newPwd_salt"] != null)
            {
                isFalse_salf = (Session["newPwd_salt"].ToString() == EncryptionTools.MD5Encoding(password, salt));
            }
            ViewBag.flage = isFalse + "【---】" + isFalse_salf;
            return View("Login");
        }


    }
}