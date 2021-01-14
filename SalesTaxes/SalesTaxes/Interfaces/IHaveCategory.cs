using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Interfaces
{
    public enum Category 
    {
        Books,
        Food,
        MedicalProducts,
        Others
    }

    /// <summary>
    /// Category where the item belongs.
    /// </summary>
    /// <remarks>
    /// This defines if the item will have basic sales tax or not
    /// </remarks>
    public interface IHaveCategory
    {
        Category Category { get; set; }
    }
}
