using Auction.Data.Infrastructure;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class BetRepository : RepositoryBase<Bet>, IBetRepository
    {
        public BetRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

    }


    public interface IBetRepository : IRepository<Bet> { }
}
