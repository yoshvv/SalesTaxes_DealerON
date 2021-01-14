using SalesTaxes.Database;
using SalesTaxes.Helpers;
using SalesTaxes.Models;
using SalesTaxes.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Logic
{
    public class StoreLogic
    {
        public StoreLogic() 
        {
            ItemLogic = new ItemLogic();
            BasketLogic = new BasketLogic();
            ItemService = new ItemsService();
        }

        readonly ItemLogic ItemLogic;

        readonly ItemsService ItemService;

        readonly BasketLogic BasketLogic;

        private List<Basket> Basket { get; set; }

        /// <summary>
        /// Sub menu to buy products
        /// </summary>
        public void StartBuyingProducts() 
        {
            var isBuying = true;
            Basket = new List<Basket>();
            while (isBuying) 
            {
                ItemLogic.ShowProductsToBuy();
                var option = Console.ReadLine();

                switch (option.ToLower()) 
                {
                    case "x":
                        isBuying = !ReturnToMainMenu();
                        break;
                    case "y":
                        BasketLogic.ShowTotalInBasket(Basket);
                        break;
                    default:
                        AddProduct(option);
                        break;
                }
            }
        }

        public bool ReturnToMainMenu() 
        {
            Console.Clear();
            var askToBack = true;
            var returnToMain = false;
            while (askToBack) 
            {
                WriteLineHelper.DangerAlert(Resources.txt_backToMainMenu);
                WriteLineHelper.DangerAlert("[1] Yes");
                WriteLineHelper.DangerAlert("[0] No");
                var option = Console.ReadLine();

                switch (option) 
                {
                    case "1":
                        returnToMain = true;
                        askToBack = false;
                        break;
                    case "0":
                        returnToMain = false;
                        askToBack = false;
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
            return returnToMain;
        }

        public void SeeTotal() 
        {

        }

        public void AddProduct(string selectedOption) 
        {
            if (!InputHelper.IsValidOption(selectedOption)) return;

            var index = int.Parse(selectedOption);

            var selectedProduct = ItemService.GetItems()[index - 1];
            //Add or update product in the basket
            BasketLogic.AddProductToBasket(Basket, selectedProduct);
            WriteLineHelper.WarningAlert(string.Format(Resources.txt_addedInBasket, selectedProduct.Name));
            WriteLineHelper.WarningAlert("");
        }
    }
}
