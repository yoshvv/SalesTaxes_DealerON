namespace SalesTaxes.Interfaces
{
    public interface IHaveTaxes
    {
        decimal Price { get; set; }

        decimal BasicTax { get; set; }

        /// <summary>
        /// 5% tax for imported items
        /// </summary>
        decimal ImportTax { get; set; }

        bool IsImported { get; set; }
    }
}
