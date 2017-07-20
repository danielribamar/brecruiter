using System;
using System.Collections.Generic;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class List
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}
