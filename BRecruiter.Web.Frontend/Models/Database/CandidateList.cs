namespace BRecruiter.Web.Frontend.Models.Database
{
    public class CandidateList
    {
        public int ListId { get; set; }
        public int CandidateId { get; set; }

        public List List { get; set; }
        public Candidate Candidate { get; set; }
    }
}
