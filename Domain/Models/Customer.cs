using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class Customer : BaseDomainEntity
    {
        [Required(ErrorMessage = "Customer Name is Required!")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Customer Phone Number is Required!")]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public int Total { get; set; }
        public int PaidAmount { get; set; }
        public int UnpaidAmount { get; set; }
        public int ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public Province? Province { get; set; }
        public virtual List<Sales> Sales { get; set; } = new List<Sales>();

    }
}
