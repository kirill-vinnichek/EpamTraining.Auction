using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class InitialData: DropCreateDatabaseIfModelChanges<AuctionEntities>
    {
        protected override void Seed(AuctionEntities context)
        {

            new List<Role>()
            {
                new Role {Name = "admin" },
                new Role {Name = "user" },
                new Role {Name = "moderator" }
            }.ForEach(r => context.Roles.Add(r));      

            context.Commint();
        }
    }
}
