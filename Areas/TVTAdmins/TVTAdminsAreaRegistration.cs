using System.Web.Mvc;

namespace k22cnt3_tavanthang_project2.Areas.TVTAdmins
{
    public class TVTAdminsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TVTAdmins";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TVTAdmins_default",
                "TVTAdmins/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}