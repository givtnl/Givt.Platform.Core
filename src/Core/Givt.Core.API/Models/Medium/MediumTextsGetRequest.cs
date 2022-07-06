using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Givt.Core.API.Models.Medium;

public class MediumTextsGetRequest
{
    [Required]
    [Description("Medium ID or Code")]
    public string Code { get; set; }

    [Description("Language/Region for texts. If not set defaults to 'en'")]
    public string Language { get; set; }
}