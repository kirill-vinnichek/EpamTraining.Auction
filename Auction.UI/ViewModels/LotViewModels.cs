using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction.UI.ViewModels
{
    public class AddLotViewModel
    {
        [Display(Name = "Enter title")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Title { get; set; }
        [Display(Name = "Enter Description")]
        [StringLength(300, ErrorMessage = "Description must contain at least {2} characters", MinimumLength = 10)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter initial cost")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Enter positive cost")]
        public decimal InitialCost { get; set; }
        [Required(ErrorMessage = "The field can not be empty!")]
        [Range(3,30,ErrorMessage ="Enter duration from 3 to 30 days")]
        public int Duration { get; set;} 
        [Required]   
        public int ImgCount { get; set; }
        public IEnumerable<string> Urls { get; set;} 
    }

    public class LotDetailsViewModel
    {
        public int LotId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal CurrentCost { get; set; }
        public DateTime DateExhibited { get; set; }
        public DateTime? DateSold { get; set; }
        public UserViewModel Seller { get; set; }
        public  IEnumerable<ImageViewModel> Images { get; set; }
        public IEnumerable<BetViewModel> Bets { get; set; }
    }
}