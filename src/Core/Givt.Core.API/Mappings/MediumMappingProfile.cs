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
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)))
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom(src => GuidTryParse(src.Code)))
            ;

        CreateMap<CampaignGetRequest, CampaignGetQuery>()
            .ForMember(dst => dst.MediumIdType,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)))
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom(src => GuidTryParse(src.Code)))
            ;

        CreateMap<MediumTextsGetRequest, CampaignGetQuery>()
            .ForMember(dst => dst.MediumIdType,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)))
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom(src => GuidTryParse(src.Code)))
            ;

        // Business -> API

    }

    private static Guid GuidTryParse(string s)
    {
        var result = Guid.Empty;
        Guid.TryParse(s, out result);
        return result;
    }
}