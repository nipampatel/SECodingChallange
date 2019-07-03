using SECodingChallenge.Web.Exceptions;
using SECodingChallenge.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace SECodingChallenge.Web.Helpers
{
    public static class CSVHelper
    {
        public static IList<string> ReadCSVFile(HttpPostedFileBase file)
        {
            // Check if posted file is image only
            file.CheckCSVValidity();
            IList<string> data = null;
            try
            {
                data = new List<string>();
                using (StreamReader sr = new StreamReader(file.InputStream, Encoding.GetEncoding("iso-8859-1")))
                {
                    string line = String.Empty;
                    while ((line = sr.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                throw new CSVValidationException("CSV file could not be read");
            }
            return data;
        }

        public static IList<VehicleDetail> ConvertToModel(IList<string> lines)
        {
            IList<VehicleDetail> vehicleDetails = new List<VehicleDetail>();
            foreach (string line in lines)
            {
                var vm = VehicleDetail.ConvertToModel(line);
                if (vm != null)
                {
                    vehicleDetails.Add(vm);
                }                
            }
            return vehicleDetails;
        }
    }
}