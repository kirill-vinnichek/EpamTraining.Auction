using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.UI.Helpers
{
    public static class ControllerHelper
    {
        //public static string StoreImage(this Controller ctrl, HttpPostedFileBase file)
        //{

        //    var ext = Path.GetExtension(file.FileName);
        //    var path = Path.Combine(ConfigurationManager.AppSettings["ImagesPath"], Guid.NewGuid().ToString() + ext);
        //    var mappedPath = ctrl.Server.MapPath(path);
        //    if (File.Exists(mappedPath))
        //        File.Delete(mappedPath);
        //    file.SaveAs(mappedPath);
        //    return path;
        //}
    }
}