using HomeOrganizer.API.Dto;
using HomeOrganizer.API.Dto.Base;
using HomeOrganizer.API.Dto.Home;
using HomeOrganizer.API.Dto.Task;
using HomeOrganizer.API.Dto.UserAccount;
using HomeOrganizer.Domain.Common;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Infrastructure.Authentication;
using Org.BouncyCastle.Asn1.Cms;
using Task = HomeOrganizer.Domain.Entities.Task;

namespace HomeOrganizer.API.Extensions;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<UserAccount, UserAccountDto>();
        CreateMap<EntityBase, DtoBase>();
        CreateMap<CurrentUser, CurrentUserDto>();
        CreateMap<Home, HomeDto>()
            .ForMember(dest => dest.Tasks, 
                opt => opt.MapFrom(src => src.Tasks))
            .ForMember(dest => dest.UserAccounts, 
                opt => opt.MapFrom(src => src.UserAccountHomes));
        CreateMap<UserAccountHome, Dto.Home.UserAccountHomeDto>()
            .IncludeMembers(x => x.UserAccount)
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.UserAccount.Id));
        CreateMap<UserAccount, Dto.Home.UserAccountHomeDto>();
        CreateMap<UserAccountHome, Dto.UserAccount.UserAccountHomeDto>()
            .IncludeMembers(x => x.UserAccount)
            .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.UserAccount.Id));
        CreateMap<UserAccount, Dto.UserAccount.UserAccountHomeDto>();
        CreateMap<Task, Dto.Home.TaskDto>()
            .ForMember(dest => dest.UserAccounts,
                opt => opt.MapFrom(src => src.TaskUserAccounts.Select(x => x.UserAccount)));
        CreateMap<Task, Dto.Task.TaskDto>()
            .ForMember(dest => dest.Home,
                opt => opt.MapFrom(src => src.Home))
            .ForMember(dest => dest.UserAccounts,
                opt => opt.MapFrom(src => src.TaskUserAccounts.Select(x => x.UserAccount)));
    }
}