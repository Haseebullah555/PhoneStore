using PhoneStore.Application.Contracts;
using PhoneStore.Application.Contracts.Additional;
using PhoneStore.Persistence.Database;
using PhoneStore.Persistence.Repositories.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore.Persistence.Repositories
{
    public class UnitOfwork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        private ICustomerReposistory _customerRepository;
        private IProvinceRepository _provinceRepository;
        private ISupplierRepository _supplierRepository;
        private IGoodsRepository _goodsRepository;
        private ICompanyRepository _companyRepository;
        private IPurchaseRepository _purchaseRepository;
        private ISalesRepository _salesRepository;
        private IExtraExpensesRepository _extraExpensesRepository;
        private ICustomersPaymentRepository _customersPaymentRepository;
        private ISuppliersPaymentRepository _suppliersPaymentRepository;
        private IStockRepository _stockRepository;
        private ISupplierLoansRepository _supplierLoansRepository;
        private ICustomerLoansRepository _customerLoansRepository;

        public UnitOfwork(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public ICustomerReposistory CustomerReposistory =>
            _customerRepository ??= new CustomerRepository(_context);

        public IProvinceRepository ProvinceRepository => 
            _provinceRepository ??= new ProvinceRepository(_context);
        public ISupplierRepository SupplierRepository =>
            _supplierRepository ??= new SupplierRepository(_context);
        public IGoodsRepository GoodsRepository =>
            _goodsRepository ??= new GoodsRepository(_context);
        public ICompanyRepository CompanyRepository =>
            _companyRepository ??= new CompanyRepository(_context);
        public IPurchaseRepository PurchaseRepository => 
            _purchaseRepository ??= new PurchasesRepository(_context);
        public ISalesRepository SalesRepository =>
            _salesRepository ??= new SalesRepository(_context);
        public IExtraExpensesRepository ExtraExpensesRepository =>
            _extraExpensesRepository ??= new ExtraExpensesRepository(_context);
        public ICustomersPaymentRepository CustomersPaymentRepository =>
            _customersPaymentRepository ??= new CustomerPaymentRepository(_context);
        public ISuppliersPaymentRepository SuppliersPaymentRepository =>
            _suppliersPaymentRepository ??= new SuppliersPaymentRepository(_context);
        public IStockRepository StockRepository =>
            _stockRepository ??= new StockRepository(_context);
            
        public ICustomerLoansRepository CustomerLoansRepository =>
            _customerLoansRepository ??=new CustomerLoansRepository(_context);

        public ISupplierLoansRepository SuppliersLoansRepository => 
            _supplierLoansRepository ??= new SupplierLoansRepository(_context);

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
