using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Model.Models;
using Auction.Service.CloudStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{
    public interface IImageService
    {
        void AddImage(Image image);
        bool StoreImage(string imgName, Stream File);
        Image GetImage(string imgName);
        Image GetImage(int id);
        Image GetImage(int id, int width, int height);
        string GetResizedUrl(string imgName, int width, int height);
        void DeleteImage(int id);
        void Save();
    }


    public class ImageService : IImageService
    {
        private IUnitOfWork uow;
        private ICloudStorage cloudStorage;
        private IImageRepository imageRepository;
        public ImageService(IUnitOfWork uow, ICloudStorage cloudStorage, IImageRepository imageRepository)
        {
            this.uow = uow;
            this.cloudStorage = cloudStorage;
            this.imageRepository = imageRepository;
        }

        public bool StoreImage(string imgName, Stream file)
        {
            return cloudStorage.UploadImage(imgName, file);
        }

        public void AddImage(Image image)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            uow.Commit();
        }

        public Image GetImage(string imgName)
        {
            var img = imageRepository.Get(im => im.Url == imgName);
            var url = cloudStorage.GetUrl(img.Url);
            return new Image()
            {
                ImageId = img.ImageId,
                LotId = img.LotId,
                Url = url
            };
        }

        public Image GetImage(int id)
        {
            var img = imageRepository.GetById(id);
            var url = cloudStorage.GetUrl(img.Url);
            return new Image()
            {
                ImageId = img.ImageId,
                LotId = img.LotId,
                Url = url
            };
        }
        public Image GetImage(int id, int width, int height)
        {
            var img = imageRepository.GetById(id);
            var url = cloudStorage.GetUrl(img.Url,width,height);
            return new Image()
            {
                ImageId = img.ImageId,
                LotId = img.LotId,
                Url = url
            };
        }

        public string GetResizedUrl(string imgName, int width, int height)
        {
            return cloudStorage.GetUrl(imgName, width, height);
        }

        public void DeleteImage(int id)
        {
            imageRepository.Delete(i => i.LotId == id);
            Save();
        }

      
    }
}
