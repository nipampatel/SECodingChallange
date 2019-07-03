using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SECodingChallenge.Web.Exceptions
{
    public class CSVValidationException : Exception
    {
        public CSVValidationException(string message)
       : base(message)
        {
        }
    }
}