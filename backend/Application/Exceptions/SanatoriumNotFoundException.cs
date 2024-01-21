using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class SanatoriumNotFoundException : Exception
    {
        public SanatoriumNotFoundException(Guid sanatoriumId) : base($"Санаторий {sanatoriumId} не найден") { }
    }
}
