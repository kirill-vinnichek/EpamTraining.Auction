using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{
    public interface IImageService
    {
        void AddImage(Image image);
        void Save();
    }


    public class ImageService : IImageService
    {
        public void AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
