using Aquarius.Data;
using Aquarius.Models.Purchase;
using System;
using System.Collections.Generic;
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
        
        public bool CreatePurchase(PurchaseCreate model)
        {
            var entity =
                new Purchase()
                {
                    OwnerID = _userId,
                    AcctID = model.AcctID,
                    CryptoID = model.CryptoID,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    TotalValue = model.TotalValue,
                    DatePurchased = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Purchases.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        // GET: All Purchases
        public IEnumerable<PurchaseListItem> GetPurchases()
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
                                TotalValue = p.TotalValue,
                                DatePurchased = p.DatePurchased
                            }
                        );
                return query.ToArray();
            }
        }
        //Get: Purchase by ID

        public PurchaseDetail GetPurchaseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Purchases
                        .Single(p => p.PurchaseID == id && p.OwnerID == _userId);
                return
                    new PurchaseDetail
                    {
                        PurchaseID = entity.PurchaseID,
                        AcctID = entity.AcctID,
                        CryptoID = entity.CryptoID,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        TotalValue = entity.TotalValue,
                        DatePurchased = entity.DatePurchased
                    };
            }
        }

    }
}
