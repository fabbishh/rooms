namespace webapi.DTO.Attributes
{
    public class DeleteAttributesRequest
    {
        public List<Guid> AttributeIds { get; set; } = new List<Guid>();
    }
}
