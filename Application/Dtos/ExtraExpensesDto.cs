using PhoneStore.Application.Dtos.Common;
using System.ComponentModel.DataAnnotations;

namespace PhoneStore.Application.Dtos
{
    public class ExtraExpensesDto : BaseDto
    {
        [Display(Name ="Description"),Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }
        [Display(Name = "Quantity"), Required(ErrorMessage = "Quantity is required!")]
        public double Quantity { get; set; }
        [Display(Name = "Date"), Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }
    }
}
