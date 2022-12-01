using Assesment6DotNET.Models;

namespace Assesment6DotNET.Interfaces
{
    public interface ITypeRepository
    {
        Task<IEnumerable<Oportunity>> GetAllTypes();
        Task<Oportunity> GetTypesById(int id);
        Task<Oportunity> AddTypes(TypeData type);
        Task<Oportunity> UpdateTypes(TypeData type);
        Task<Oportunity> DeleteTypes(int id);
    }
}
