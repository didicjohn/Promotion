using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class OfferOnSameProduct : Offer
    {
        string itemName;
        int count;
        public string ItemName { get => itemName; set => itemName = value; }
        public int Count { get => count; set => count = value; }
    }
}
