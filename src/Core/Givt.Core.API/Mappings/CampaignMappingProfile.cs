using AutoMapper;
using Givt.Core.API.Models.Medium;
using Givt.Core.Business.Extensions;
using Givt.Core.Domain.Entities;
using Givt.Platform.Payments.Enums;

namespace Givt.Core.API.Mappings;

public class CampaignMappingProfile : Profile
{
    public CampaignMappingProfile()
    {
        CreateMap<Campaign, MediumTextsGetResponse>()
            .ForMember(dst => dst.OrganisationName,
                options => options.MapFrom(src => src.Owner.Owner.Name))
            .ForMember(dst => dst.Language,
                options => options.MapFrom(src => src.Owner.Owner))
            .ForMember(dst => dst.Country,
                options => options.MapFrom(src => src.Owner.Owner.CountryId ))
            .ForMember(dst => dst.OrganisationLogoLink,
                options => options.MapFrom(src => src.Owner.LogoImageLink))
            .ForMember(dst => dst.Title,
                options => options.MapFrom(
                    (src, dest, _, context) => src.GetLocalisedText(nameof(CampaignTexts.Title), context.Items[ContextTag.Language] as string)))
            .ForMember(dst => dst.Goal,
                options => options.MapFrom(
                    (src, dest, _, context) => src.GetLocalisedText(nameof(CampaignTexts.Goal), context.Items[ContextTag.Language] as string)))
            .ForMember(dst => dst.ThankYou,
                options => options.MapFrom(
                    (src, dest, _, context) => src.GetLocalisedText(nameof(CampaignTexts.ThankYou), context.Items[ContextTag.Language] as string)))
            .ForMember(dst => dst.PaymentMethods,
                options => options.MapFrom(src => GetPaymentMethodsAsStrings(src.GetPaymentMethods())))
            .ForMember(dst => dst.Currency,
                options => options.MapFrom(src => src.Owner.Owner.Country.Currency))
            //AutoMapper maps Amounts
            .ForMember(dst => dst.WantKnowMoreLink,
                options => options.MapFrom(src => src.Owner.Owner.Country.GivtOffice.WantKnowMore))
            .ForMember(dst => dst.PrivacyPolicyLink,
                options => options.MapFrom(src => src.Owner.Owner.Country.GivtOffice.GivtPrivacyPolicy))
            ;

        CreateMap<Campaign, MediumGetResponse>()
           .ForMember(dst => dst.CampaignId,
               options => options.MapFrom(src => src.Id))
           .ForMember(dst => dst.RecipientId,
               options => options.MapFrom(src => src.OwnerId))
           .ForMember(dst => dst.Country,
               options => options.MapFrom(src => src.Owner.Owner.CountryId))
           .ForMember(dst => dst.Currency,
               options => options.MapFrom(src => src.Owner.Owner.Country.Currency))
           .ForMember(dst => dst.FeeAmount,
               options => options.MapFrom(src =>
                   (src.FeeAgreements.Count > 0) ? src.FeeAgreements.First().Fee.Amount :
                   (src.DefaultFee != null) ? src.DefaultFee.Amount : -1))
           .ForMember(dst => dst.FeePercentage,
               options => options.MapFrom(src =>
                   (src.FeeAgreements.Count > 0) ? src.FeeAgreements.First().Fee.Percentage :
                   (src.DefaultFee != null) ? src.DefaultFee.Percentage : -1))
           ;
    }

    // TODO: check if AutoMapper supports mapping from string <-> PaymentMethod, so we implement those and let AutoMapper do the work for list creation etc.
    private static string[] GetPaymentMethodsAsStrings(IEnumerable<PaymentMethod> paymentMethods)
    {
        var result = new List<string>();
        foreach (var paymentMethod in paymentMethods)
        {
            result.Add(paymentMethod.ToString().ToLowerInvariant());
        }
        result.Sort();
        return result.ToArray();
    }

}