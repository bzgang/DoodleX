using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DoodleX.Models;

namespace DoodleX.DbContextHelper
{
    public class BizDbContext : DbContext
    {
        public BizDbContext() : base(GetConnectionString())
        //   public EFDbContext() :base("sqlConn") //获取名称 需要配置在config中的  <connectionStrings>节点
        {

        }
        public static string GetConnectionString()
        {
            //return ConfigurationManager.AppSettings["sqlConn"].ToString();
            return ConfigurationManager.ConnectionStrings["sqlConn"].ToString();
        }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<DX_Menus> DX_Menus { get; set; }
        public DbSet<DX_Role> DX_Role { get; set; }
        public DbSet<DX_Role_Menus> DX_Role_Menus { get; set; }
        public DbSet<DX_User> DX_User { get; set; }
        public DbSet<DX_User_Menus> DX_User_Menus { get; set; }
        public DbSet<DX_User_Role> DX_User_Role { get; set; }
        //public DbSet<DX_MenusEx> DX_MenusEx { get; set; }
    }

}