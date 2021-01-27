using PromotionEngine;
using System;
using System.Collections.Generic;
using Xunit;

namespace PromotionEngineUnitTest
{
    public class PromotionEngineTests
    {
        readonly Cart _cart;//system under test
        public PromotionEngineTests()
        {
            _cart = new Cart();
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void TestCheckout(decimal amount, Dictionary<string, int> _cartItems, Dictionary<string, decimal> _products, List<Promotion> _promotions)
        {
            _cart.CartItemsQty = _cartItems;
            _cart.ProductValues = _products;
            _cart.Promotions = _promotions;
            Assert.Equal(amount, _cart.Checkout());
        }
        public static IEnumerable<object[]> TestData()
        {
            var productList = new Dictionary<string, decimal>() { { "A", 50 }, { "B", 30 }, { "C", 20 }, { "D", 15 } };
            var pro1 = new PromotionOnSameType()
            {
                OfferOnSameItems = new List<OfferOnSameProduct>() {
                     new OfferOnSameProduct() { ItemName = "A", Count = 3, OfferValue = 130 },
                     new OfferOnSameProduct(){ ItemName="B",Count = 2,OfferValue =45 } }
            };
            var pro2 = new CombinationPromotion()
            {
                OfferOnCombinations = new List<OfferDifferentProducts>(){
                {
                    new OfferDifferentProducts(){
                        Combinations = new Dictionary<string, int>(){
                            { "C",1},{ "D", 1 } },
                        OfferValue = 30 }
                }}
            };
            var promotions = new List<Promotion>(){pro1,pro2};
            yield return new object[] {100,new Dictionary<string, int>() {{"A",1 },{"B",1},{"C",1},{ "D", 0 }},productList ,promotions};
            yield return new object[] { 380, new Dictionary<string, int>() { { "A", 5 }, { "B", 5 }, { "C", 1 }, { "D", 1 } }, productList, promotions };
            yield return new object[] { 280, new Dictionary<string, int>() { { "A", 3 }, { "B", 5 }, { "C", 1 }, { "D", 1 } }, productList, promotions };
        }
    }
}
