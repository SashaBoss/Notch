namespace Notch
{
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterBootstrap(bundles);
            RegisterAppStyles(bundles);
        }

        private static void RegisterAppStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/app")
                .Include("~/Content/app.css"));
        }

        private static void RegisterBootstrap(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/bootstrap")
                .Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootsrap.css"));
        }
    }
}