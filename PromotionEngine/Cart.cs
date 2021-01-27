using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart
    {
        Dictionary<string, int> _cartItemsQty;//ProductXQuantity
        Dictionary<string, decimal> _productValues;//ProductXUnitPrice
        List<Promotion> _promotions;//ActivePromotions
        public Dictionary<string, int> CartItemsQty { get => _cartItemsQty; set => _cartItemsQty = value; }
        public Dictionary<string, decimal> ProductValues { get => _productValues; set => _productValues = value; }
        public List<Promotion> Promotions { get => _promotions; set => _promotions = value; }

        public Cart()
        {
            CartItemsQty = new Dictionary<string, int>();
            ProductValues = new Dictionary<string, decimal>();
            Promotions = new List<Promotion>();
        }

        public decimal Checkout()
        {
            decimal billAmount = 0;
            //Apply promotions
            foreach (Promotion promotion in Promotions)
                promotion.ApplyPromotion(ref _cartItemsQty, ref billAmount);

            foreach (var item in _cartItemsQty)
                billAmount += (item.Value * _productValues[item.Key]); //Qty*Price
            return billAmount;
        }
    }
}
