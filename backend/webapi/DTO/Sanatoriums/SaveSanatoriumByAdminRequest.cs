namespace webapi.DTO.Sanatoriums
{
    public class SaveSanatoriumByAdminRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public Guid ObjectType { get; set; }
        public Guid SubjectId { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public int Season { get; set; }
        public int Status { get; set; }
        public Guid OwnerId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
