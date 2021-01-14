using SalesTaxes.Helpers;
using System;

namespace SalesTaxes
{
    public class Store
    {
        static void Main(string[] args)
        {
            var isBuying = true;

            //Being in a loopt until the sale is finished or the client leaves
            while (isBuying) 
            {
                //Displaying the menu
                WriteLineHelper.InfoAlert("[1] List of products \n" +
                                          "[2] Purchase");
                WriteLineHelper.WarningAlert("[0] Exit \n");

                var option = Console.ReadLine();

                //If the input is valid we check which option the user selected
                if (InputHelper.IsValidMenuInput(option)) 
                {
                    switch (option) 
                    {
                        case "1":
                            Console.Clear();
                            break;
                        case "2":
                            Console.Clear();
                            break;
                        case "0":
                            isBuying = false;
                            break;
                    }
                }
                Console.Clear();
            }

            WriteLineHelper.InfoAlert("Press a key to exit...");
            Console.ReadLine();
        }
    }
}
