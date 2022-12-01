namespace Assesment6DotNET.Models
{
    public class TypeData
    {
        public int? idType { get; set; }
        public string? typeName { get; set; }

        public TypeData(int idType)
        {
            this.idType = idType;
        }
        public TypeData(string typeName)
        {
            this.typeName = typeName;
        }

        public TypeData(int idType, string typeName)
        {
            this.idType = idType;
            this.typeName = typeName;
        }
        public TypeData()
        {
            
        }
    }

}
