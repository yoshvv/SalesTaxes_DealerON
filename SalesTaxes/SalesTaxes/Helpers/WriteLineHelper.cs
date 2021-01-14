using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Helpers
{
    public static class WriteLineHelper
    {
        /// <summary>
        /// Green success message
        /// </summary>
        /// <param name="message"></param>
        public static void SuccessAlert(string message)
        {
            Alert(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Danger message
        /// </summary>
        /// <param name="message"></param>
        public static void DangerAlert(string message)
        {
            Alert(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Yellow warning message
        /// </summary>
        /// <param name="message"></param>
        public static void WarningAlert(string message)
        {
            Alert(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Default message
        /// </summary>
        /// <param name="message"></param>
        public static void InfoAlert(string message)
        {
            Alert(message, ConsoleColor.Gray);
        }

        /// <summary>
        /// Emite un mensaje de alerta con el color que esté en los parámetros.
        /// </summary>
        /// <param name="message"></param>
        private static void Alert(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
