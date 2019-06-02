using System;
using System.Collections.Generic;
using ResourcesLibrary;

namespace BusinessApi.Helper
{
    public static class Converter
    {
        readonly static string[] _singleWords;
        readonly static string[] _tenWords;
        readonly static Dictionary<string, string> constantValues;

        static Converter()
        {
            _singleWords = new[] { Common.ZERO, Common.ONE, Common.TWO, Common.THREE, Common.FOUR,
            Common.FIVE, Common.SIX, Common.SEVEN, Common.EIGHT, Common.NINE, Common.TEN, Common.ELEVEN, Common.TWELVE, Common.THIRTEEN, Common.FOURTEEN,
            Common.FIFTEEN, Common.SIXTEEN, Common.SEVENTEEN, Common.EIGHTEEN, Common.NINETEEN };

            _tenWords = new[] { Common.ZERO, Common.TEN, Common.TWENTY, Common.THIRTY, Common.FORTY,
            Common.FIFTY, Common.SIXTY, Common.SEVENTY, Common.EIGHTY, Common.NINETY };

            constantValues = new Dictionary<string, string>();
            constantValues.Add("MINUS", "MINUS ");
            constantValues.Add("QUADRILLION", " " + Common.QUADRILLION + " ");
            constantValues.Add("TRILLION", " " + Common.TRILLION + " ");
            constantValues.Add("BILLION", " " + Common.BILLION + " ");
            constantValues.Add("MILLION", " " + Common.MILLION + " ");
            constantValues.Add("THOUSAND", " " + Common.THOUSAND + " ");
            constantValues.Add("HUNDRED", " " + Common.HUNDRED + " ");
            constantValues.Add("AND", Common.AND + " ");
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
