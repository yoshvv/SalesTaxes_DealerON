using System.Text.RegularExpressions;

namespace SalesTaxes.Helpers
{
    public static class InputHelper
    {
        /// <summary>
        /// True if the input is a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidOption(string input) 
        {
            return new Regex("[0-9]").IsMatch(input);
        }

        /// <summary>
        /// True if the input is a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidDecimalInput(string input)
        {
            var isValid = false;

            try
            {
                decimal.Parse(input);
                isValid = true;
            }
            catch (System.Exception e)
            {
            }
            return isValid;
        }
    }
}
