using Assesment6DotNET.Models;

namespace Assesment6DotNET.Interfaces
{
    public interface OportunityInterface
    {
        Task<IEnumerable<Oportunity>> GetAllOportunities();
        Task<Oportunity> GetOportunitiesById(int id);
        Task<Oportunity> AddOportunity(Contact contact);
        Task<Oportunity> UpdateOportunity(Contact contact);
        Task<Oportunity> DeleteOportunity(int id);
    }
}
