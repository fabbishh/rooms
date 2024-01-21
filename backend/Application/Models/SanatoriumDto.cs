namespace Application.Models
{
    public class SanatoriumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? PhotoUrl { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Address { get; set; }
        public decimal? PriceFrom { get; set; }
        public int Season { get; set; }
        public bool IsFavourite { get; set; }
    }
}
