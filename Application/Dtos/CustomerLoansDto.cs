using PhoneStore.Application.Dtos.Common;

namespace PhoneStore.Application.Dtos
{
    public class CustomerLoansDto : BaseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int UnpaidAmount { get; set; }
    }
}
