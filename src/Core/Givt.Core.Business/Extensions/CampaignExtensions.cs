using Givt.Core.Domain.Entities;
using Givt.Platform.Common.Enums;
using System.Reflection;

namespace Givt.Core.Business.Extensions;

public static class CampaignExtensions
{
    public static IEnumerable<PaymentMethod> GetPaymentMethods(this Campaign campaign)
    {
        if (campaign.Owner?.PayOutMethods?.Any() == true)
            return campaign.Owner.PaymentMethods;

        if (campaign.Owner?.Owner?.Country?.PaymentMethods?.Any() == true)
            return campaign.Owner.Owner.Country.PaymentMethods;

        return new List<PaymentMethod>();
    }

    // Select the best matching text on locale from the campaign, fall back to texts defined for the organisation
    public static string GetLocalisedText(this Campaign campaign, string propertyName, IOrderedEnumerable<string> locales)
    {
        var checkedDefaultLanguage = false;
        if (campaign == null)
            return null;
        // get the property value through reflection
        var propertyInfo = typeof(CampaignTexts).GetProperty(propertyName);
        if (propertyInfo == null)
            return null;

        var campaignTexts = campaign.Texts.ToList<CampaignTexts>();
        string result;
        if (locales?.Any() == true)
        {
            foreach (var locale in locales)
            {
                // get language from locale
                var p = locale.IndexOf('-');
                var language = p > 0 ? locale[..p] : locale;

                checkedDefaultLanguage |= language.Equals("en", StringComparison.OrdinalIgnoreCase);

                // match on Campaign texts
                result = GetMatchingText(campaignTexts, locale, language, propertyInfo);
                if (result != null) return result;
            }
        }
        if (!checkedDefaultLanguage)
        {
            // match on Campaign texts on default language "en" only
            result = GetMatchingText(campaignTexts, "en", propertyInfo);
            if (result != null) return result;
        }
        // Still (desperately) seeking... match any text
        result = GetAnyText(campaignTexts, propertyInfo);
        if (result != null) return result;

        return String.Empty;
    }

    private static string GetMatchingText(IList<CampaignTexts> texts, string locale, string language, PropertyInfo propertyInfo)
    {
        if (texts?.Count > 0)
        {
            CampaignTexts match = null;
            // exact match on language AND region 
            match = texts
                .Where(t => t.LanguageId.Equals(locale, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (match != null && propertyInfo.GetValue(match) is string result && !String.IsNullOrEmpty(result))
                return result;
        }
        return GetMatchingText(texts, language, propertyInfo);
    }

    private static string GetMatchingText(ICollection<CampaignTexts> texts, string language, PropertyInfo propertyInfo)
    {
        if (texts?.Count > 0)
        {
            CampaignTexts match = null;
            // language only
            match = texts
                .Where(t => t.LanguageId.Equals(language, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (match != null && propertyInfo.GetValue(match) is string result1 && !String.IsNullOrEmpty(result1))
                return result1;

            // other language codes with same language
            match = texts
                .Where(t => t.LanguageId.StartsWith(language + '-', StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
            if (match != null && propertyInfo.GetValue(match) is string result2 && !String.IsNullOrEmpty(result2))
                return result2;
        }
        return null;
    }

    private static string GetAnyText(ICollection<CampaignTexts> texts, PropertyInfo propertyInfo)
    {
        if (texts?.Count > 0)
        {
            foreach (var match in texts)
                if (propertyInfo.GetValue(match) is string result && !String.IsNullOrWhiteSpace(result))
                    return result;
        }
        return null;
    }

}