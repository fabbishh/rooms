using Domain.Common;
using Domain.Entities;
using Domain.Models;
using HousingReservation.DataAccess;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataSeeder
    {
        public static void SeedData(ReservationDbContext context)
        {
            if (!context.Subjects.Any())
            {
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

                List<Subject> subjects = new List<Subject>();

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

                    subjects.Add(mappedRegion);
                }

                context.Subjects.AddRange(subjects);

                context.SaveChanges();
            }
        }
    }
}
