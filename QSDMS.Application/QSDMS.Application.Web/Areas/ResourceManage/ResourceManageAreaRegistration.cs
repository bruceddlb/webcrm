using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.ResourceManage
{
    public class ResourceManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ResourceManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ResourceManage_default",
                "ResourceManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
