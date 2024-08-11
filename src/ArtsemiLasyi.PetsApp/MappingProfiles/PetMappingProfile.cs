namespace ArtsemiLasyi.PetsApp.MappingProfiles;

using Responses;
using AutoMapper;
using DataAccess.Entities;

public class PetMappingProfile : Profile
{
    public PetMappingProfile()
    {
        CreateMap<Pet, PetResponse>()
            .ForMember(dst => dst.Id, src => src.MapFrom(m => m.Id))
            .ForMember(dst => dst.Name, src => src.MapFrom(m => m.Name))
            .ForMember(
                dst => dst.AgeInMonths,
                src => src.MapFrom(
                    m => DateTime.UtcNow.Date.Month 
                        - m.BirthDate.Month
                        + 12 * (
                            DateTime.UtcNow.Date.Year
                            - m.BirthDate.Year
                        )
                )
            )
            .ForMember(
                dst => dst.WeightInGrams,
                src => src.MapFrom(m => m.WeightInGrams)
            )
            .ForMember(
                dst => dst.PetBreedName,
                src => src.MapFrom(m => m.PetBreed.Name)
            )
            .ForMember(
                dst => dst.PetTypeName,
                src => src.MapFrom(m => m.PetBreed.PetType.Name)
            );
    }
}