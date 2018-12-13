using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.SiteManage
{
    public class SiteManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "SiteManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "SiteManage_default",
                "SiteManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
