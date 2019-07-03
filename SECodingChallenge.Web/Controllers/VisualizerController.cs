using SECodingChallenge.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SECodingChallenge.Web.Controllers
{
    public class VisualizerController : Controller
    {
        [HttpGet]        
        public async Task<ActionResult> Index()
        {
            try
            {                
                return View("Index");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;                
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<ActionResult> ViewSalesData()
        {
            try
            {
                HttpPostedFileBase salesDataFile = Request.Files.Count > 0 ? Request.Files[0] : null;
                IList<string> csvData = CSVHelper.ReadCSVFile(salesDataFile);

                if (csvData == null)
                {
                    ViewBag.Errors = new[] { "Unable to read CSV file." };
                }
                var vehicleDetails = CSVHelper.ConvertToModel(csvData);
                return View("Results", vehicleDetails);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return View("Error");
            }
        }
    }
}