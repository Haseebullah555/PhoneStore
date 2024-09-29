using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class CustomerLoans : BaseDomainEntity
    {
        public int UnpaidAmount { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
    }
}
