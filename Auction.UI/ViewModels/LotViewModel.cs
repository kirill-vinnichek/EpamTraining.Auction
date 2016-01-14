using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
    public class LotViewModel
    {
        public LotViewModel()
        {
            DateExhibited = DateTime.Now;
        }

        public int LotId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public decimal InitialCost { get; set; }
        public decimal CurrentCost { get; set; }
        public DateTime DateExhibited { get; set; }

        public DateTime DateOfFinishing { get; set; }

        public DateTime? DateSold { get; set; }

        public virtual UserViewModel Seller { get; set; }

        public virtual UserViewModel Buyer { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }
        public virtual ICollection<BetViewModel> Bets { get; set; }

    }
}
