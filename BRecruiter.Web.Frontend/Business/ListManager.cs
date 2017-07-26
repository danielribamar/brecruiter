using BRecruiter.Web.Frontend.Data;

namespace BRecruiter.Web.Frontend.Business
{
    public class ListManager
    {
        private BRecruiterContext _context;
        public ListManager(BRecruiterContext context)
        {
            _context = context;
        }
    }
}
