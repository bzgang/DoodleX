using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoodleX.DbContextHelper;
using DoodleX.Models;
using DoodleX.UnintClass;

namespace DoodleX.Controllers
{
    public class MenuController : BaseMvcController
    {

        // GET: Menu
        public ActionResult Index()
        {
            using (BizDbContext bizDb = new BizDbContext())
            {
                List<DX_Menus> parentMenus = bizDb.DX_Menus.ToList();
            }
            return View();
        }

        public ActionResult getTreeView()
        {
            List<DX_MenusEx> menusExList = new List<DX_MenusEx>();

            string currentUser = GetCurrentUser();
            using (BizDbContext bizDb = new BizDbContext())
            {
                List<DX_Menus> parentMenus = bizDb.DX_Menus.Where(me => me.ParentId <= 0 && me.IsDeleted == false && me.IsEnable == true).ToList();

                foreach (DX_Menus pmenus in parentMenus)
                {
                    DX_MenusEx menusEx = new DX_MenusEx();
                    menusEx.Id = pmenus.Id;
                    menusEx.MenuChName = pmenus.MenuChName;
                    menusEx.MenuEnName = pmenus.MenuEnName;
                    menusEx.MenuIcon = pmenus.MenuIcon;
                    menusEx.MenuLevel = pmenus.MenuLevel;

                    menusEx.ParentId = pmenus.ParentId;
                    menusEx.CreatedOn = pmenus.CreatedOn;
                    menusEx.CreatedBy = pmenus.CreatedBy;
                    menusEx.UpdatedOn = pmenus.UpdatedOn;
                    menusEx.UpdatedBy = pmenus.UpdatedBy;
                    menusEx.IsDeleted = pmenus.IsDeleted;
                    menusEx.IsEnable = pmenus.IsEnable;
                    menusEx.SortBy = pmenus.SortBy;
                    List<DX_Menus> childMenus = bizDb.DX_Menus.Where(me => me.ParentId == pmenus.Id && me.IsDeleted == false && me.IsEnable == true).ToList();
                    menusEx.DXMenus = childMenus;
                    //如果包含子菜单项，则修改父项的显示方式和地址：地址为空，点击时，不进行页面切换
                    menusEx.LinkAddress = childMenus.Count > 0 ? "" : pmenus.LinkAddress;
                    menusEx.MenuTarget = childMenus.Count > 0 ? "_blank" : pmenus.MenuTarget;
                    menusExList.Add(menusEx);
                }
            }
            var json = Json(new
            {
                data = menusExList
            }, JsonRequestBehavior.AllowGet);
            return json;
            //  return Json("11");
        }
    }
}