using webapi.DTO.Attributes;

namespace webapi.DTO.Sanatoriums
{
    public class UpdateSanatoriumAttributesDto
    {
        public List<AddSanatoriumAttributeDto> SanatoriumAttributes { get; set; }
        public string AttributeGroup { get; set; }
    }
}
