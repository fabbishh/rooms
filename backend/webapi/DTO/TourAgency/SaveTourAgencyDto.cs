namespace webapi.DTO.TourAgency
{
    public class SaveTourAgencyDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Guid SubjectId { get; set; }
        public string? Location { get; set; }
        public string? Link { get; set; }
        public string Email { get; set; }
        public string? Description { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
