using System.Web;
using System.Web.Optimization;

namespace MVCWebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Stylesheets welke nodig zijn

            bundles.Add(new StyleBundle("~/Content/normalize").Include(
             "~/Content/normalize.css"));

            bundles.Add(new StyleBundle("~/Content/foundation").Include(
                "~/Content/foundation.css"));

            bundles.Add(new StyleBundle("~/Content/fonts").Include(
               "~/Content/fonts.css"));

            bundles.Add(new StyleBundle("~/Content/aux_style").Include(
              "~/Content/aux_style.css"));

            // Main framework Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-min").Include(
                        "~/Scripts/vendor/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/foundation").Include(
                      "~/Scripts/foundation.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app.js"));

            // Scripts welke nodig zijn voor de werking van alles
            bundles.Add(new ScriptBundle("~/bundles/what-input").Include(
                       "~/Scripts/vendor/what-input.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/textarea-grow").Include(
                      "~/Scripts/vendor/textarea-autogrow/textareaAutoGrow.js"));

            bundles.Add(new ScriptBundle("~/bundles/waypoints").Include(
                     "~/Scripts/vendor/waypoints/waypoints.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/counterup").Include(
                    "~/Scripts/vendor/counter-up/jquery.counterup.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/clipboard").Include(
                    "~/Scripts/vendor/clipboard/clipboard.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/prism").Include(
                    "~/Scripts/vendor/prism/prism.js"));

            bundles.Add(new ScriptBundle("~/bundles/demo").Include(
                    "~/Scripts/demo.js"));
        }
    }
}
