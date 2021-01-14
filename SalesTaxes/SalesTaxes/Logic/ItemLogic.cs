using SalesTaxes.Database;
using SalesTaxes.Helpers;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using SalesTaxes.Properties;
using System;
using System.Linq;

namespace SalesTaxes.Logic
{
    public class ItemLogic
    {
        public ItemLogic()
        {
        }

        /// <summary>
        /// Show the list of products stored and the index to be selected when buying
        /// </summary>
        public void ShowProductsToBuy()
        {
            //List of products
            var products = ItemsService.GetItems();

            WriteLineHelper.SuccessAlert(Resources.separator);
            WriteLineHelper.SuccessAlert($"{Resources.txt_pickProducts} [X] Return, [Y] See total");
            WriteLineHelper.SuccessAlert(Resources.separator);

            //Showing the products ordered by category
            var index = 1;
            foreach (var product in products)
            {
                WriteLineHelper.InfoAlert(GetProductBasicDescription(product, index));
                index++;
            }
            WriteLineHelper.SuccessAlert("");
        }

        /// <summary>
        /// Show all the products ordered by category
        /// </summary>
        public void ShowProductsByCategory() 
        {
            //List of products
            var products = ItemsService.GetItems();

            //Products by category
            var productsByCategory = products
                .GroupBy(x => x.Category)
                .ToList();

            //Showing the products ordered by category
            foreach(var category in productsByCategory)
            {
                WriteLineHelper.SuccessAlert(Resources.separator);
                WriteLineHelper.SuccessAlert(Enum.GetName(typeof(Category), category.Key));
                WriteLineHelper.SuccessAlert(Resources.separator);
                foreach (var product in category) 
                {
                    WriteLineHelper.InfoAlert(GetProductFriendlyDescription(product));
                }
                WriteLineHelper.SuccessAlert("");
            }
        }

        /// <summary>
        /// Show the index, name and price of a product
        /// </summary>
        /// <param name="product"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetProductBasicDescription(Item product, int index)
        {
            var name = product.Name;
            //Numeric values with format
            var price = string.Format("{0:C2}", product.Price);
           
            return string.Format($"[{index}] {product.Name} {Resources.txt_at} {price}");
        }

        /// <summary>
        /// Show the detail of a product in console
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public string GetProductFriendlyDescription(Item product) 
        {
            var name = product.Name;
            //Numeric values with format
            var price = string.Format("{0:C2}", product.Price);
            var basicTaxValue = product.BasicTax > 0 ? string.Format("{0:C2}", product.BasicTax) : "";
            var importTaxValue = product.ImportTax > 0 ? string.Format("{0:C2}", product.ImportTax) : "";
            //Text values
            var basicTax = string.IsNullOrEmpty(basicTaxValue) ? "" : $" [{Resources.txt_basicTax}] => {basicTaxValue}";
            var importTax = string.IsNullOrEmpty(importTaxValue) ? "" : $" [{Resources.txt_importTax}] => {importTaxValue}";

            return string.Format($"{product.Name} {Resources.txt_at} {price}{basicTax}{importTax}");
        }
    }
}
