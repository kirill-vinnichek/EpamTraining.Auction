using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Auction.UI.App_Start
{
    public static class BundleConfig
    {

        public static void RegistreBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Jquery").Include(
                     "~/Scripts/jquery-2.1.4.min.js",
                     "~/Scripts/jquery.validate.min.js",
                     "~/Scripts/jquery.validate.unobtrusive.min.js",
                     "~/Scripts/jquery.unobtrusive-ajax.min.js"
                     ));
            
            
               
            bundles.Add(new ScriptBundle("~/Scripts/Brushed").Include(
                "~/Scripts/Brushed/bootstrap.min.js",
                "~/Scripts/Brushed/supersized.3.2.7.min.js",
                 "~/Scripts/Brushed/waypoints.js",
                 "~/Scripts/Brushed/waypoints-sticky.js",
                 "~/Scripts/Brushed/jquery.isotope.js",
                 "~/Scripts/Brushed/jquery.fancybox.pack.js",
                "~/Scripts/Brushed/jquery.fancybox-media.js",
                 "~/Scripts/Brushed/modernizr.js",
                "~/Scripts/Brushed/jquery.tweet.js",
                "~/Scripts/Brushed/plugins.js",
                "~/Scripts/Brushed/main.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/Dmupload")
                .Include("~/Scripts/DmUpload/dmuploader.min.js",
                         "~/Scripts/DmUpload/upload.js"));


            bundles.Add(new StyleBundle("~/Content/Brushed").Include(
                "~/Content/Brushed/bootstrap.min.css",
                "~/Content/Brushed/main.css",
                 "~/Content/Brushed/supersized.css",
                "~/Content/Brushed/supersized.shutter.css",
                "~/Content/Brushed/fancybox/jquery.fancybox.css",
                "~/Content/Brushed/fonts.css",
                 "~/Content/Brushed/shortcodes.css",
                "~/Content/Brushed/bootstrap-responsive.min.css",
                  "~/Content/Brushed/responsive.css",
                  "~/Content/Site.css"


                ));


        }


    }
}