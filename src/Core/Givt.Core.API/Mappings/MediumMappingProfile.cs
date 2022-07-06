using AutoMapper;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.CQR;
using Givt.Core.Business.Models;
using Givt.Core.Domain.Entities;
using Givt.Platform.Payments.Enums;

namespace Givt.Core.API.Mappings;

public class MediumMappingProfile : Profile
{
    public MediumMappingProfile()
    {
        // API -> Business
        CreateMap<MediumTextsGetRequest, MediumExistQuery>()
            .ForMember(dst => dst.MediumId, 
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)));

        CreateMap<MediumGetRequest, CampaignGetByMediumQuery>()
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)));

        CreateMap<MediumTextsGetRequest, CampaignGetByMediumQuery>()
            .ForMember(dst => dst.MediumId,
                options => options.MapFrom(src => MediumIdType.FromString(src.Code)));

        // Business -> API

    }
}