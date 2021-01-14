using SalesTaxes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesTaxes.Logic
{
    public class BasketLogic
    {
        public decimal GetTotal(IHaveTaxes item, int quantity)
        {
            return (item.Price * quantity) + GetBasicTax(item, quantity) + GetImportedTax(item, quantity);
        }

        public decimal GetBasicTax(IHaveTaxes item, int quantity) 
        {
            return Math.Round(item.Price * item.BasicTax * quantity, 2);
        }

        public decimal GetImportedTax(IHaveTaxes item, int quantity)
        {
            return Math.Round(item.Price * item.ImportTax * quantity, 2);
        }

        public decimal GetAllSalesTaxes(IReadOnlyList<IBasket> basket) 
        {
            return basket
                .Select(x => GetBasicTax(x.Product, x.Quantity))
                .DefaultIfEmpty(0).
                Sum(x => x);
        }
    }
}
