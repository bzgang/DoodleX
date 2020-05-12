using DoodleX.UnintClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoodleX.DbContextHelper;
using DoodleX.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace DoodleX.Controllers
{
    public class UserManagerController : BaseMvcController
    {
        List<DX_User> user = null;
        int CountNum = 0;
        int pageSize = ConfigurationManager.AppSettings["pageSize"] == null ? 10 : Convert.ToInt32(ConfigurationManager.AppSettings["pageSize"]);
        int pageIndex = 1;
        int pageNum = 0;

        // GET: UserManager
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getList(string pageIndex, string pSize)
        {
            string currentUser = GetCurrentUser();

            this.pageIndex = Convert.ToInt32(pageIndex);
            if (pSize != "-1")
            {
                this.pageSize = Convert.ToInt32(pSize);
            }
            using (BizDbContext bizDb = new BizDbContext())
            {
                SqlParameter[] sqlp1 = new SqlParameter[4];
                string tablsSql = "(select * from DX_User) as t";  //如果是多表联合查询，把语句包裹起来，创建别名

                sqlp1[0] = new SqlParameter("@page_size", pageSize);
                sqlp1[1] = new SqlParameter("@page_index", pageIndex);
                sqlp1[2] = new SqlParameter("@table", tablsSql);
                sqlp1[3] = new SqlParameter("@ISCOUNT", 0);
                sqlp1[3].Direction = System.Data.ParameterDirection.Output;
                //执行存储过程，返回list结果
                user = bizDb.DX_User.SqlQuery("[Proc_TablePage] @page_size,@page_index,@table,@ISCOUNT out", sqlp1).ToList();
                //返回总数据条数
                CountNum = Convert.ToInt32(sqlp1[3].Value);//总条数
                                                           //计算总页数 
                if (CountNum <= pageSize && CountNum > 0)
                {
                    pageNum = 1;
                }
                else if (CountNum % pageSize > 0)
                {

                    pageNum = (CountNum / pageSize) + 1;
                }
                else if (CountNum % pageSize == 0)
                {
                    pageNum = CountNum / pageSize;
                }
            }
            var json = Json(new
            {
                data = user,
                pageNums = pageNum,
                CountNums = CountNum,
                pageSizes = pageSize
            }, JsonRequestBehavior.AllowGet);
            return json;
        }
    }
}