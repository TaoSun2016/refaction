using refactor_me.Models;
using System.Data.Entity;
using System.Web.Http;

namespace refactor_me
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new ProductDBInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
