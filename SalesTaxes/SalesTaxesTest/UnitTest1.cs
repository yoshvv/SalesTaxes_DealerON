using SalesTaxes.Interfaces;
using SalesTaxes.Logic;
using SalesTaxes.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SalesTaxesTest
{
    public class UnitTest1
    {
        private BasketLogic Logic { get; set; } = new BasketLogic();

        [Fact]
        public void OUTPUT1()
        {
            var basket = new List<Basket>() 
            {
                new Basket(product: new Item(name: "Book", price: 12.49m, category: Category.Books), quantity: 1),
                new Basket(product: new Item(name: "Book", price: 12.49m, category: Category.Books), quantity: 1),
                new Basket(product: new Item(name: "Music CD", price: 14.99m, category: Category.Others), quantity: 1),
                new Basket(product: new Item(name: "Chocolate bar", price: 0.85m, category: Category.Food), quantity: 1),
            };

            Assert.True(Logic.GetAllSalesTaxes(basket) == 1.50m);
            Assert.True(Logic.GetTotalBasket(basket) == 42.32m);
        }

        [Fact]
        public void OUTPUT2()
        {
            var basket = new List<Basket>()
            {
                new Basket(product: new Item(name: "Imported box of chocolates", price: 10, category: Category.Food, isImported: true), quantity: 1),
                new Basket(product: new Item(name: "Imported bottle of perfume", price: 47.50m, category: Category.Others, isImported: true), quantity: 1),
            };

            Assert.True(Logic.GetTotalBasket(basket) == 65.15m);
        }

        [Fact]
        public void OUTPUT3()
        {
            var basket = new List<Basket>()
            {
                new Basket(product: new Item(name: "Imported bottle of perfume", price: 27.99m, category: Category.Others, isImported: true), quantity: 1),
                new Basket(product: new Item(name: "Bottle of perfume", price: 18.99m, category: Category.Others), quantity: 1),
                new Basket(product: new Item(name: "Packet of headache pills", price: 9.75m, category: Category.MedicalProducts), quantity: 1),
                new Basket(product: new Item(name: "Imported box of chocolates", price: 11.25m, category: Category.Food, isImported: true), quantity: 1),
                new Basket(product: new Item(name: "Imported box of chocolates", price: 11.25m, category: Category.Food, isImported: true), quantity: 1),
            };
            var total = Logic.GetTotalBasket(basket);
            Assert.True(Logic.GetTotalBasket(basket) == 86.53m);
        }
    }
}
