namespace Givt.Core.Domain.Entities
{
    public class GivtOffice
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public LegalEntity Owner { get; set; }
        public string WantKnowMore { get; set; }
        public string GivtPrivacyPolicy { get; set; }
    }
}