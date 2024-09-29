namespace PhoneStore.Application.Dtos.Common
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModifyBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
