using System;
using System.Collections.Generic;

namespace BusinessApi.Helper
{
    public static class Converter
    {
        readonly static string[] _singleWords;
        readonly static string[] _tenWords;
        readonly static Dictionary<string, string> constantValues;

        static Converter()
        {
            _singleWords = new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR",
            "FIVE", "SIX", "SEVEN", "EIGHT", "NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN",
            "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };

            _tenWords = new[] { "ZERO", "TEN", "TWENTY", "THIRTY", "FORTY",
            "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };

            constantValues = new Dictionary<string, string>();
            constantValues.Add("MINUS", "MINUS ");
            constantValues.Add("QUADRILLION", " QUADRILLION ");
            constantValues.Add("TRILLION", " TRILLION ");
            constantValues.Add("BILLION", " BILLION ");
            constantValues.Add("MILLION", " MILLION ");
            constantValues.Add("THOUSAND", " THOUSAND ");
            constantValues.Add("HUNDRED", " HUNDRED ");
            constantValues.Add("AND", "AND ");
        }

        public static string ConvertNumberToWords(this Int64 inputNumber)
        {
            if (inputNumber == 0) return _singleWords[0];

            if (inputNumber < 0) return constantValues["MINUS"] + ConvertNumberToWords(Math.Abs(inputNumber));

            string outputWord = "";

            if ((inputNumber / 1000000000000000) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 1000000000000000) + constantValues["QUADRILLION"];
                inputNumber %= 1000000000000000;
            }

            if ((inputNumber / 1000000000000) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 1000000000000) + constantValues["TRILLION"];
                inputNumber %= 1000000000000;
            }

            if ((inputNumber / 1000000000) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 1000000000) + constantValues["BILLION"];
                inputNumber %= 1000000000;
            }

            if ((inputNumber / 1000000) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 1000000) + constantValues["MILLION"];
                inputNumber %= 1000000;
            }

            if ((inputNumber / 1000) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 1000) + constantValues["THOUSAND"];
                inputNumber %= 1000;
            }

            if ((inputNumber / 100) > 0)
            {
                outputWord += ConvertNumberToWords(inputNumber / 100) + constantValues["HUNDRED"];
                inputNumber %= 100;
            }

            if (inputNumber > 0)
            {
                if (outputWord != "")
                    outputWord += constantValues["AND"];

                if (inputNumber < 20)
                    outputWord += _singleWords[inputNumber];
                else
                {
                    outputWord += _tenWords[inputNumber / 10];
                    if ((inputNumber % 10) > 0)
                        outputWord += "-" + _singleWords[inputNumber % 10];
                }
            }

            return outputWord;
        }
    }
}
