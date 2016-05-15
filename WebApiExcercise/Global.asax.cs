using System.Web.Http;

namespace WebApiExcercise
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
             
            
        }

    }
}
