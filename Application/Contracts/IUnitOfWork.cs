using PhoneStore.Application.Contracts.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Application.Contracts
{
    public interface IUnitOfWork
    {
        public ICustomerReposistory CustomerReposistory {  get; }
        public ISupplierRepository SupplierRepository { get; }
        public IGoodsRepository GoodsRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        //public IPurchaseRepository PurchaseRepository { get; }
        //public ISalesRepository SalesRepository { get; }
        public IExtraExpensesRepository ExtraExpensesRepository { get; }
        public ICustomersPaymentRepository CustomersPaymentRepository { get; }
        public ISuppliersPaymentRepository SuppliersPaymentRepository { get; }  
        public IStockRepository StockRepository { get; }
        public ISupplierLoansRepository SuppliersLoansRepository { get; }
        public ICustomerLoansRepository CustomerLoansRepository { get; }



        public IProvinceRepository ProvinceRepository { get; }
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
