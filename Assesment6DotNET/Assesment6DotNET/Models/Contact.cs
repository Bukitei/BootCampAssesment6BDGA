namespace Assesment6DotNET.Models
{
    public class Contact
    {
        int id { get; set; }
        public DateTime date { get; set; }
        public bool isAction { get; set; }
        public Type type { get; set; }
        public string details { get; set; }
        public Oportunity oportunity { get; set; }

        public string GetDetails()
        {
            return this.details;
        }
    }
}
