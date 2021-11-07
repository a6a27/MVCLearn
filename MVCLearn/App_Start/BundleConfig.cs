using System.Web;
using System.Web.Optimization;

namespace MVCLearn
{
    public class BundleConfig
    {
        // 如需統合的詳細資訊，請瀏覽 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js",
                         "~/Scripts/jquery.blockUI.js",
                         "~/Scripts/sweetalert.min.js",
                         "~/Scripts/bootstrap-datepicker.min.js",
                         "~/Scripts/locales/bootstrap-datepicker.zh-TW.min.js",
                         "~/Scripts/CustomJs/Common.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            //Microsoft.jQuery.Unobtrusive.Ajax
            bundles.Add(new ScriptBundle("~/bundles/jqueryajax").Include(
            "~/Scripts/jquery.unobtrusive-ajax*"));

            // 使用開發版本的 Modernizr 進行開發並學習。然後，當您
            // 準備好可進行生產時，請使用 https://modernizr.com 的建置工具，只挑選您需要的測試。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/sweetalert.css",
                      "~/Content/site.css",
                      "~/Content/style_custom.css"));
        }
    }
}
