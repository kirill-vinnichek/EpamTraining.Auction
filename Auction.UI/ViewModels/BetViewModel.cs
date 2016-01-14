using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
    public class BetViewModel
    {
        public BetViewModel()
        {
            Date = DateTime.Now;
        }

        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int LotId { get; set; }

        public virtual UserViewModel User { get; set; }


    }
}
