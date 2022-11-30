namespace Assesment6DotNET.Models
{
    public class Oportunity
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surName { get; set; }
        public string details { get; set; }
        public bool isClient { get; set; }


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
