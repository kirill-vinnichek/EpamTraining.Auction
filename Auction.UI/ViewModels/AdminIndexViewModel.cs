using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction.UI.ViewModels
{
    public class AdminIndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Category> Category { get; set; }




    }
}