using AutoMapper;
using PhoneStore.Application.Dtos;
using PhoneStore.Application.Features.CustomerPayment.Request.Command;
using PhoneStore.Domain.Models;

namespace PhoneStore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Goods, GoodsDto>().ReverseMap();
            CreateMap<Purchase, PurchaseDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<ExtraExpenses, ExtraExpensesDto>().ReverseMap();
            CreateMap<CustomersPayment, CustomersPaymentDto>().ReverseMap();
            CreateMap<SuppliersPayment, SuppliersPaymentDto>().ReverseMap();
            CreateMap<Stock, StockDto>().ReverseMap();
            CreateMap<AddCustomerPaymentCommand, CustomersPayment>()
           .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<SupplierLoans, SupplierLoansDto>().ReverseMap();
            CreateMap<CustomerLoans, CustomerLoansDto>().ReverseMap();
        }
    }
}
