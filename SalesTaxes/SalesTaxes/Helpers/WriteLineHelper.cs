using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxes.Helpers
{
    /// <summary>
    /// Simple class to format the write line in console
    /// </summary>
    public static class WriteLineHelper
    {
        public static string Separator() => "-------------------------------------------------";

        /// <summary>
        /// Green success message
        /// </summary>
        /// <param name="message"></param>
        public static void SuccessAlert(string message, bool isWriteLine = true)
        {
            Alert(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Danger message
        /// </summary>
        /// <param name="message"></param>
        public static void DangerAlert(string message, bool isWriteLine = true)
        {
            Alert(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Yellow warning message
        /// </summary>
        /// <param name="message"></param>
        public static void WarningAlert(string message, bool isWriteLine = true)
        {
            Alert(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Default message
        /// </summary>
        /// <param name="message"></param>
        public static void InfoAlert(string message, bool isWriteLine = true)
        {
            Alert(message, ConsoleColor.Gray);
        }

        /// <summary>
        /// Emite un mensaje de alerta con el color que esté en los parámetros.
        /// </summary>
        /// <param name="message"></param>
        private static void Alert(string message, ConsoleColor color, bool isWriteLine = true)
        {
            Console.ForegroundColor = color;
            if(isWriteLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
