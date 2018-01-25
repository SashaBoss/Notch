namespace Notch
{
    using System.Web.Optimization;

    using Notch.App_Bundles;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            ScriptBundles.Register(bundles);
            StyleBundles.Register(bundles);
            BundleTable.EnableOptimizations = false;
        }
                .Include("~/Scripts/bootstrap.js"));
        }
    }
}