using Application.Models;
using Domain.Common;
using Domain.Entities;
using Domain.Models;
using Newtonsoft.Json;

namespace Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegionService(ISubjectRepository subjectRepository, IUnitOfWork unitOfWork)
        {
            _subjectRepository = subjectRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateActivity(Guid id, bool isActive)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if(subject is not null)
            {
                subject.IsActive = isActive;
                _subjectRepository.Update(subject);
                await _unitOfWork.SaveAsync();
            }  
        }

        public async Task<IEnumerable<RegionModel>> GetRegionsAsync(bool? isActive)
        {
            IEnumerable<Subject>? regions = null;
            if (isActive is null)
            {
                regions = await _subjectRepository.GetAllAsync();
            } else
            {
                regions = await _subjectRepository.FindAsync(s => s.IsActive == isActive);
            }

            var mappedRegions = regions.Select(s => new RegionModel { Id = s.Id, IsActive = s.IsActive, NameWithType = s.NameWithType, Name = s.Name });

            return mappedRegions;
        }

        public async Task<RegionModel> GetDefaultRegion()
        {
            var region = await _subjectRepository.FindOneAsync(r => r.NameWithType == "Пермский край");
            if(region == null)
            {
                return null;
            }

            var mappedRegion = new RegionModel { Id = region.Id, IsActive = region.IsActive, NameWithType = region.NameWithType, Name = region.Name };

            return mappedRegion;
        }

        public async Task SeedRegionDataAsync()
        {
            var existingRegions = await _subjectRepository.GetAllAsync();
            if(existingRegions is not null && existingRegions.Any())
            {
                return;
            }

            List<SubjectSerializeModel>? regions = null;
            using (StreamReader r = new StreamReader("Data/regions.json"))
            {
                string json = r.ReadToEnd();
                regions = JsonConvert.DeserializeObject<List<SubjectSerializeModel>>(json);
            }

            if (regions is null || !regions.Any())
            {
                return;
            }

            foreach (var region in regions)
            {
                var mappedRegion = new Subject
                {
                    DateCreated = DateTimeOffset.UtcNow,
                    FederalDisctrict = region.federal_district,
                    FiasId = region.fias_id,
                    GeonameCode = region.geoname_code,
                    GeonameId = region.geoname_id,
                    GeonameName = region.geoname_name,
                    Id = Guid.NewGuid(),
                    IsActive = region.name_with_type == "Пермский край",
                    IsoCode = region.iso_code,
                    KladrId = region.kladr_id,
                    Name = region.name,
                    NameWithType = region.name_with_type,
                    Okato = region.okato,
                    Oktmo = region.oktmo,
                    PostalCode = region.postal_code,
                    TaxOffice = region.tax_office,
                    Timezone = region.timezone,
                    Type = region.type,
                };

                await _subjectRepository.AddAsync(mappedRegion);
            }

            await _unitOfWork.SaveAsync();
        }
    }
}
