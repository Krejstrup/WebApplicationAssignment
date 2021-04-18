using System;

namespace WebApplicationAssignment.Models
{
    public class TempCheck
    {

        /// <summary>
        /// CheckTemp uses a float value to check if the temperature is in the range of fewer or not.
        /// </summary>
        /// <param name="floatTemp">The body temperature that should be tested.</param>
        /// <returns>Returns string-text for the reslts of the testing.</returns>
        public static string CheckTemp(float floatTemp)
        {
            string resultString;


            if (floatTemp > 37.5)
            {
                resultString = "fever";
            }
            else if (floatTemp < 35.5)
            {
                resultString = "hyperdermia";
            }
            else
            {
                resultString = "no fever";
            }

            return resultString;
        }


        /// <summary>
        /// CheckTemp uses a float value to check if the temperature is in the range of fewer or not.
        /// </summary>
        /// <param name="stringTemp">Takes a string with decimal as either "." or "," as a input body temperature.</param>
        /// <returns>Returns string-text for the reslts of the testing.</returns>
        public static string CheckTemp(string stringTemp)
        {
            string resultString;
            float floatTemp;

            if (stringTemp.Contains("."))
            {
                stringTemp = stringTemp.Replace(".", ",");
            }

            if (Single.TryParse(stringTemp, out floatTemp))
            {
                if (floatTemp > 37.5)
                {
                    resultString = "fever";
                }
                else if (floatTemp < 35.5)
                {
                    resultString = "hyperdermia";
                }
                else
                {
                    resultString = "no fever";
                }

            }
            else
            {
                resultString = "Not a value";
            }
            return resultString;
        }


    }
}
