using System.Globalization;
using System.Web;
using System.Web.Optimization;

namespace DeveloperMediaDemo.AppStart
{
    public static class BundleConfig
    {
        public const string Styles    = "~/bundles/styles/less";
        public const string Scripts = "~/bundles/scripts/global";

        public static void RegisterLessBundles(BundleCollection bundles)
        {
            Bundle bundle = new Bundle(Styles)
                .Include("~/Content/Site.css",
                        "~/Content/jquery.datatables/css/demo_page.css",
                        "~/Content/jquery.datatables/css/demo_table.css");

            bundles.Add(bundle);
        }

        public static IHtmlString RenderLess(string bundleName)
        {
            return System.Web.Optimization.Styles.Render(bundleName);
        }

        public static void RegisterScriptBundles(BundleCollection bundles)
        {
            Bundle bundle = new ScriptBundle(Scripts);
            bundle.Orderer = new AsIsBundleOrderer();
            bundle.Include(
                "~/Scripts/require.js",
                "~/Scripts/require.config.js");

            bundles.Add(bundle);
        }
    }

}