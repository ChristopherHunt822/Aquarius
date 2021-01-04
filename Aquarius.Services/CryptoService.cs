using Aquarius.Data;
using Aquarius.Models.Crypto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Services
{
    public class CryptoService
    {
        private readonly Guid _userId;

        public CryptoService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateCrypto(CryptoCreate model)
        {
            var entity =
                new Crypto()
                {
                    OwnerID = _userId,
                    Name = model.Name,
                    Symbol = model.Symbol
                };

                        using (var ctx = new ApplicationDbContext())
                        {
                            ctx.Cryptos.Add(entity);
                            return await ctx.SaveChangesAsync() == 1;
                        }
        }

        public async Task<IEnumerable<CryptoListItem>> GetCryptos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cryptos
                        .Where(c => c.OwnerID == _userId)
                        .Select(
                            c =>
                                new CryptoListItem
                                {
                                    CryptoID = c.CryptoID,
                                    Name = c.Name,
                                    Symbol = c.Symbol
                                }
                        );
                return await query.ToListAsync();
            }
        }

        public async Task<CryptoDetail> GetCryptoByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    await ctx
                        .Cryptos
                        .SingleAsync(c => c.CryptoID == id && c.OwnerID == _userId);
                return
                    new CryptoDetail
                    {
                        CryptoID = entity.CryptoID,
                        Name = entity.Name,
                        Symbol = entity.Symbol
                    };
            }
        }

        public async Task<bool> UpdateCrypto(CryptoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cryptos
                        .Single(c => c.CryptoID == model.CryptoID && c.OwnerID == _userId);

                entity.Name = model.Name;
                entity.Symbol = model.Symbol;

                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<bool> DeleteCrypto(int cryptoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cryptos
                        .Single(c => c.CryptoID == cryptoID && c.OwnerID == _userId);

                ctx.Cryptos.Remove(entity);

                return await ctx.SaveChangesAsync() == 1;
            }
        }
    }

}
