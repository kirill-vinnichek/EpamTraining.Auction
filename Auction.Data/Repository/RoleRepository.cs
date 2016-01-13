using Auction.Data.Infrastructure;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Data.Repository
{
   public class RoleRepository:RepositoryBase<Role>,IRoleRepository
    {
        public RoleRepository(IDatabaseFactory DatabaseFactory):base(DatabaseFactory)
        { }
    }
    public interface IRoleRepository : IRepository<Role> { }
}
