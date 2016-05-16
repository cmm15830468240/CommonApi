using System.Web;
using System.Web.Optimization;

namespace CommonApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/basecsslib").Include(
              "~/Content/bootstrap.min.css",
              "~/Content/login.css"
              ));

            bundles.Add(new ScriptBundle("~/js/basejslib").Include(
                "~/Scripts/jquery-1.10.2.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));

          
        }
    }
}
