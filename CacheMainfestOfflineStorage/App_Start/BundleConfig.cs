using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace CacheMainfestOfflineStorage
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // JS 

            bundles.Add(new ScriptBundle("~/bundles/javascript").Include(

                        // lib
                        "~/content/js/lib/jquery-2.0.2.js",
                        "~/content/js/lib/knockout-2.2.1.js",

                        // app
                         "~/content/js/app/main.js",
                         "~/content/js/app/offline.js"

                        ));

            BundleTable.EnableOptimizations = true;
        }
    }
}