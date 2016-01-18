using CloudinaryDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using CloudinaryDotNet.Actions;

namespace Auction.Service.CloudStorage
{
    public class CloudinaryStorage:ICloudStorage
    {
        private Cloudinary cloudinary;
        private string cloudName = ConfigurationManager.AppSettings["CloudName"];
        private string apiKey = ConfigurationManager.AppSettings["apiKey"];
        private string apiSecret = ConfigurationManager.AppSettings["apiSecret"];



        public CloudinaryStorage()
        {
            Account account = new Account(cloudName, apiKey, apiSecret);
            cloudinary = new Cloudinary(account);
        }

        public bool UploadImage(string imgName,Stream img)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imgName, img),          
                PublicId = imgName                
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            //TODO: Дописать проверку на ошибку(не сохранилось ихображение)
            return true;
           
        }

        public string GetUrl(string imgName,int width,int height)
        {
           return cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(width).Height(height).Crop("scale")).BuildUrl(imgName);
        }

        public string GetUrl(string imgName)
        {
            return cloudinary.Api.UrlImgUp.BuildUrl(imgName);
        }
    }
}
