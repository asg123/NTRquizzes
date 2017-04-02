using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AsgSearch.DAL;

namespace AsgSearch.web.Classes
{
    public class QueryService : IQueryService, IDisposable
    {
        private IDALContext context;

        public QueryService(IDALContext dal)
        {
            context = dal;
        }

        public List<Query> GetQueries()
        {
            return context.Queries.All().ToList();
        }

        // HINT: For step 2 you'll need to add a new parameter so you can set a value for the
        // QueryResults collection in Query
        public Query SaveQuery(Query query)
        {
            context.Queries.Create(query);
            context.SaveChanges();
            return query;
        }

        public void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
}