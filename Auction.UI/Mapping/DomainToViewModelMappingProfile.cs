using Auction.Model.Models;
using Auction.UI.ViewModels;
using AutoMapper;

namespace Auction.UI.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile():base("DomainToViewModelMappings")
        {

        }

        protected override void Configure()
        {
            CreateMap<User, RegisterViewModel>();
            CreateMap<Lot, AddLotViewModel>();
            CreateMap<Lot, LotDetailsViewModel>();
            CreateMap<User, UserDetailsViewModel>();
        }


    }
}