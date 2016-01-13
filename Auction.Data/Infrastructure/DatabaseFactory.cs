using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Infrastructure
{
    public class DatabaseFactory : Disposable,IDatabaseFactory
    {

        private AuctionEntities context;

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }

        public AuctionEntities Get()
        {
            return context ?? (context = new AuctionEntities());
        }
    }
}
