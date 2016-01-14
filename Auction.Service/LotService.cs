using Auction.Data.Infrastructure;
using Auction.Data.Repository;
using Auction.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Service
{

    public interface ILotService
    {
        IEnumerable<Lot> GetLots();
        IEnumerable<Lot> GetSomeLots(int take, int skip);
        IEnumerable<Lot> GetSomeLots(int take, int skip, string search);
        IEnumerable<Lot> GetLots(string search);
        IEnumerable<Lot> GetInterstingLots(int userid);
        void AddLot(Lot lot);
        Lot GetLot(int id);
        void Update(Lot lot);
        int Count();
        bool MakeBet(int userId, int lotId);

        void Save();
    }



    public class LotService : ILotService
    {
        private ILotRepository lotRepository;
        private IUnitOfWork uow;
        private IUserService userService;

        public LotService(ILotRepository lotRepository, IUnitOfWork uow, IUserService userService)
        {
            this.lotRepository = lotRepository;
            this.uow = uow;
            this.userService = userService;
        }

        public void AddLot(Lot lot)
        {
            if (lot != null)
            {
                lotRepository.Add(lot);
                Save();
            }
        }

        public Lot GetLot(int id)
        {
            return lotRepository.GetById(id);
        }

        public IEnumerable<Lot> GetLots()
        {
            return lotRepository.GetAll().ToList();
        }

        public IEnumerable<Lot> GetLots(string search)
        {
            return lotRepository.GetMany(l => l.Title.ToLower().Contains(search) || l.Description.ToLower().Contains(search));
        }

        public int Count()
        {
            return lotRepository.Count();
        }



        public IEnumerable<Lot> GetSomeLots(int take, int skip)
        {            
            return lotRepository.GetMany(take, skip);
        }

        public IEnumerable<Lot> GetSomeLots(int take, int skip, string search)
        {
            return lotRepository.GetMany(l => l.Title.ToLower().Contains(search) || l.Description.ToLower().Contains(search), take, skip);
        }

        public void Update(Lot lot)
        {
            lotRepository.Update(lot);
            Save();
        }

        public IEnumerable<Lot> GetInterstingLots(int userId)
        {
            return lotRepository.GetMany(l => l.Bets.Any(b => b.User.UserId == userId));
        }

        public void Save()
        {
            uow.Commit();
        }

        public bool MakeBet(int userId, int lotId)
        { 
            var lot = GetLot(lotId);
            var user = userService.GetUser(userId);
            var amount = lot.CurrentCost * (decimal)0.2;
            if (!userService.CanMakeBet(user, amount))
                return false;
            lot.CurrentCost += amount;
            var bet = new Bet()
            {
                Amount = amount,
                User = user,
                LotId = lot.LotId
            };
            lot.Bets.Add(bet);
            Save();
            return true;
        }
    }
}
