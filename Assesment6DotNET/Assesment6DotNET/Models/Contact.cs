namespace Assesment6DotNET.Models
{
    public class Contact
    {
        int id { get; set; }
        DateTime date { get; set; }
        bool isAction { get; set; }
        Type type { get; set; }
        string details { get; set; }
        Oportunity oportunity { get; set; }

        public string GetDetails()
        {
            return this.details;
        }
    }
}
