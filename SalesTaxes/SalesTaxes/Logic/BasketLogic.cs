using SalesTaxes.Helpers;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using SalesTaxes.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Logic
{
    public class BasketLogic
    {
        public void ShowTotalInBasket(List<Basket> basket)
        {
            Console.Clear();
            if (basket.Count() == 0)
            {
                WriteLineHelper.SuccessAlert($"No products in basket");
                WriteLineHelper.SuccessAlert($"");
                return;
            }
            WriteLineHelper.SuccessAlert(Resources.separator);
            var salesTaxes = 0m;
            var total = 0m;
            foreach (var product in basket) 
            {
                var totalProd = 0m;
                var salesTaxesProd = 0m;
                var importTaxesProd = 0m;

                for (int i = 0; i < product.Quantity; i++)
                {
                    totalProd += GetTotal(product.Product, 1);
                    salesTaxesProd += GetBasicTax(product.Product, 1);
                    importTaxesProd += GetImportedTax(product.Product, 1);
                    salesTaxes += salesTaxesProd + importTaxesProd;
                }
                
                var quantityDetail = product.Quantity > 1 ? $"({product.Quantity} @ {GetTotal(product.Product, 1)})" :  "";

                WriteLineHelper.InfoAlert($"{product.Product.Name}: {totalProd} {quantityDetail}");
                total += totalProd;
            }
            WriteLineHelper.InfoAlert($"Sales Taxes: {salesTaxes}");
            WriteLineHelper.InfoAlert($"Total: {total}");
            WriteLineHelper.SuccessAlert(Resources.separator);
            WriteLineHelper.SuccessAlert("");
        }

        public void AddProductToBasket(List<Basket> basket, Item product)
        {
            var productInBasket = basket
                .Select((x,i) => new 
                {
                    Index = i,
                    Item = x
                })
                .Where(x => x.Item.Product.Guid == product.Guid);

            var isAlreadyInBasket = productInBasket.Any();

            //if the product is in the basket we get the index and update the quantity
            //if not just add the new item with 1 qty
            if (isAlreadyInBasket) 
            {
                var index = productInBasket
                            .Select(x => x.Index)
                            .FirstOrDefault();

                basket[index].Quantity = basket[index].Quantity + 1;
            }
            else 
            {
                basket.Add(new Basket(product, 1));
            }
        }

        public decimal GetSubTotal(IHaveTaxes item, int quantity)
        {
            return (item.Price * quantity);
        }

        public decimal GetTotal(IHaveTaxes item, int quantity)
        {
            return GetSubTotal(item, quantity) + GetBasicTax(item, quantity) + GetImportedTax(item, quantity);
        }

        public decimal GetBasicTax(IHaveTaxes item, int quantity) 
        {
            var rawTax = (item.Price * quantity) * item.BasicTax;
            var roundTax = RoundAfterFive(rawTax);
            return roundTax;
        }

        public decimal GetImportedTax(IHaveTaxes item, int quantity)
        {
            var rawTax = (item.Price * quantity) * item.ImportTax;
            var roundTax = RoundAfterFive(rawTax);
            return roundTax;
        }

        private decimal RoundAfterFive(decimal val) 
        {
            return Math.Ceiling(val / .05m) * .05m;
        }

        public decimal GetAllSalesTaxes(IReadOnlyList<IBasket> basket) 
        {
            return basket
                .Select(x => GetBasicTax(x.Product, x.Quantity))
                .DefaultIfEmpty(0).
                Sum(x => x);
        }

        public decimal GetTotalBasket(IReadOnlyList<IBasket> basket)
        {
            return basket
                .Select(x => GetTotal(x.Product, x.Quantity))
                .DefaultIfEmpty(0).
                Sum(x => x);
        }
    }
}
