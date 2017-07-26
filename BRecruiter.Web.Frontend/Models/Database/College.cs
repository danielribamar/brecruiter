using System.Collections.Generic;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class College
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
    }
}
