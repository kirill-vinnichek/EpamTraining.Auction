using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service.CloudStorage
{
    public interface ICloudStorage
    {
        bool UploadImage(string imgNane, Stream img);
        string GetUrl(string imgName, int width, int height);
        string GetUrl(string imgName);
    }
}
