using Assesment6DotNET.Models;

namespace Assesment6DotNET.Interfaces
{
    public interface IOportunityRepository
    {
        Task<IEnumerable<Oportunity>> GetAllOportunities();
        Task<Oportunity> GetOportunitiesById(int id);
        Task<Oportunity> AddOportunity(Oportunity oportunity);
        Task<Oportunity> UpdateOportunity(Oportunity oportunity);
        Task<Oportunity> DeleteOportunity(int id);
        Task<Oportunity> GetLastInsertedOportunity();
    }
}
