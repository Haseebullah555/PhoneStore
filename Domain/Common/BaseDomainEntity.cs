namespace PhoneStore.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
        public DateTime LastModifyBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
