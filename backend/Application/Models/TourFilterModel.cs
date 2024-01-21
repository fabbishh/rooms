using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TourFilterModel
    {
        public int? DaysFrom { get; set; }
        public int? DaysTo { get; set; }
        public int? TouristsFrom { get; set; }
        public int? TouristsTo { get; set; }
        public List<int>? Seasons { get; set; }
        public Guid? TourType { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public Guid? TourAgencyId { get; set; }
        public Guid? SubjectId { get; set; }
    }
}
