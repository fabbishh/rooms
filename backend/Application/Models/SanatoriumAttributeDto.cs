using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SanatoriumAttributeDto
    {
        public Guid SanatoriumAttributeId { get; set; }
        public string Name { get; set; }
        public string? GroupName { get; set; }
        public bool IsActive { get; set; }

    }
}
