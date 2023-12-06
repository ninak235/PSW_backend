using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.ShoppingCarts
{
    public class TourPurchaseToken : Entity
    {
        public int TouristId { get; set; }

        public int IdTour { get; set; }
        public double Price {  get; set; }
        public DateTime? PurchaseDateTime { get; private set; }

        public TourPurchaseToken(int touristId, int idTour, double price, DateTime? purchaseDateTime)
        {
            TouristId = touristId;
            IdTour = idTour;
            Price = price;
            PurchaseDateTime = purchaseDateTime;
        }

    }
}
