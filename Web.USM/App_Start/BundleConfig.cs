using System.Web;
using System.Web.Optimization;

namespace Web.USM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular-animate").Include(
                        "~/Scripts/angular-animate.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular-route").Include(
                        "~/Scripts/angular-route.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular-validator").Include(
                        "~/Scripts/angular-validator.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular-infinite").Include(
                        "~/Scripts/ng-infinite-scroll.min.js"));
            
            //bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
            //            "~/Scripts/jquery.dataTables.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/angular-dataTables").Include(
            //            "~/Scripts/angular-datatables.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-toggle").Include(
                        "~/Scripts/bootstrap-toggle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ngProgress").Include(
                        "~/Scripts/ngProgress.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/Router").Include(
                        "~/Scripts/Router.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen_jquery").Include(
                        "~/Scripts/chosen.jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen_proto").Include(
                        "~/Scripts/chosen.proto.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                        "~/Scripts/moment.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular-moment").Include(
                        "~/Scripts/angular-moment.min.js"));

            //bundles.Add(new ScriptBundle("~/bundles/dataTables_bootstrap").Include(
            //            "~/Scripts/angular-datatables.bootstrap.js"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/bootstrap-toggle.min.css",
                      "~/Content/ngProgress.css",
                      "~/Content/Menu.css",
                      "~/Content/DefaultTheme.css",
                      "~/Content/chosen.min.css"//,
                      //"~/Content/datatables.bootstrap.min"
                      ));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
