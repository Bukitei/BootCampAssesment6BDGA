namespace Assesment6DotNET.Models
{
    public class Oportunity
    {
        int id { get; set; }
        Contact contact { get; set; }
        string name { get; set; }
        string surName { get; set; }
        string details { get; set; }
        bool isClient { get; set; }

        public Oportunity(int id, Contact contact, string name, string surName, string details, bool isClient)
        {
            this.id = id;
            this.contact = contact;
            this.name = name;
            this.surName = surName;
            this.details = details;
            this.isClient = isClient;
        }


    }
}
