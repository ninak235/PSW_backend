using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos.ShoppingCartDtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Payments.Core.UseCases.ShoppingCarts
{
    public class WalletService : CrudService<WalletDto, Wallet>, IWalletService
    {
       // private readonly IWalletRepository _wallletRepository;
        public WalletService(ICrudRepository<Wallet> crudRepository, IMapper mapper) : base(crudRepository, mapper)
        {
        }
        //public Result<PagedResult<WalletDto>> GetByTouristId(int userId, int page, int pageSize)
        //{
        //    var wallet = _repository.GetByTouristId(userId, page, pageSize);
        //    return MapToDto(wallet);
        //}
    }
}
