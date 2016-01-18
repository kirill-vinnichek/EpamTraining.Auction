using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
   public class Category
    {
        public Category()
        {
            SubCategories = new HashSet<Category>();
        }

        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }



    }
}
