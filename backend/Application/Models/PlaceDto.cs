namespace Application.Models
{
    public class PlaceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public List<PhotoModel> Photos { get; set; } = new List<PhotoModel>();
    }
}
