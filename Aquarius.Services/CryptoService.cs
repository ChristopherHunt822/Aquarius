using Aquarius.Data;
using Aquarius.Models.Crypto;
using System;
using System.Collections.Generic;
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

        public bool CreateCrypto(CryptoCreate model)
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
                            return ctx.SaveChanges() == 1;
                        }
        }

        public IEnumerable<CryptoListItem> GetCryptos()
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
                return query.ToArray();
            }
        }

        public CryptoDetail GetCryptoByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cryptos
                        .Single(c => c.CryptoID == id && c.OwnerID == _userId);
                return
                    new CryptoDetail
                    {
                        CryptoID = entity.CryptoID,
                        Name = entity.Name,
                        Symbol = entity.Symbol
                    };
            }
        }

        public bool UpdateCrypto(CryptoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cryptos
                        .Single(c => c.CryptoID == model.CryptoID && c.OwnerID == _userId);

                entity.Name = model.Name;
                entity.Symbol = model.Symbol;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCrypto(int cryptoID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cryptos
                        .Single(c => c.CryptoID == cryptoID && c.OwnerID == _userId);

                ctx.Cryptos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }

}
