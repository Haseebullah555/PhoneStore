using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneStore.Domain.Models
{
    public class CustomersPayment : BaseDomainEntity
    {
        public int PaymentAmount { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }
        public int SalesId { get; set; }
        [ForeignKey(nameof(SalesId))]
        public Sales? Sales { get; set; }
    }
}
