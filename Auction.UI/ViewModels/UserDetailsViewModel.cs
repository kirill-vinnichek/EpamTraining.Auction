using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.UI.ViewModels
{
    public class UserDetailsViewModel
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Cash { get; set; }

        public DateTime DateCreated { get; set; }
        public string AvatarPath { get; set; }
        public IEnumerable<LotViewModel> Lots { get; set; }
        public IEnumerable<LotViewModel> InterstingLots { get; set; }

        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }


    }
}