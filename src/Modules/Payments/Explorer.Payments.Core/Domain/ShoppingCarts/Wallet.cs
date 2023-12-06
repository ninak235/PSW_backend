using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.ShoppingCarts
{
    public class Wallet : Entity
    {
        public int TouristId { get; set; }
        public double Money { get; set; }
        
        public Wallet(int touristId, double money)
        {
            TouristId = touristId;
            Money=0;
        }
    }
}
