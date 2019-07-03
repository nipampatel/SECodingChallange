using SECodingChallenge.Web.Exceptions;
using System.Web;

namespace SECodingChallenge.Web.Helpers
{
    public static class HttpPostedFileBaseExtensions
    {
        public const int CSVMinimumBytes = 128;

        public static void CheckCSVValidity(this HttpPostedFileBase postedFile)
        {
            if (postedFile == null || postedFile.ContentLength <= 0)
            {
                throw new CSVValidationException("Invalid CSV file");
            }

            //  check mime types
            if (postedFile.ContentType.ToLower() != "application/vnd.ms-excel")
            {
                throw new CSVValidationException("Invalid CSV file");
            }

            if (postedFile.ContentLength > 2097152)
            {
                throw new CSVValidationException("CSV file should be less than 2MB");
            }

            //  attempt to read the file
            if (!postedFile.InputStream.CanRead)
            {
                throw new CSVValidationException("Can't read CSV file");
            }
        }
    }
}