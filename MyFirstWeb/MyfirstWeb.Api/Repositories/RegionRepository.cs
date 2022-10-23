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

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await mWebDBContext.AddAsync(region);
            await mWebDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await mWebDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            //delete region
            mWebDBContext.Regions.Remove(region);
            await mWebDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await mWebDBContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
            return await mWebDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await mWebDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if(existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await mWebDBContext.SaveChangesAsync();

            return existingRegion;
        }

    }
}

