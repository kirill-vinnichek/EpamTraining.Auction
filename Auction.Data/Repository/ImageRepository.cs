using Auction.Data.Infrastructure;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class ImageRepository:RepositoryBase<Image>,IImageRepository
    {
        public ImageRepository(IDatabaseFactory databaseFactory) :base (databaseFactory) { }
    }

    public interface IImageRepository : IRepository<Image> { }
}
