namespace webapi.DTO.Auth
{
    public class ValidateConfirmationCodeDto
    {
        public string Code { get; set; }
        public string Email { get; set; }
        public bool ShouldUpdateConfirm {  get; set; }
    }
}
