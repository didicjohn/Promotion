using System.Collections.Generic;

namespace PromotionEngine
{
    public class OfferDifferentProducts : Offer
    {
        Dictionary<string, int> combinations;

        public Dictionary<string, int> Combinations { get => combinations; set => combinations = value; }

    }
}
