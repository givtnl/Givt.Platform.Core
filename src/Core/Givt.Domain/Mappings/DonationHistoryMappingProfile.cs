using AutoMapper;
using Givt.Domain.Entities;

namespace Givt.Domain.Mappings;

public class DonationHistoryMappingProfile: Profile
{
    public DonationHistoryMappingProfile()
    {
        CreateMap<Donation, DonationHistory>();
    }
}