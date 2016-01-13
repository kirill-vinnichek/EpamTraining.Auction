using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Auction.UI.Helpers
{
    public static class Utils
    {
        public static bool IsSupportedMimeType(string mimeType)
        {
            if (!string.IsNullOrWhiteSpace(mimeType))
                switch (mimeType)
                {
                    case "image/jpg":
                    case "image/jpeg":
                    case "image/png":
                    case "image/gif":
                        return true;
                }
            return false;
        }
    }

}