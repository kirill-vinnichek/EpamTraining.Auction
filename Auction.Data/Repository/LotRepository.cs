using Auction.Data.Infrastructure;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
    public class LotRepository : RepositoryBase<Lot>, ILotRepository
    {
        public LotRepository(IDatabaseFactory databaseFactory) : base(databaseFactory) { }

        public  IEnumerable<Lot> GetMany(int take, int skip) => dbSet.OrderBy(l => l.DateExhibited).Skip(skip).Take(take).ToList();
        public  IEnumerable<Lot> GetMany(Expression<Func<Lot, bool>> where, int take, int skip) => dbSet.Where(where).OrderBy(l => l.DateExhibited).Skip(skip).Take(take).ToList();

    }


    public interface ILotRepository : IRepository<Lot>
    {
         IEnumerable<Lot> GetMany(int take, int skip);
         IEnumerable<Lot> GetMany(Expression<Func<Lot, bool>> where, int take, int skip);
    }
}
