namespace Assesment6DotNET.Models
{
    public class TypeData
    {
        public int idType { get; set; }
        public string typeName { get; set; }

        public TypeData(int idType)
        {
            this.idType = idType;
        }
        public TypeData(string typeName)
        {
            this.typeName = typeName;
        }
    }

}
