﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AsgSearch.web.Controllers
{
    public class PastSearchesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return null;
        }

        public string Get(int id)
        {
            return null;
        }

        public void Post([FromBody]string value)
        {
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
        }
    }
}
