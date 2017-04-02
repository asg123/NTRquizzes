using AsgSearch.DAL;
using AsgSearch.web.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AsgSearch.web.Controllers
{
    public class PastSearchesController : ApiController
    {
        IQueryService _svc;
        public PastSearchesController(IQueryService svc)
        {
            _svc = svc;
        }

        public IEnumerable<Query> Get()
        {
            return _svc.GetQueries();
        }

        public Query Get(int id)
        {
            return null;
        }

        public void Post([FromBody]Query value)
        {
            _svc.SaveQuery(value);
        }

        public void Put(int id, [FromBody]Query value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
