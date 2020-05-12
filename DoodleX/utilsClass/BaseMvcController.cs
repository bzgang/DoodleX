using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoodleX.UnintClass
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseMvcController : Controller
    {
        /// <summary>
        ///获取当前登陆用户
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUser()
        {
            if (Session["currentUser"] == null)
            {
                Session.Add("currentUser", "当前登陆人");
            }
            //string a = User.Identity.Name.ToString();
            return Session["currentUser"].ToString();
        }

    }
}