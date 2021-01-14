using SalesTaxes.Database;
using SalesTaxes.Helpers;
using SalesTaxes.Logic;
using SalesTaxes.Properties;
using System;

namespace SalesTaxes
{
    public class Store
    {
        static void Main(string[] args)
        {
            ItemsService.InitItems();

            //Class where we have all the logic to display the products
            var itemLogic = new ItemLogic();
            //Class where we have all the logic to buy products
            var storeLogic = new StoreLogic();

            var isBuying = true;

            //Being in a loopt until the sale is finished or the client leaves
            while (isBuying) 
            {
                //Displaying the menu
                WriteLineHelper.InfoAlert($"[1] {Resources.txt_listOfProducts} \n" +
                                          $"[2] {Resources.txt_addProduct} \n" +
                                          $"[3] {Resources.txt_editProduct} \n" +
                                          $"[4] {Resources.txt_purchase}");
                WriteLineHelper.WarningAlert($"[0] {Resources.txt_exit} \n");

                var option = Console.ReadLine();

                Console.Clear();

                //If the input is valid we check which option the user selected
                if (InputHelper.IsValidOption(option)) 
                {
                    switch (option) 
                    {
                        case "1":
                            itemLogic.ShowProductsByCategory();
                            WriteLineHelper.InfoAlert(Resources.txt_return);
                            Console.ReadLine();
                            break;
                        case "2":
                            storeLogic.StartAddingProducts();
                            break;
                        case "3":
                            storeLogic.StartEditingProducts();
                            break;
                        case "4":
                            storeLogic.StartBuyingProducts();
                            break;
                        case "0":
                            isBuying = false;
                            break;
                    }
                }
                Console.Clear();
            }

            WriteLineHelper.InfoAlert(Resources.txt_pressAKey);
            Console.ReadLine();
        }
    }
}
