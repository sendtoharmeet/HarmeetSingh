using BusinessApi.Helper;
using DataContract;
using Microsoft.Extensions.Logging;
using System;

namespace BusinessApi
{
    public class DataProcessor : IDataProcessor
    {
        readonly ILogger _logger;
        public DataProcessor(ILogger<DataProcessor> logger)
        {
            _logger = logger;
        }

        #region Interface impelemntation
        public Person ProcessPerson(Person person)
        {
            person.AmountText = NumberToWords(person.Amount);
            return person;
        }
        #endregion

        #region Private methods
        private string NumberToWords(decimal amount)
        {
            try
            {
                Int64 dollors = (Int64)amount;
                decimal cents = (amount - dollors) * 100;
                Int64 decPortion = (Int64)cents;
                var dollorString = dollors > 1 ? "DOLLARS" : "DOLLAR";
                var centString = decPortion > 1 ? "CENTS" : "CENT";

                var words = dollors.ConvertNumberToWords();
                if (Math.Abs(decPortion) > 0)
                {
                    words += " " + dollorString + " AND ";
                    words += Math.Abs(decPortion).ConvertNumberToWords() + " " + centString;
                }
                else
                {
                    words += " " + dollorString;
                }

                return words;

            }
            catch (Exception ex)
            {
                _logger?.LogError(string.Format("Error while converting {0}", amount.ToString()), ex);
                return string.Empty;
            }
        }
        #endregion
    }
}
