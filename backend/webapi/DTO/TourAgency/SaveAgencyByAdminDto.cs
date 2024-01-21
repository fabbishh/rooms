namespace webapi.DTO.TourAgency
{
    public class SaveAgencyByAdminDto : SaveTourAgencyDto
    {
        public Guid OwnerId { get; set; }
        public int Status { get; set; }
    }
}
