using Microsoft.EntityFrameworkCore;
using MyfirstWeb.Api.Data;
using MyfirstWeb.Api.Models.Domain;

namespace MyfirstWeb.Api.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly MWebDBContext mWebDBContext;

        public RegionRepository(MWebDBContext mWebDBContext)
        {
            this.mWebDBContext = mWebDBContext;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
           return await mWebDBContext.Regions.ToListAsync();
        }
    }
}
