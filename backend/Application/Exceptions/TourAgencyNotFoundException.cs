using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class TourAgencyNotFoundException : Exception
    {
        public TourAgencyNotFoundException(Guid tourAgencyId) : base(tourAgencyId.ToString()) { }
    }
}
