using MyfirstWeb.Api.Models.Domain;

namespace MyfirstWeb.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
