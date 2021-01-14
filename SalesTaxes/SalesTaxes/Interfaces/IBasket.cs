using SalesTaxes.Models;

namespace SalesTaxes.Interfaces
{
    public interface IBasket
    {
        Item Product { get; set; }

        int Quantity { get; set; }
    }
}
