using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using System.Collections.Generic;

namespace SalesTaxes.Database
{
    /// <summary>
    /// Stores all the items to sell in the store
    /// </summary>
    public class ItemsService
    {
        public ItemsService() 
        {
            InitItems();
        }

        public List<Item> StoreItems { get; set; }

        public void InitItems() 
        {
            StoreItems = new List<Item>() 
            {
                new Item(name: "Book", price: 12.49m, category: Category.Books),
                new Item(name: "Music CD", price: 14.99m, category: Category.Others),
                new Item(name: "Chocolate bar", price: 0.85m, category: Category.Food),
                new Item(name: "Imported box of chocolates", price: 10, category: Category.Food, isImported: true),
                new Item(name: "Imported bottle of perfume", price: 47, category: Category.Others, isImported: true),
                new Item(name: "Packet of headache pills", price: 9.75m, category: Category.MedicalProducts),
            };
        }

        public IReadOnlyList<Item> GetItems() 
        {
            return this.StoreItems;
        }
    }
}
