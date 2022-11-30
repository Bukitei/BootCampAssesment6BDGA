namespace Assesment6DotNET.Models
{
    public class Oportunity
    {
        int id { get; set; }
        string name { get; set; }
        string surName { get; set; }
        string details { get; set; }
        bool isClient { get; set; }


        public Oportunity(string name, string surName, string details, bool isClient)
        {
            this.name = name;
            this.surName = surName;
            this.details = details;
            this.isClient = isClient;
        }
        public Oportunity(int id){
                this.id = id;
            }

    }
}
