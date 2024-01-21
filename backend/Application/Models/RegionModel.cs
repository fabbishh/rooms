namespace Application.Models
{
    public class RegionModel
    {
        public Guid Id { get; set; }
        public string NameWithType { get; set; }
        public string Name {  get; set; }
        public bool IsActive { get; set; }
    }
}
