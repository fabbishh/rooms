using Application.Models;

namespace Application.Services
{
    public interface IRegionService
    {
        Task SeedRegionDataAsync();
        Task<IEnumerable<RegionModel>> GetRegionsAsync(bool? isActive);
        Task UpdateActivity(Guid id, bool isActive);
        Task<RegionModel> GetDefaultRegion();
    }
}
