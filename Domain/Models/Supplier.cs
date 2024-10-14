using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Domain.Models
{
    public class Supplier : BaseDomainEntity
    {
        [Required(ErrorMessage ="Supplier Name Can't be empty")]
        public string SupplierName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int Total { get; set; }
        public int PaidAmount { get; set; }
        public int UnpaidAmount { get; set; }
        public virtual List<Purchase> Purchases { get; set; } = new List<Purchase>();

    }
}
