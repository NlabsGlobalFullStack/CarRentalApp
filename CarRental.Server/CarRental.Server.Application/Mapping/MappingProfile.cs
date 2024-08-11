using AutoMapper;
using CarRental.Server.Application.Features.Auth.Register;
using CarRental.Server.Application.Features.Categories.CreateCategory;
using CarRental.Server.Domain.Cars;
using CarRental.Server.Domain.Users;

namespace CarRental.Server.Application.Mapping;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AppUser, RegisterCommand>().ReverseMap();
        CreateMap<CreateCategoryCommand, Category>().ReverseMap();
    }
}