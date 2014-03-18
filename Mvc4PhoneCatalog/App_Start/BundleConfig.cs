using System.Web;
using System.Web.Optimization;

namespace Mvc4PhoneCatalog
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.unobtrusive-ajax").Include(
                            "~/Scripts/jquery.unobtrusive-ajax.min.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                            "~/Scripts/jquery.validate.js",
                            "~/Scripts/jquery.validate.unobtrusive.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap-theme.min.css",
                        "~/Content/Site.css"));

            //bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
            //            "~/Content/bootstrap.min.css",
            //            "~/Content/bootstrap-responsive.min.css"));
        }
    }
}