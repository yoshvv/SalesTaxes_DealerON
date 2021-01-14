﻿using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System.Collections.Generic;

namespace SalesTaxes.Database
{
    /// <summary>
    /// Stores all the items to sell in the store
    /// </summary>
    public static class ItemsService
    {
        private static List<Item> StoreItems { get; set; }

        /// <summary>
        /// Current products stored in the app
        /// </summary>
        public static void InitItems() 
        {
            StoreItems = new List<Item>() 
            {
                new Item(name: "Book", price: 12.49m, category: Category.Books),
                new Item(name: "Music CD", price: 14.99m, category: Category.Others),
                new Item(name: "Chocolate bar", price: 0.85m, category: Category.Food),
                new Item(name: "Bottle of perfume", price: 18.99m, category: Category.Others),
                new Item(name: "Imported box of chocolates", price: 10.00m, category: Category.Food, isImported: true),
                new Item(name: "Imported bottle of perfume", price: 47.50m, category: Category.Others, isImported: true),
                new Item(name: "Packet of headache pills", price: 9.75m, category: Category.MedicalProducts),
            };
        }

        public static void AddNewItem(Item item)
        {
            StoreItems.Add(item);
        }

        public static List<Item> GetItems() 
        {
            return StoreItems;
        }
    }
}
