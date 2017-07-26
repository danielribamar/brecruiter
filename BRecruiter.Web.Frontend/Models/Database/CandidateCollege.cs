namespace BRecruiter.Web.Frontend.Models.Database
{
    public class CandidateCollege
    {
        public int CandidateId { get; set; }
        public int Collegeid { get; set; }

        public Candidate Candidate { get; set; }
        public College College { get; set; }
    }
}
