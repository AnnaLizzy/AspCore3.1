namespace WebApp.ViewModels.System.Users
{
    public class LoginRequest
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}
