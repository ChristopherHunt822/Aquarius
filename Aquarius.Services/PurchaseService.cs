using Aquarius.Data;
using Aquarius.Models.PurchaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class PurchaseService
    {
        private readonly Guid _userId;

        public PurchaseService(Guid userId)
        {
            _userId = userId;
        }
        
        public async Task<bool> CreatePurchase(PurchaseCreate model)
        {
            var entity =
                new Purchase()
                {
                    OwnerID = _userId,
                    AcctID = model.AcctID,
                    Symbol = (Purchase.PCryptoSymbolEnum)model.Symbol,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    //Total = model.Total,
                    PurchaseDate = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Purchases.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        // GET: All Purchases
        public async Task<IEnumerable<PurchaseListItem>> GetPurchases()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Purchases
                        .Where(p => p.OwnerID == _userId)
                        .Select(
                            p => new PurchaseListItem
                            {
                                PurchaseID = p.PurchaseID,
                                AcctID = p.AcctID,
                                Quantity = p.Quantity,
                                Price = p.Price,
                                Total = p.Total,
                                PurchaseDate = p.PurchaseDate
                            }
                        );
                return await query.ToListAsync();
            }
        }
        //Get: Purchase by ID

        public async Task<PurchaseDetail> GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    await ctx
                        .Purchases
                        .SingleAsync(p => p.PurchaseID == id && p.OwnerID == _userId);
                return
                    new PurchaseDetail
                    {
                        PurchaseID = entity.PurchaseID,
                        AcctID = entity.AcctID,
                        Symbol = (PurchaseDetail.PCryptoSymbolEnum)entity.Symbol,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        Total = entity.Total,
                        PurchaseDate = entity.PurchaseDate
                    };
            }
        }

    }
}
