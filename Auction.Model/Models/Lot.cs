using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
    public class Lot
    {
        public Lot()
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

        public virtual User Seller { get; set; }

        public virtual User Buyer { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
