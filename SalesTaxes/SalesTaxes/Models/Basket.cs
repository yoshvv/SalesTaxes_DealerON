using SalesTaxes.Interfaces;

namespace SalesTaxes.Models
{
    /// <summary>
    /// Represents the quantity of the same product that is being sold
    /// </summary>
    public class Basket : IBasket
    {
        public Basket(Item product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Item Product {get; set;}

        public int Quantity { get; set; }
    }
}
