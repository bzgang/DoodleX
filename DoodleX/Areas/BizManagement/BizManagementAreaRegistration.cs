using System.Web.Mvc;
namespace DoodleX.Areas.BizManagement
{
    public class BizManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BizManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "BizManagement",
                "BizManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}