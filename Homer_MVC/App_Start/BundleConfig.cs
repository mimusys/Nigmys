﻿using System.Web;
using System.Web.Optimization;

namespace Nigmys
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Homer style
            bundles.Add(new StyleBundle("~/bundles/homer/css").Include(
                      "~/Content/style.css", new CssRewriteUrlTransform()));

            // Homer script
            bundles.Add(new ScriptBundle("~/bundles/homer/js").Include(
                      "~/Vendor/metisMenu/dist/metisMenu.min.js",
                      "~/Vendor/iCheck/icheck.min.js",
                      "~/Vendor/peity/jquery.peity.min.js",
                      "~/Vendor/sparkline/index.js",
                      "~/Scripts/homer.js",
                      "~/Scripts/charts.js"));

            // Animate.css
            bundles.Add(new StyleBundle("~/bundles/animate/css").Include(
                      "~/Vendor/animate.css/animate.min.css"));

            // Pe-icon-7-stroke
            bundles.Add(new StyleBundle("~/bundles/peicon7stroke/css").Include(
                      "~/Icons/pe-icon-7-stroke/css/pe-icon-7-stroke.css", new CssRewriteUrlTransform()));

            // Font Awesome icons style
            bundles.Add(new StyleBundle("~/bundles/font-awesome/css").Include(
                      "~/Vendor/fontawesome/css/font-awesome.min.css", new CssRewriteUrlTransform()));

            // Bootstrap style
            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Vendor/bootstrap/dist/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            // Bootstrap
            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Vendor/bootstrap/dist/js/bootstrap.min.js"));

            // jQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Vendor/jquery/dist/jquery.min.js"));

            // jQuery UI
            bundles.Add(new ScriptBundle("~/bundles/jqueryui/js").Include(
                      "~/Vendor/jquery-ui/jquery-ui.min.js"));

            // Flot chart
            bundles.Add(new ScriptBundle("~/bundles/flot/js").Include(
                      "~/Vendor/flot/jquery.flot.js",
                      "~/Vendor/flot/jquery.flot.tooltip.min.js",
                      "~/Vendor/flot/jquery.flot.resize.js",
                      "~/Vendor/flot/jquery.flot.pie.js",
                      "~/Vendor/flot.curvedlines/curvedLines.js",
                      "~/Vendor/jquery.flot.spline/index.js"));

            // Star rating
            bundles.Add(new ScriptBundle("~/bundles/starRating/js").Include(
                      "~/Vendor/bootstrap-star-rating/js/star-rating.min.js"));

            // Star rating style
            bundles.Add(new StyleBundle("~/bundles/starRating/css").Include(
                      "~/Vendor/bootstrap-star-rating/css/star-rating.min.css", new CssRewriteUrlTransform()));

            // Sweetalert
            bundles.Add(new ScriptBundle("~/bundles/sweetAlert/js").Include(
                      "~/Vendor/sweetalert/dist/sweetalert.min.js"));

            // Sweetalert style
            bundles.Add(new StyleBundle("~/bundles/sweetAlert/css").Include(
                      "~/Vendor/sweetalert/dist/sweetalert.css",
                      "~/Content/alertForm.css"));

            // Toastr
            bundles.Add(new ScriptBundle("~/bundles/toastr/js").Include(
                      "~/Vendor/toastr/build/toastr.min.js"));

            // Toastr style
            bundles.Add(new StyleBundle("~/bundles/toastr/css").Include(
                      "~/Vendor/toastr/build/toastr.min.css"));

            // Nestable
            bundles.Add(new ScriptBundle("~/bundles/nestable/js").Include(
                      "~/Vendor/nestable/jquery.nestable.js"));

            // Toastr
            bundles.Add(new ScriptBundle("~/bundles/bootstrapTour/js").Include(
                      "~/Vendor/bootstrap-tour/build/js/bootstrap-tour.min.js"));

            // Toastr style
            bundles.Add(new StyleBundle("~/bundles/bootstrapTour/css").Include(
                      "~/Vendor/bootstrap-tour/build/css/bootstrap-tour.min.css"));

            // Moment
            bundles.Add(new ScriptBundle("~/bundles/moment/js").Include(
                      "~/Vendor/moment/moment.js"));

            // Full Calendar
            bundles.Add(new ScriptBundle("~/bundles/fullCalendar/js").Include(
                      "~/Vendor/fullcalendar/dist/fullcalendar.min.js"));

            // Full Calendar style
            bundles.Add(new StyleBundle("~/bundles/fullCalendar/css").Include(
                      "~/Vendor/fullcalendar/dist/fullcalendar.min.css"));

            // Chart JS
            bundles.Add(new ScriptBundle("~/bundles/chartjs/js").Include(
                      "~/Vendor/chartjs/Chart.min.js"));

            // Datatables
            bundles.Add(new ScriptBundle("~/bundles/datatables/js").Include(
                      "~/Vendor/datatables/media/js/jquery.dataTables.min.js"));

            // Datatables bootstrap
            bundles.Add(new ScriptBundle("~/bundles/datatablesBootstrap/js").Include(
                      "~/Vendor/datatables_plugins/integration/bootstrap/3/dataTables.bootstrap.min.js"));

            // Datatables style
            bundles.Add(new StyleBundle("~/bundles/datatables/css").Include(
                      "~/Vendor/datatables_plugins/integration/bootstrap/3/dataTables.bootstrap.css"));

            // Xeditable
            bundles.Add(new ScriptBundle("~/bundles/xeditable/js").Include(
                      "~/Vendor/xeditable/bootstrap3-editable/js/bootstrap-editable.min.js"));

            // Xeditable style
            bundles.Add(new StyleBundle("~/bundles/xeditable/css").Include(
                      "~/Vendor/xeditable/bootstrap3-editable/css/bootstrap-editable.css", new CssRewriteUrlTransform()));

            // Select 2
            bundles.Add(new ScriptBundle("~/bundles/select2/js").Include(
                      "~/Vendor/select2-3.5.2/select2.min.js"));

            // Select 2 style
            bundles.Add(new StyleBundle("~/bundles/select2/css").Include(
                      "~/Vendor/select2-3.5.2/select2.css",
                      "~/Vendor/select2-bootstrap/select2-bootstrap.css"));

            // Touchspin
            bundles.Add(new ScriptBundle("~/bundles/touchspin/js").Include(
                      "~/Vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.js"));

            // Touchspin style
            bundles.Add(new StyleBundle("~/bundles/touchspin/css").Include(
                      "~/Vendor/bootstrap-touchspin/dist/jquery.bootstrap-touchspin.min.css"));

            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/datepicker/js").Include(
                      "~/Vendor/bootstrap-datepicker-master/dist/js/bootstrap-datepicker.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/datepicker/css").Include(
                      "~/Vendor/bootstrap-datepicker-master/dist/css/bootstrap-datepicker3.min.css"));

            // Datepicker
            bundles.Add(new ScriptBundle("~/bundles/summernote/js").Include(
                      "~/Vendor/summernote/dist/summernote.min.js"));

            // Datepicker style
            bundles.Add(new StyleBundle("~/bundles/summernote/css").Include(
                      "~/Vendor/summernote/dist/summernote.css",
                      "~/Vendor/summernote/dist/summernote-bs3.css"));

            // Bootstrap checkbox style
            bundles.Add(new StyleBundle("~/bundles/bootstrapCheckbox/css").Include(
                      "~/Vendor/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css"));

            // Blueimp gallery
            bundles.Add(new ScriptBundle("~/bundles/blueimp/js").Include(
                      "~/Vendor/blueimp-gallery/js/jquery.blueimp-gallery.min.js"));

            // Blueimp gallery style
            bundles.Add(new StyleBundle("~/bundles/blueimp/css").Include(
                      "~/Vendor/blueimp-gallery/css/blueimp-gallery.min.css", new CssRewriteUrlTransform()));

            // Foo Table
            bundles.Add(new ScriptBundle("~/bundles/fooTable/js").Include(
                      "~/Vendor/fooTable/dist/footable.all.min.js"));

            // Foo Table style
            bundles.Add(new StyleBundle("~/bundles/fooTable/css").Include(
                      "~/Vendor/fooTable/css/footable.core.min.css", new CssRewriteUrlTransform()));

            // jQuery Validation
            bundles.Add(new ScriptBundle("~/bundles/validation/js").Include(
                      "~/Vendor/jquery-validation/jquery.validate.min.js"));

            #region Nigmys Components
            //Nigmys Styles
            bundles.Add(new StyleBundle("~/bundles/nigmyscomponents/css").Include(
                "~/Content/NigmysComponents/button.css", new CssRewriteUrlTransform()).Include(
                "~/Content/NigmysComponents/wizard.css", new CssRewriteUrlTransform()).Include(
                "~/Content/NigmysComponents/upload.css", new CssRewriteUrlTransform()).Include(
                "~/Content/NigmysComponents/navigation.css", new CssRewriteUrlTransform()).Include(
                "~/Content/NigmysComponents/side-bar.css", new CssRewriteUrlTransform()));

            //Nigmys Scripts
            bundles.Add(new ScriptBundle("~/bundles/nigmyscomponents/js").Include(
                "~/Scripts/NigmysComponents/wizard.js").Include(
                "~/Scripts/NigmysComponents/upload.js").Include(
                "~/Scripts/NigmysComponents/side-bar.js"));

            /*Individual Styles*/

            //Side-Bar Style
            bundles.Add(new StyleBundle("~/bundles/side-bar/css").Include(
                "~/Content/NigmysComponents/side-bar.css", new CssRewriteUrlTransform()));

            //Navigation Style
            bundles.Add(new StyleBundle("~/bundles/navigation/css").Include(
                "~/Content/NigmysComponents/navigation.css", new CssRewriteUrlTransform()));

            //Button Style
            bundles.Add(new StyleBundle("~/bundles/buttons/css").Include(
                "~/Content/NigmysComponents/buttons.css", new CssRewriteUrlTransform()));

            //Wizard Style
            bundles.Add(new StyleBundle("~/bundles/wizard/css").Include(
                "~/Content/NigmysComponents/wizard.css", new CssRewriteUrlTransform()));

            //Upload Style
            bundles.Add(new StyleBundle("~/bundles/upload/css").Include(
                "~/Content/NigmysComponents/upload.css"));

            /*Individual Scripts*/

            //Side-Bar Scripts
            bundles.Add(new ScriptBundle("~/bundles/side-bar/js").Include(
                "~/Scripts/nigmyscomponents/side-bar.js"));

            //Wizard Scripts
            bundles.Add(new ScriptBundle("~/bundles/wizard/js").Include(
                "~/Scripts/nigmyscomponents/wizard.js"));

            //Upload Scripts
            bundles.Add(new ScriptBundle("~/bundles/upload/js").Include(
                "~/Scripts/nigmyscomponents/upload.js"));
            #endregion

            #region Home Layout
            //Home Styles
            bundles.Add(new StyleBundle("~/bundles/home/css").Include(
                "~/Content/home/home.css", new CssRewriteUrlTransform()));
            #endregion

            #region Main Layout
            //Main Styles
            bundles.Add(new StyleBundle("~/bundle/main/css").Include(
                "~/Content/main/main.css"));
            #endregion

            #region Sign Up Components
            //Sign up
            bundles.Add(new StyleBundle("~/bundles/signup/css").Include(
                "~/Content/SignUp/sign-up.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/signup/js").Include(
                "~/Scripts/SignUp/signup.js").Include(
                "~/Scripts/Sha256/sha256.js"));
            #endregion

            #region Sign In Components
            //Sign In
            bundles.Add(new StyleBundle("~/bundles/signin/css").Include(
                "~/Content/SignIn/signIn.css"));

            
            bundles.Add(new ScriptBundle("~/bundles/signin/js").Include(
                "~/Scripts/SignIn/signin.js").Include(
                "~/Scripts/Sha256/sha256.js"));
            #endregion

            #region SHA256 Hash

            //SHA256 Hash Script
            bundles.Add(new ScriptBundle("~/bundles/sha256/js").Include(
                "~/Scripts/Sha256/sha256.js"));

            #endregion

            //Landing-Page Custom
            bundles.Add(new StyleBundle("~/bundles/landing-page/css").Include(
                "~/Content/landingStyle.css", new CssRewriteUrlTransform()));

            //Login Custom Style
            bundles.Add(new StyleBundle("~/bundles/login-page/css").Include(
                "~/Content/loginCustom.css", new CssRewriteUrlTransform()));

            //Add New Investment Script
            bundles.Add(new ScriptBundle("~/bundles/add-new-investment/js").Include(
                "~/Scripts/addInvestment.js"));

            //Numeral JS Script
            bundles.Add(new ScriptBundle("~/bundles/numeral-js/js").Include(
                "~/Vendor/numeral-js/min/numeral.min.js"));

            //Investment List
            bundles.Add(new StyleBundle("~/bundles/investment-list/css").Include(
                "~/Content/investmentListCustom.css"));

            bundles.Add(new ScriptBundle("~/bundles/investment-list/js").Include(
                "~/Scripts/investmentList.js"));

            //Investment View
            bundles.Add(new StyleBundle("~/bundles/investment-view/css").Include(
               "~/Content/investmentview.css"));

        }

    }
}
