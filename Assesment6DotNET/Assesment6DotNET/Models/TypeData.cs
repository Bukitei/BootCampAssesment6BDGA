namespace Assesment6DotNET.Models
{
    public class TypeData
    {
        int idType { get; set; }
        string typeName { get; set; }

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
