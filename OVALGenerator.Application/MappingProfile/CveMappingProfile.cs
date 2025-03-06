using AutoMapper;
using OVALGenerator.Application.Dtos;

namespace OVALGenerator.Application.MappingProfile;

public class CveMappingProfile : Profile
{
    public CveMappingProfile()
    {
        CreateMap<CveRequest, CveData>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CveId));

        CreateMap<CveResponse, CveRequest>()
            .ForMember(dest => dest.CveId, opt => opt.MapFrom(src =>
                src.CveMetadata.CveId))
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src =>
                src.Containers.Cna.Affected.FirstOrDefault()!.Product))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src =>
                src.Containers.Cna.Descriptions.FirstOrDefault()!.Value));

    }
}