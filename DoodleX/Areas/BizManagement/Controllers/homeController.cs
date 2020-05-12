using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DoodleX.Areas.BizManagement.Controllers
{
    public class homeController : Controller
    {
        // GET: BizManagement/home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExportToExcel()
        {
            ViewBag.pageFlage = "导出";
            var sbHtml = new StringBuilder();
            sbHtml.Append("<table border='1' cellspacing='0' cellpadding='0'>");
            sbHtml.Append("<tr>");
            var lstTitle = new List<string> { "编号", "姓名", "年龄", "创建时间" };
            foreach (var item in lstTitle)
            {
                sbHtml.AppendFormat("<td style='font-size: 14px;text-align:center;background-color: #DCE0E2; font-weight:bold;' height='25'>{0}</td>", item);
            }
            sbHtml.Append("</tr>");
            for (int i = 0; i < 100; i++)
            {
                sbHtml.Append("<tr>");
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>屌丝{0}号</td>", i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", new Random().Next(20, 30) + i);
                sbHtml.AppendFormat("<td style='font-size: 12px;height:20px;'>{0}</td>", DateTime.Now);
                sbHtml.Append("</tr>");
            }
            sbHtml.Append("</table>");
            //第一种:使用FileContentResult
            byte[] fileContents = Encoding.UTF8.GetBytes(sbHtml.ToString());
            //return File(fileContents, "application/ms-excel", "测试下载fileContents.xls");

            //第二种:使用FileStreamResult
            var fileStream = new MemoryStream(fileContents);
            return File(fileStream, "application/ms-excel", "测试1fileStream.xls");

            //第三种:使用FilePathResult
            //服务器上首先必须要有这个Excel文件,然会通过Server.MapPath获取路径返回.
            //var fileName = Server.MapPath("~/Files/fileName.xls");
            //return File(fileName, "application/ms-excel", "fileName.xls");
        }


        public ActionResult ExportToExcel2()
        {
            HttpContext curContext = System.Web.HttpContext.Current;
            //设置编码及附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "";
            string fullName = HttpUtility.UrlEncode("FileName.xls", Encoding.UTF8);
            //curContext.Response.AppendHeader("Content-Disposition",
            //    "attachment;filename=" + HttpUtility.UrlEncode(fullName, Encoding.UTF8));  //attachment后面是分号

            //创建workbook
            IWorkbook workbook;
            string fileExt = Path.GetExtension(fullName).ToLower();
            if (fileExt == ".xlsx")
                workbook = new XSSFWorkbook();
            else if (fileExt == ".xls")
                workbook = new HSSFWorkbook();
            else
                workbook = null;

            ICell cell;
            ISheet sheet = workbook.CreateSheet("StressTest");
            int i = 0;
            int rowLimit = 100;
            DateTime originalTime = DateTime.Now;
            for (i = 0; i < rowLimit; i++)
            {
                cell = sheet.CreateRow(i).CreateCell(0);
                cell.SetCellValue("值" + i.ToString());
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                var buffer = ms.GetBuffer();
                ms.Close();
                return File(buffer, "application/ms-excel", "ABCtest.xlsx");
            }
        }


        public ActionResult exExcel()
        {
            HttpContext curContext = System.Web.HttpContext.Current;
            //设置编码及附件格式
            curContext.Response.ContentType = "application/vnd.ms-excel";
            curContext.Response.ContentEncoding = Encoding.UTF8;
            curContext.Response.Charset = "utf-8";
            string fullName = HttpUtility.UrlEncode("FileName.xls", Encoding.UTF8);

            //curContext.Response.AppendHeader("Content-Disposition",
            //    "attachment;filename=" + HttpUtility.UrlEncode(fullName, Encoding.UTF8));  //attachment后面是分号

            byte[] data = TableToExcel(fullName).GetBuffer();
            string fileExt = Path.GetExtension(fullName).ToLower();
            return File(data, "application/vnd.ms-excel", "测试Htest" + fileExt);
        }
        public MemoryStream TableToExcel(string file)
        {
            //创建workbook
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
                workbook = new XSSFWorkbook();
            else if (fileExt == ".xls")
                workbook = new HSSFWorkbook();
            else
                workbook = null;
            //创建sheet
            ISheet sheet = workbook.CreateSheet("SheetName1");//到处节点的名称

            //表头
            IRow headrow = sheet.CreateRow(0);
            for (int i = 0; i < 5; i++)
            {
                ICell headcell = headrow.CreateCell(i);
                headcell.SetCellValue("测试数据值表头" + i.ToString());

            }
            //表内数据
            for (int i = 0; i < 50; i++)
            {
                IRow row = sheet.CreateRow(i + 1);
                for (int j = 0; j < 5; j++)
                {
                    ICell cell = row.CreateCell(j);
                    cell.SetCellValue("内容信息：行" + (i + 1).ToString() + "列" + (j + 1).ToString());
                }
            }
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                var buffer = ms.GetBuffer();
                ms.Close();
                return ms;
            }
        }
    }
}