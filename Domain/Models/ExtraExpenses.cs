using PhoneStore.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Domain.Models
{
    public class ExtraExpenses : BaseDomainEntity
    {
        [Required(ErrorMessage ="Description is required!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Quantity is required!")]
        public double Quantity { get; set; }
        [Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }
    }
}
