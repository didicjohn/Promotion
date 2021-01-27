using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public abstract class Promotion
    {
        public abstract void ApplyPromotion(ref Dictionary<string, int> _cartItems, ref decimal billAmount);
    }
}
