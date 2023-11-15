using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.BuildingBlocks.Infrastructure.Database;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.Core.Domain.ShoppingCarts;
using Explorer.Tours.Core.Domain.Tours;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Tours.Infrastructure.Database.Repositories
{
    public class TourPurchaseTokenRepository:ITourPurchaseTokenRepository
    {
        private readonly DbSet<TourPurchaseToken> _tokens;
        private readonly ToursContext _context;

        public TourPurchaseTokenRepository(ToursContext context)
        {
            _context = context;
            _tokens = _context.Set<TourPurchaseToken>();
        }
        public PagedResult<TourPurchaseToken> GetByUserId(int userId, int page, int pageSize)
        {

            var tokens = _tokens.Where(t => t.TouristId == userId).GetPagedById(page, pageSize);
            return tokens.Result;
        }
    }
}
