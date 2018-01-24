namespace Notch.App_Bundles
{
    using System.Web.Optimization;

    public class ScriptBundles
    {
        public static void Register(BundleCollection bundles)
        {
            AppBundles(bundles);
            Tracks(bundles);
        }

        private static void AppBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
        }

        private static void Tracks(BundleCollection bundles)
        {
           
        }
    }
}