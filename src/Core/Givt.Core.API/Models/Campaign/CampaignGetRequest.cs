using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Givt.Core.API.Models.Campaign;

public class CampaignGetRequest
{
    [Required]
    [Description("Medium ID or Code")]
    public string Code { get; set; }

}