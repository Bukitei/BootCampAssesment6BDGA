namespace Assesment6DotNET.Models
{
    public class Contact
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public bool isAction { get; set; }
        public TypeData type { get; set; }
        public string details { get; set; }
        public Oportunity oportunity { get; set; }

        public Contact(DateTime date, bool isAction, TypeData type, string details, Oportunity oportunity)
        {
            this.date = date;
            this.isAction = isAction;
            this.type = type;
            this.details = details;
            this.oportunity = oportunity;
        }

        public Contact(DateTime date, bool isAction, int typeId, string details, int oportunityId)
        {
            this.date = date;
            this.isAction = isAction;
            this.type = new TypeData(typeId);
            this.details = details;
            this.oportunity = new Oportunity(oportunityId);
        }

        public Contact(int id, DateTime date, bool isAction, int typeId, string details, Oportunity oportunity)
        {
            this.id = id;
            this.date = date;
            this.isAction = isAction;
            this.type = new TypeData(typeId);
            this.details = details;
            this.oportunity = oportunity;
        }

        public Contact(int id, int idOportunity, DateTime date, bool isAction, string details, int idTypes)
        {
            this.id = id;
            this.oportunity = new Oportunity(idOportunity);
            this.date = date;
            this.isAction = isAction;
            this.details = details;
            this.type = new TypeData(idTypes);
        }

        public Contact()
        {
            
        }
    }
}
