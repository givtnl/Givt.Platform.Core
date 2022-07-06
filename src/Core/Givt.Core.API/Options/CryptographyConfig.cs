namespace Givt.Core.API.Options
{
    /// <summary>
    /// Model of the Cryptographic settings
    /// </summary>
    public class CryptographyConfig
    {
        /// <summary>
        /// Section name in configuration
        /// </summary>
        public const string SectionName = "Cryptography";

        /// <summary>
        /// private key to sign authorisation information data to Auth0 (or other external authentication providers)
        /// </summary>
        public string AuthorisationSigningKey { get; set; } = string.Empty;
    }
}
