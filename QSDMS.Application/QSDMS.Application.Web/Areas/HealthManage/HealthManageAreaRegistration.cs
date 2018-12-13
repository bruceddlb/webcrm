using System.Web.Mvc;

namespace QSDMS.Application.Web.Areas.HealthManage
{
    public class HealthManageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HealthManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HealthManage_default",
                "HealthManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
