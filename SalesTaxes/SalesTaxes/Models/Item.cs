using SalesTaxes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Models
{
    public class Item : IHaveTaxes, IHaveCategory
    {
        public Item(string name, decimal price, Category category, bool isImported = false)
        {
            Name = name;
            Price = price;
            Category = category;
            ImportTax = isImported ? 0.05m: 0;
            IsImported = isImported;

            //Initialize the basic tax value depending in the category
            switch (category) 
            {
                case Category.Others:
                    BasicTax = 0.10m;
                    break;
                default:
                    BasicTax = 0;
                    break;
            }
        }

        public string Guid { get; set; } = System.Guid.NewGuid().ToString();

        public string Name { get; set; }

        public decimal Price { get ; set ; }

        public decimal BasicTax { get; set; }

        public decimal ImportTax { get ; set ; }

        public bool IsImported { get ; set ; }

        public Category Category { get; set; }
    }
}
