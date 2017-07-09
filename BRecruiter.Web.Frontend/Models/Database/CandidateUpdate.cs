using System;

namespace BRecruiter.Web.Frontend.Models.Database
{
    public class CandidateUpdate
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Observations { get; set; }
        public DateTime Createdate { get; set; }
    }
}
