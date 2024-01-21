using HousingReservation.Domain.Common;

namespace Domain.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string NameWithType { get; set; }
        public string FederalDisctrict { get; set; }
        public string KladrId { get; set; }
        public string FiasId { get; set; }
        public string Okato { get; set; }
        public string Oktmo { get; set; }
        public string TaxOffice { get; set; }
        public string PostalCode { get; set; }
        public string IsoCode { get; set; }
        public string Timezone { get; set; }
        public string GeonameCode { get; set; }
        public string GeonameId { get; set; }
        public string GeonameName { get; set; }
    }
}
