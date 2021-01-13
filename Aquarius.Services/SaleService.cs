using Aquarius.Data;
using Aquarius.Models.SaleModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class SaleService
    {
        private readonly Guid _userId;

        public SaleService(Guid userId)
        {
            _userId = userId;
        }
        
        public async Task<bool> CreateSale(SaleCreate model)
        {
            var entity =
                new Sale()
                {
                    OwnerID = _userId,
                    AcctID = model.AcctID,
                    Symbol = (Sale.CryptoSymbolEnum)model.Symbol,
                    Quantity = model.Quantity,
                    Price = model.Price,
                    //Total = model.Total,
                    SaleDate = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sales.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }
        //GET: All Sales

        public async Task<IEnumerable<SaleListItem>> GetSales()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sales
                        .Where(s => s.OwnerID == _userId)
                        .Select(
                            s => new SaleListItem
                            {
                                SaleID = s.SaleID,
                                AcctID = s.AcctID,
                                //Total = s.Total,
                                SaleDate = s.SaleDate
                            }
                        );
                return await query.ToListAsync();
            }
        }
        //Get: Purchase by ID

        public async Task<SaleDetail> GetSaleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    await ctx
                        .Sales
                        .SingleAsync(p => p.SaleID == id && p.OwnerID == _userId);
                return
                    new SaleDetail
                    {
                        SaleID = entity.SaleID,
                        AcctID = entity.AcctID,
                        Symbol = (SaleDetail.CryptoSymbolEnum)entity.Symbol,
                        Quantity = entity.Quantity,
                        Price = entity.Price,
                        //Total = entity.Total,
                        SaleDate = entity.SaleDate
                    };
            }
        }
    }
}
