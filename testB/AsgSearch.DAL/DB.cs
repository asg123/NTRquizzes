using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AsgSearch.DAL
{
    public class DB : DbContext
    {
        public DB() : base("ASGsearchDB")
        {
            Database.SetInitializer<DB>(null);
        }
        public DbSet<Query> Queries { get; set; }
    }
}
