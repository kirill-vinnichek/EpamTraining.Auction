using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.UI.ViewModels
{
    public class IndexViewModel
    {
        public int PageCount { get; set; }
        public int Page { get; set; }
        public IEnumerable<Lot> Lots { get; set; }
        public IEnumerable<Category> Categories { get; set; }

    }
}