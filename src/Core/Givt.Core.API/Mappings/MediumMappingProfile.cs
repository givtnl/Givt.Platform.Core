using AutoMapper;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.CQR;
using Givt.Core.Business.Models;

namespace Givt.Core.API.Mappings;

public class MediumMappingProfile : Profile
{
    public MediumMappingProfile()
    {
        // API -> Business
        CreateMap<MediumCheckRequest, MediumExistQuery>()
            .ForMember(dst => dst.MediumIdType,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)));

        CreateMap<MediumGetRequest, CampaignGetQuery>()
            .ForMember(dst => dst.MediumIdType,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)))
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom((src, dst) => Guid.TryParse(src.Code, out dst.MediumId)))
            ;

        CreateMap<MediumTextsGetRequest, CampaignGetQuery>()
            .ForMember(dst => dst.MediumIdType,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)))
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom((src, dst) => Guid.TryParse(src.Code, out dst.MediumId)))
            ;

        // Business -> API

    }
}