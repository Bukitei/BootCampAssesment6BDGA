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

    }
}
