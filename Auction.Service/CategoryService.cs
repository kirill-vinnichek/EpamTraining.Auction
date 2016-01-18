using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{

    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

    }

    public class CategoryService : ICategoryService
    {

        private IUnitOfWork uow;
        private ICategoryRepository categoryRepository;
        public CategoryService(IUnitOfWork uow, ICategoryRepository categoryRepository)
        {
            this.uow = uow;
            this.categoryRepository = categoryRepository;
        }


        public IEnumerable<Category> GetCategories()
        {
            return categoryRepository.GetMany(c => c.ParentCategoryId == null);
        }
    }
}
