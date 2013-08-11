using System.Globalization;
using System.Web;
using System.Web.Optimization;

namespace DeveloperMediaDemo.AppStart
{
    public static class BundleConfig
    {
        public const string StylesLess    = "~/bundles/styles/less";
        public const string ScriptsGlobal = "~/bundles/scripts/global";

        public static void RegisterLessBundles(BundleCollection bundles)
        {
            Bundle bundle = new Bundle(StylesLess)
                .Include("~/Content/Site.less");

            bundles.Add(bundle);
        }

        public static IHtmlString RenderLess(string bundleName)
        {
            if (BundleTable.EnableOptimizations)
            {
                string url = BundleTable.Bundles.ResolveBundleUrl(bundleName);
                string result = string.Format(CultureInfo.InvariantCulture, @"<link rel=""stylesheet"" href=""{0}"" type=""text/css"" />", url);
                return new HtmlString(result);
            }

            return Styles.Render(bundleName);
        }

        public static void RegisterScriptBundles(BundleCollection bundles)
        {
            Bundle bundle = new ScriptBundle(ScriptsGlobal);
            bundle.Orderer = new AsIsBundleOrderer();
            bundle.Include(
                "~/Scripts/require.js",
                "~/Scripts/require.config.js");

            bundles.Add(bundle);
        }
    }

}