using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using AsgSearch.web.Classes;

namespace AsgSearch.web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            return View();
        }
        public ActionResult Step1()
        {
            ViewBag.Title = "Step 1";

            return View();
        }
        public ActionResult Step2()
        {
            ViewBag.Title = "Step 2";

            return View();
        }
        public ActionResult Step3()
        {
            ViewBag.Title = "Step 3";

            return View();
        }

        public async Task<ActionResult> Search(string searchTerm)
        {
            //TODO: Add Summary,comments, log and handle service call in other layers to improve test ability.
            var response = String.Empty;
            RootObject ro = null;
            try
            {
                var apiUrl = "http://api.stackexchange.com/2.2/search/advanced?pagesize=40&q={0}&accepted=True&body={1}&tagged={2}&site=stackoverflow";
                apiUrl = String.Format(apiUrl, searchTerm, searchTerm, searchTerm);

                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.BaseAddress = new Uri(apiUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await httpClient.GetStringAsync(apiUrl);

                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    ro = json_serializer.Deserialize<RootObject>(response);
                    ViewBag.items = ro.items;
                }
            }catch(Exception e)
            {
                //TODO: Handle error
                return Content("Failure");
            }
            
            //TODO: Return better response
            return PartialView("Step1", ro.items);
        }
    }
}
