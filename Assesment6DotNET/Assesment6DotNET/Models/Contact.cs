namespace Assesment6DotNET.Models
{
    public class Contact
    {
        int id { get; set; }
        public DateTime date { get; set; }
        public bool isAction { get; set; }
        public int idType { get; set; }
        public string nameType { get; set; }
        public string details { get; set; }
        public int idOportunity { get; set; }
        public string nameOportunity { get; set; }
        public string surnameOportunity { get; set; }
        public string detailOportunity { get; set; }
        public bool isClient { get; set; }

        public Contact(DateTime date, bool isAction, int idType, string details, int idOportunity)
        {
            this.date = date;
            this.isAction = isAction;
            this.idType = idType;
            this.details = details;
            this.idOportunity = idOportunity;
        }
    }
}
