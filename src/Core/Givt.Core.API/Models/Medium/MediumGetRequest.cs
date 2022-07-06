using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Givt.Core.API.Models.Medium;

public class MediumGetRequest
{
    [Required]
    [Description("Medium ID or Code")]
    public string Code { get; set; }

}