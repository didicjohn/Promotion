using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    public class CombinationPromotion : Promotion
    {
        List<OfferDifferentProducts> offerOnCombinations;
        public List<OfferDifferentProducts> OfferOnCombinations { get => offerOnCombinations; set => offerOnCombinations = value; }
        public CombinationPromotion()
        {
            OfferOnCombinations = new List<OfferDifferentProducts>();
        }
        public override void ApplyPromotion(ref Dictionary<string, int> _cartItems, ref decimal billAmount)
        {
            if (_cartItems == null) return;
            foreach (OfferDifferentProducts offer in this.OfferOnCombinations)
            {
                // if cartItem has all the keys and corresponding  count then apply
                bool qualify = true;
                do
                {
                    foreach (KeyValuePair<string, int> pair in offer.Combinations)
                        if (_cartItems[pair.Key] < pair.Value) qualify = false;
                    if (qualify)
                    {
                        foreach (KeyValuePair<string, int> pair in offer.Combinations)
                            _cartItems[pair.Key] -= pair.Value;
                        billAmount += offer.OfferValue;
                        Console.WriteLine("Applied Offer {0} ", offer.ToString());
                    }
                } while (qualify);
            }

        }
    }
}
