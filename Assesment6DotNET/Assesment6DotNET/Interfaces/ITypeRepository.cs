using Assesment6DotNET.Models;

namespace Assesment6DotNET.Interfaces
{
    public interface ITypeRepository
    {
        Task<IEnumerable<TypeData>> GetAllTypes();
        Task<Oportunity> GetTypesById(int id);
        Task<TypeData> AddTypes(TypeData type);
        Task<TypeData> UpdateTypes(TypeData type);
        Task<TypeData> DeleteTypes(int id);
        Task<Oportunity> GetLastInsertedType();
    }
}
