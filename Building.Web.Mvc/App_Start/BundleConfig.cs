using System.Web;
using System.Web.Optimization;
using Links;

namespace Building.Web.Mvc
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

            bundles.Add(new StyleBundle("~/admin/component/css").Include(

    ));


            bundles.Add(new StyleBundle("~/admin/css")
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
                "~" + Links.Content.AdminTheme.dist.css.ui_jqgrid_min_css,
                "~/fonts/font-awesome-4.6.3/css/font-awesome.min.css"
                ));

            bundles.Add(new ScriptBundle("~/admin/common/script").Include(
                 "~" + Content.AdminTheme.dist.js.jquery_min_js,
                 "~" + Content.AdminTheme.dist.js.bootstrap_min_js,
                 "~" + Content.AdminTheme.dist.js.ace_extra_min_js
                ));

            bundles.Add(new ScriptBundle("~/admin/component/js").Include(
                //X_EDITABLE
                "~" + Content.AdminTheme.dist.js.x_editable.bootstrap_editable_min_js,
                "~" + Content.AdminTheme.dist.js.x_editable.ace_editable_min_js,
                //DATA_TIME
                "~" + Content.AdminTheme.dist.js.date_time.moment_min_js,
                "~" + Content.AdminTheme.dist.js.date_time.bootstrap_datepicker_min_js,
                "~" + Content.AdminTheme.dist.js.date_time.bootstrap_datetimepicker_min_js,
                "~" + Content.AdminTheme.dist.js.date_time.bootstrap_timepicker_min_js,
                "~" + Content.AdminTheme.dist.js.date_time.daterangepicker_min_js,
                //FLOAT
                "~" + Content.AdminTheme.dist.js.flot.jquery_flot_min_js,
                "~" + Content.AdminTheme.dist.js.flot.jquery_flot_pie_min_js,
                "~" + Content.AdminTheme.dist.js.flot.jquery_flot_resize_min_js,
                //FUELUX
                "~" + Content.AdminTheme.dist.js.fuelux.fuelux_spinner_min_js,
                "~" + Content.AdminTheme.dist.js.fuelux.fuelux_tree_min_js,
                "~" + Content.AdminTheme.dist.js.fuelux.fuelux_wizard_min_js,
                //JQGRIDE
                "~" + Content.AdminTheme.dist.js.jqGrid.jquery_jqGrid_min_js,
                //MARK_DOWN
                "~" + Content.AdminTheme.dist.js.markdown.markdown_min_js,
                "~" + Content.AdminTheme.dist.js.markdown.bootstrap_markdown_min_js
                ));

            bundles.Add(new ScriptBundle("~/admin/component/dataTable/js").Include(
                //DATA_TABLE
                "~" + Content.AdminTheme.dist.js.dataTables.jquery_dataTables_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.jquery_dataTables_bootstrap_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.buttons.dataTables_buttons_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.buttons.buttons_colVis_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.buttons.buttons_flash_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.buttons.buttons_html5_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.buttons.buttons_print_min_js,
                "~" + Content.AdminTheme.dist.js.dataTables.extensions.@select.dataTables_select_min_js
                ));

            //<<--VALIDETTA_COMPONENT
            bundles.Add(new ScriptBundle("~/admin/component/validetta/js").Include(
                "~"+Content.Plugins.jquery_validetta.validetta_min_js,
                "~"+Content.Plugins.jquery_validetta.validettaLang_fa_IR_js
                ));

            bundles.Add(new StyleBundle("~/admin/component/validetta/css").Include(
                      "~"+Content.Plugins.jquery_validetta.validetta_min_css
                     ));
            //END-->>

            bundles.Add(new ScriptBundle("~/admin/script").Include(
                "~" + Content.AdminTheme.dist.js.jquery_ui_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_ui_custom_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_ui_touch_punch_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_bootstrap_duallistbox_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_colorbox_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_easypiechart_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_gritter_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_hotkeys_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_inputlimiter_1_3_1_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_knob_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_maskedinput_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_mobile_custom_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_nestable_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_validate_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_raty_min_js,
                "~" + Content.AdminTheme.dist.js.jquery_sparkline_min_js,
                "~" + Content.AdminTheme.dist.js.fullcalendar_min_js,
                "~" + Content.AdminTheme.dist.js.bootstrap_colorpicker_min_js,
                "~" + Content.AdminTheme.dist.js.bootstrap_multiselect_min_js,
                "~" + Content.AdminTheme.dist.js.bootstrap_tag_min_js,
                "~" + Content.AdminTheme.dist.js.bootstrap_wysiwyg_min_js,
                "~" + Content.AdminTheme.dist.js.bootbox_min_js,
                "~" + Content.AdminTheme.dist.js.additional_methods_min_js,
                "~" + Content.AdminTheme.dist.js.autosize_min_js,
                "~" + Content.AdminTheme.dist.js.chosen_jquery_min_js,
                "~" + Content.AdminTheme.dist.js.dropzone_min_js,
                "~" + Content.AdminTheme.dist.js.prettify_min_js,
                "~" + Content.AdminTheme.dist.js.select2_min_js,
                "~" + Content.AdminTheme.dist.js.spin_min_js,
                "~" + Content.AdminTheme.dist.js.typeahead_jquery_min_js,
                "~" + Content.AdminTheme.dist.js.ace_elements_min_js,
                "~" + Content.AdminTheme.dist.js.ace_extra_min_js,
                "~" + Content.AdminTheme.dist.js.ace_min_js

                ));

            //BundleTable.EnableOptimizations = true;
        }
    }
}
