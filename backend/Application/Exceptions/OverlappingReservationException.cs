using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class OverlappingReservationException : Exception
    {
        public OverlappingReservationException() : base("Накладывающиеся брони") { }
    }
}
