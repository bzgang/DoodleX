using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DoodleX.App_Start
{
    public class BundleConfig
    {        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //          "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            //// 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            //合并加载js文件,页面中只需要引用虚拟目录，就能加载虚拟目录中的所有js
            var bundleJS = new ScriptBundle("~/bundles/Mytestjs");
            bundleJS.Include("~/assets/js/language/zh_CN.js", "~/assets/js/date-time/bootstrap-datetimepicker.zh-CN.js", "~/assets/js/date-time/daterangepicker.min.js");
            bundles.Add(bundleJS);
            //指定压缩--多个js压缩成一个脚本
            BundleTable.EnableOptimizations = true;

            //页面中使用方式：
           //1、 @Scripts.Render("~/bundles/Mytestjs")   //有唯一标识码的
          //2、< script src = "~/bundles/Mytestjs" ></ script > //可自己手动添加
        }
    }
}