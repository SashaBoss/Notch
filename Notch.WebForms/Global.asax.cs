namespace Notch.WebForms
{
    using System;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Notch.Bootstrap;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ApplicationMapper.Init();
        }
    }
}