using Aquarius.Data;
using Aquarius.Models.Investor;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class InvestorService
    {
        private readonly Guid _userId;

        public InvestorService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateInvestor(InvestorCreate model)
        {
            var entity =
                new Investor()
                {
                    OwnerID = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Investors.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<InvestorListItem>> GetInvestors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Investors
                        .Where(i => i.OwnerID == _userId)
                        .Select(
                            i =>
                                new InvestorListItem
                                {
                                    InvestorID = i.InvestorID,
                                    FirstName = i.FirstName,
                                    LastName = i.LastName
                                }
                            );

                return await query.ToListAsync();
            }
        }
        public async Task<InvestorDetail> GetInvestorByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    await ctx
                        .Investors
                        .SingleAsync(i => i.InvestorID == id && i.OwnerID == _userId);
                return
                    new InvestorDetail
                    {
                        InvestorID = entity.InvestorID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber
                    };
            }
        }

        public async Task<bool> UpdateInvestor(InvestorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Investors
                        .Single(i => i.InvestorID == model.InvestorID && i.OwnerID == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        /*
        public async Task<bool> DeleteInvestor (int investorID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Investors
                        .Single(i => i.InvestorID == investorID && i.OwnerID == _userId);

                ctx.Investors.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }
        */
    }

}
