using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.NewsManage
{
    public class NewsManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "NewsManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "NewsManage_default",
                "NewsManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
