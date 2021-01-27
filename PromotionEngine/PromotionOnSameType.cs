using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionOnSameType : Promotion
    {
        List<OfferOnSameProduct> offerOnSameItems;
        public List<OfferOnSameProduct> OfferOnSameItems { get => offerOnSameItems; set => offerOnSameItems = value; }

        public PromotionOnSameType()
        {
            OfferOnSameItems = new List<OfferOnSameProduct>();
        }

        public override void ApplyPromotion(ref Dictionary<string, int> _cartItems, ref decimal billAmount)
        {
            if (_cartItems == null) return;
            foreach (OfferOnSameProduct offer in this.offerOnSameItems)
            {
                while (_cartItems[offer.ItemName] >= offer.Count)
                {
                    _cartItems[offer.ItemName] -= offer.Count;
                    billAmount += offer.OfferValue;
                }
            }

        }
    }
}
