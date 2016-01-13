using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
    public class Bet
    {
        public Bet()
        {
            Date = DateTime.Now;
        }

        public int BetId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public int LotId { get; set; }

        public virtual User User { get; set; }


    }
}
