using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos.ShoppingCartDtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Public.ShoppingCart
{
    public interface IWalletService
    {
        Result<PagedResult<WalletDto>> GetPaged(int page, int pageSize);
       // Result<PagedResult<WalletDto>> GetByTouristId(int userId, int page, int pageSize);
    }
}
