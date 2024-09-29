using PhoneStore.Application.Dtos.Common;

namespace PhoneStore.Application.Dtos
{
    public class SupplierLoansDto : BaseDto
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int GoodId { get; set; }
        public string GoodName { get; set; }
        public int UnpaidAmount { get; set; }

    }
}
