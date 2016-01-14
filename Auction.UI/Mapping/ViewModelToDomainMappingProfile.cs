using Auction.Model.Models;
using Auction.UI.ViewModels;
using AutoMapper;
using System;
using System.Web.Helpers;

namespace Auction.UI.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {

        public ViewModelToDomainMappingProfile() : base("ViewModelToDomainMappings")
        {

        }

        protected override void Configure()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(p => p.PasswordHash, opt => opt.MapFrom(source => Crypto.HashPassword(source.Password)));
            CreateMap<AddLotViewModel, Lot>()
                .ForMember(p => p.DateOfFinishing, opt => opt.MapFrom(source => DateTime.Now.AddDays(source.Duration)))
                .ForMember(p => p.CurrentCost, opt => opt.MapFrom(source => source.InitialCost));
            CreateMap<LotDetailsViewModel, Lot>();
            CreateMap<UserDetailsViewModel, User>();


            CreateMap<LotViewModel,Lot>();
            CreateMap<UserViewModel,User>();
            CreateMap<BetViewModel,Bet >();
            CreateMap<ImageViewModel,Image>();



        }
    }
}