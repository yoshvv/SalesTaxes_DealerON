namespace SalesTaxes.Models
{
    /// <summary>
    /// Represents the quantity of the same product that is being sold
    /// </summary>
    public class Basket
    {
        public Item Product {get; set;}

        public decimal Quantity { get; set; }
    }
}
