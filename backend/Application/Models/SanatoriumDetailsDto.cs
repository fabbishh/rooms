namespace Application.Models
{
    public class SanatoriumDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int Status { get; set; }
        public List<string> PhotoUrls { get; set; } = new List<string>();
        public List<SanatoriumAttributeDto> Attributes { get; set; } = new List<SanatoriumAttributeDto>();
    }
}
