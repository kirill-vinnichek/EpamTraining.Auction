using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Model.Models
{
   public class UserViewModel
    {
       
        public UserViewModel()
        {
            DateCreated = DateTime.Now;
            Cash = 1000;
            LastName = string.Empty;
        }


        public int UserId { get; set; }

        public string Email { get; set; }      

        public string FirstName { get; set; }      
         
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public decimal Cash { get; set; }
        public string AvatarPath { get; set; }

        public DateTime DateCreated { get; set; }

        public  ICollection<Role> Roles { get; set; }

        public  ICollection<LotViewModel> Lots { get; set; }


        public string DisplayName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
