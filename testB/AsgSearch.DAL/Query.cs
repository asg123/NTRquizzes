using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsgSearch.DAL
{
    [Table("queries")]
    public class Query
    {
        [Key]
        public int ID { get; set; }

        public virtual string QueryText { get; set; }

        public virtual DateTime? Time { get; set; }

        public virtual string title { get; set; }

        public virtual int creationDate { get; set; }

        public virtual int answerCount { get; set; }

        public virtual string displayName { get; set; }

        public virtual string profileImage { get; set; }

        public virtual string link { get; set; }

    }
}
