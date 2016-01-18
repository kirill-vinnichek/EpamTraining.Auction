using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class InitialData : DropCreateDatabaseIfModelChanges<AuctionEntities>
    {
        protected override void Seed(AuctionEntities context)
        {

            new List<Role>()
            {
                new Role {Name = "admin" },
                new Role {Name = "user" },
                new Role {Name = "moderator" }
            }.ForEach(r => context.Roles.Add(r));

            var c = new Category() { Title = "Art" };
            context.Categories.Add(c);

            new List<Category>()
            {
                new Category {Title = "Cars" },
                new Category {Title = "Mobile" },
                new Category {Title = "House" },
                new Category {Title = "Other" }
            }.ForEach(ca => context.Categories.Add(ca));

            context.Commint();

            new List<Category>()
            {
                new Category {Title = "Pictures",ParentCategoryId = 1 },
                new Category {Title = "Books",ParentCategoryId = 1 }
            }.ForEach(ca =>
            {
                context.Categories.Add(ca);
                c.SubCategories.Add(ca);
            });
            context.Commint();
        }
    }
}
