using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SECodingChallenge.Web.Models
{
    public class VehicleDetail
    {
        public int DealerNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public static VehicleDetail ConvertToModel(string line)
        {
            // https://stackoverflow.com/questions/18893390/splitting-on-comma-outside-quotes
            // with edge case tested
            var elements = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

            if (elements.Length != 6)
            {
                return null;
            }

            int dealerNumber;
            if (!int.TryParse(elements[0], out dealerNumber))
            {
                return null;
            }

            double price;
            if (!double.TryParse(elements[4].Replace("\"", ""), out price))
            {
                return null;
            }

            DateTime date;
            if (!DateTime.TryParse(elements[5], out date))
            {
                return null;
            }
            return new VehicleDetail() { DealerNumber = dealerNumber, CustomerName = elements[1], DealershipName = elements[2], Vehicle = elements[3], Price = price, Date = date };
        }
    }
}