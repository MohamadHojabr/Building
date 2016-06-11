using System.Web;
using System.Web.Optimization;

namespace Building
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/admin/css")
    .Include(
                "~" + Links.Content.AdminTheme.dist.css.ace_min_css,
                "~" + Links.Content.AdminTheme.dist.css.ace_rtl_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_datetimepicker_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_duallistbox_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_editable_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_multiselect_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_timepicker_min_css,
                "~" + Links.Content.AdminTheme.dist.css.bootstrap_datepicker3_min_css,
                "~" + Links.Content.AdminTheme.dist.css.jquery_ui_min_css,
                "~" + Links.Content.AdminTheme.dist.css.jquery_gritter_min_css,
                "~" + Links.Content.AdminTheme.dist.css.jquery_ui_custom_min_css,
                "~" + Links.Content.AdminTheme.dist.css.chosen_min_css,
                "~" + Links.Content.AdminTheme.dist.css.colorbox_min_css,
                "~" + Links.Content.AdminTheme.dist.css.colorpicker_min_css,
                "~" + Links.Content.AdminTheme.dist.css.daterangepicker_min_css,
                "~" + Links.Content.AdminTheme.dist.css.fullcalendar_min_css,
                "~" + Links.Content.AdminTheme.dist.css.dropzone_min_css,
                "~" + Links.Content.AdminTheme.dist.css.prettify_min_css,
                "~" + Links.Content.AdminTheme.dist.css.select2_min_css,
                "~" + Links.Content.AdminTheme.dist.css.ui_jqgrid_min_css
                ));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
