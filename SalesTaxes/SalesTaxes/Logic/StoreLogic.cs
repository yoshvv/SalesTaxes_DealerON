using SalesTaxes.Database;
using SalesTaxes.Helpers;
using SalesTaxes.Interfaces;
using SalesTaxes.Models;
using SalesTaxes.Properties;
using System;
using System.Collections.Generic;

namespace SalesTaxes.Logic
{
    public class StoreLogic
    {
        public StoreLogic() 
        {
            ItemLogic = new ItemLogic();
            BasketLogic = new BasketLogic();
        }

        readonly ItemLogic ItemLogic;

        readonly BasketLogic BasketLogic;

        private List<Basket> Basket { get; set; }

        /// <summary>
        /// Sub menu to buy products
        /// </summary>
        public void StartAddingProducts()
        {
            var isAdding = true;

            //Values for new product
            var name = "";
            var price = 0m;
            var category = Category.Books;
            var isImported = false;

            while (isAdding)
            {
                WriteLineHelper.SuccessAlert(Resources.separator);
                WriteLineHelper.InfoAlert(Resources.txt_addNewProduct);
                WriteLineHelper.SuccessAlert(Resources.separator);
                WriteLineHelper.SuccessAlert("");

                //Step 1
                name = AskForName();
                //Step 2
                price = AskForPrice();
                //Step 3
                category = AskForCategory();
                //Step 4
                isImported = AskForImport();

                isAdding = false;
            }

            var newProduct = new Item(name: name, price: price, category: category, isImported: isImported);
            ItemsService.AddNewItem(newProduct);
            WriteLineHelper.SuccessAlert($"{newProduct.Name} added to the store");
            WriteLineHelper.SuccessAlert("");
        }

        /// <summary>
        /// Creates a loop for asking the name of the product
        /// </summary>
        /// <returns></returns>
        public string AskForName() 
        {
            bool isAskingForName = true;
            var name = "";
            while (isAskingForName)
            {
                WriteLineHelper.WarningAlert(string.Format(Resources.txt_steps, 1, 4));
                WriteLineHelper.WarningAlert($"{Resources.txt_name}: ");
                name = Console.ReadLine();

                isAskingForName = string.IsNullOrEmpty(name);
                if (!isAskingForName) 
                {
                    WriteLineHelper.DangerAlert(Resources.txt_validation_name);
                }

            }
            Console.Clear();
            return name;
        }

        /// <summary>
        /// Creates a loop for asking the price of the product
        /// </summary>
        /// <returns></returns>
        public decimal AskForPrice()
        {
            bool isAskingForPrice = true;
            var input = "";
            var price = 0m;
            while (isAskingForPrice)
            {
                WriteLineHelper.WarningAlert(string.Format(Resources.txt_steps, 2, 4));
                WriteLineHelper.WarningAlert($"{Resources.txt_price}: ");
                input = Console.ReadLine();

                var isValidInput = InputHelper.IsValidDecimalInput(input);

                if (isValidInput)
                {
                    price = decimal.Parse(input);
                    isAskingForPrice = false;
                }

            }
            Console.Clear();
            return price;
        }

        /// <summary>
        /// Creates a loop for asking the category of the product
        /// </summary>
        /// <returns></returns>
        public Category AskForCategory()
        {
            bool isAskingForCategory = true;
            var input = "";
            var category = Category.Books;
            while (isAskingForCategory)
            {
                WriteLineHelper.WarningAlert(string.Format(Resources.txt_steps, 3, 4));
                WriteLineHelper.WarningAlert($"{Resources.txt_category}: ");
                WriteLineHelper.WarningAlert($"[0] Books ");
                WriteLineHelper.WarningAlert($"[1] Food ");
                WriteLineHelper.WarningAlert($"[2] MedicalProducts ");
                WriteLineHelper.WarningAlert($"[3] Others ");
                WriteLineHelper.WarningAlert("");

                input = Console.ReadLine();

                var isValidInput = InputHelper.IsValidOption(input);

                if (isValidInput)
                {
                    category = (Category)int.Parse(input);
                    isAskingForCategory = false;
                }

            }
            Console.Clear();
            return category;
        }

        /// <summary>
        /// Creates a loop for asking if  the product is imported or not
        /// </summary>
        /// <returns></returns>
        public bool AskForImport()
        {
            bool isAskingForImport = true;
            var input = "";
            var isImport = false;
            while (isAskingForImport)
            {
                WriteLineHelper.WarningAlert(string.Format(Resources.txt_steps, 4, 4));
                WriteLineHelper.WarningAlert($"{Resources.txt_import}: ");
                WriteLineHelper.WarningAlert("[1] Yes");
                WriteLineHelper.WarningAlert("[2] No");
                input = Console.ReadLine();

                switch (input) 
                {
                    case "1":
                        isImport = true;
                        isAskingForImport = false;
                        break;
                    case "2":
                        isImport = false;
                        isAskingForImport = false;
                        break;
                }

            }
            Console.Clear();
            return isImport;
        }


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

        /// <summary>
        /// Asks the user if wants to return to the main menu
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Adds or update the quantity of a product in the basket
        /// </summary>
        /// <param name="selectedOption"></param>
        public void AddProduct(string selectedOption) 
        {
            if (!InputHelper.IsValidOption(selectedOption)) return;

            var index = int.Parse(selectedOption);

            var selectedProduct = ItemsService.GetItems()[index - 1];
            //Add or update product in the basket
            BasketLogic.AddProductToBasket(Basket, selectedProduct);
            WriteLineHelper.WarningAlert(string.Format(Resources.txt_addedInBasket, selectedProduct.Name));
            WriteLineHelper.WarningAlert("");
        }
    }
}
