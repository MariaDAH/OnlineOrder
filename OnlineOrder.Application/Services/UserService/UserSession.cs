namespace OnlineOrder.Application.Services.UserService
{
    public class UserSession: IUserSession
    {
    
        public static readonly String LOCALE_SESSION_ATTRIBUTE = "locale";

        public static readonly String USER_SESSION_ATTRIBUTE = "userSession";

        private static IUserService userService;

        public IUserService UserService
        {
            set { userService = value; }
        }
        
        //RegisterUser
        
        //Login
        
        //Get login details
    
    }
}
