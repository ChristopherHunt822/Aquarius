using Aquarius.Data;
using Aquarius.Models.Acct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class AcctService
    {
        private readonly Guid _userId;

        public AcctService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateAcct(AcctCreate model)
        {
            var entity =
                new Acct()
                {
                    OwnerID = _userId,
                    AcctType = (Acct.AcctTypeEnum)model.AcctType,
                    TotalValue = model.TotalValue,
                    OpenedUtc = DateTimeOffset.Now,
                    InvestorID = model.InvestorID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Accts.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<AcctListItem>> GetAccts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Accts
                        .Where(a => a.OwnerID == _userId)
                        .Select(
                            a =>
                                new AcctListItem
                                {
                                    AcctID = a.AcctID,
                                    AcctType = (AcctListItem.AcctTypeEnum)a.AcctType,
                                    TotalValue = a.TotalValue,
                                    OpenedUtc = a.OpenedUtc,
                                }
                        );
                return await query.ToListAsync();
            }
        }

        public async Task<AcctDetail> GetAcctById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    await ctx
                        .Accts
                        .SingleAsync(a => a.AcctID == id && a.OwnerID == _userId);
                return
                    new AcctDetail
                    {
                        InvestorID = entity.InvestorID,
                        AcctID = entity.AcctID,
                        AcctType = (AcctDetail.AcctTypeEnum)entity.AcctType,
                        TotalValue = entity.TotalValue,
                        OpenedUtc = entity.OpenedUtc
                    };
            }
        }

        public async Task<bool> UpdateAcct(AcctEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accts
                        .Single(a => a.AcctID == model.AcctID && a.OwnerID == _userId);

                entity.AcctID = model.AcctID;
                entity.AcctType = (Acct.AcctTypeEnum)model.AcctType;
                entity.InvestorID = model.InvestorID;

                return await ctx.SaveChangesAsync() == 1; 
            }
        }
        public async Task<bool> DeleteAcct(int acctID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Accts
                        .Single(i => i.AcctID == acctID && i.OwnerID == _userId);

                ctx.Accts.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }
}
