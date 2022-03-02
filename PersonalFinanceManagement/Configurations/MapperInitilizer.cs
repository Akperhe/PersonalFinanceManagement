using AutoMapper;
using PersonalFinanceManagement.Data;
using PersonalFinanceManagement.Data.Dtos;
using X.PagedList;

namespace HotelListing.Core.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<AccountSummary, CreateAccountSummaryDto>().ReverseMap();
            CreateMap<AccountSummary, AccountSummaryDto>().ReverseMap();
            CreateMap<AccountSummary, AccountSummary>().ReverseMap();
            CreateMap<AccountSummaryDto, UpdateAccountSummaryDto>().ReverseMap();
            CreateMap< UpdateAccountSummaryDto, AccountSummary>().ReverseMap();
           // CreateMap<IPagedList<AccountSummary>, IPagedList<UpdateAccountSummaryDto>>().ReverseMap();
           
        }
    }
}
