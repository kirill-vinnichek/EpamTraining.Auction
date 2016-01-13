using Auction.Data.Infrastructure;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class CategoryRepository: RepositoryBase<Category>,ICategoryRepository
    {
        public CategoryRepository(IDatabaseFactory DatabaseFactory ) :base (DatabaseFactory)
        { }
    }

    public interface ICategoryRepository:IRepository<Category> { }
}
