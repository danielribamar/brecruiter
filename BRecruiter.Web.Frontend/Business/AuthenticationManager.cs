using BRecruiter.Web.Frontend.Models;

namespace BRecruiter.Web.Frontend.Business
{
    public class AuthenticationManager
    {
        public static bool LoginUser(LoginModel model)
            => !(model.Username.Equals("bmota") && model.Username.Equals("xoninhas"));
        
    }
}
