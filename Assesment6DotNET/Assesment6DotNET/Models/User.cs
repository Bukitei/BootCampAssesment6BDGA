namespace Assesment6DotNET.Models
{
    public class User
    {
        string username;
        string password;
        string token;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
