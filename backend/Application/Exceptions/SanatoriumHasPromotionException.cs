using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class SanatoriumHasPromotionException : Exception
    {
        public SanatoriumHasPromotionException(Guid sanatoriumId) : base($"Санаторий {sanatoriumId} уже находится в промо ряде") { }
    }
}
