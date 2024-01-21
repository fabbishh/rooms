namespace webapi.DTO.Places
{
    public class SavePlaceDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public List<IFormFile>? Photos { get; set; }
        public List<Guid>? DeletedPhotos { get; set; }
    }
}
