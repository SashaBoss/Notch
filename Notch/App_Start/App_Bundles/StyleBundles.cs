namespace Notch.App_Bundles
{
    using System.Web.Optimization;

    public class StyleBundles
    {
        public static void Register(BundleCollection bundles)
        {
            MainBundle(bundles);
            Bootstrap(bundles);
        }

        private static void Bootstrap(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                    "~/Content/bootstrap.css"));
        }

        private static void MainBundle(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/main").Include(
                    "~/Content/bundled.css"));
        }
    }
}