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
using AsgSearch.DAL;
using System.Linq;

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
            ViewBag.items = Session["items"];
            ViewBag.SearchTerm = Session["SearchTerm"];

            if(ViewBag.items != null && ViewBag.SearchTerm != null)
            {
                var newQuery = new Query();
                newQuery.title = ViewBag.items[0].title;
                newQuery.creationDate = ViewBag.items[0].creation_date;
                newQuery.answerCount = ViewBag.items[0].answer_count;
                newQuery.displayName = ViewBag.items[0].owner.display_name;
                newQuery.profileImage = ViewBag.items[0].owner.profile_image;
                newQuery.link = ViewBag.items[0].link;
                newQuery.QueryText = ViewBag.SearchTerm;
                newQuery.Time = DateTime.Now;
                
                //TODO: Implement Container
                IQueryService query = new QueryService(new DALContext());
                //TODO: Check Null Insert
                query.SaveQuery(newQuery);
            }
            
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
            IQueryService query = new QueryService(new DALContext());
            var result = query.GetQueries();

            var topFiveResult = result.Where(n => n.Time != null)
                                .OrderByDescending(n => n.Time)
                                .Take(5);

            ViewBag.TopFiveQuery = topFiveResult;

            return View();
        }

        public async Task<ActionResult> Search(string searchTerm)
        {
            //TODO: Add Summary,comments, log and handle service call in other layers to improve test ability.
            var response = String.Empty;
            RootObject ro = null;
            Session["SearchTerm"] = searchTerm;
            try
            {
                var apiUrl = "http://api.stackexchange.com/2.2/search/advanced?pagesize=40&q={0}&accepted=True&site=stackoverflow";
                apiUrl = String.Format(apiUrl, searchTerm);

                HttpClientHandler handler = new HttpClientHandler();
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (var httpClient = new HttpClient(handler))
                {
                    httpClient.BaseAddress = new Uri(apiUrl);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await httpClient.GetStringAsync(apiUrl);

                    JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                    ro = json_serializer.Deserialize<RootObject>(response);

                    Session["items"] = ro.items;

                }
            }
            catch (Exception e)
            {
                //TODO: Handle error
            }

            //TODO: Return better response
            return View("Step1");
        }
    }
}
