namespace Assesment6DotNET.Models
{
    public class Relationship
    {
        int idRelationship { get; set; }
        Oportunity oportunity1 { get; set; }
        Oportunity oportunity2 { get; set; }
        bool isGood { get; set; }
        string Description { get; set; }
    }
}
