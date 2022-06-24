namespace Givt.Core.API.Models.Config
{
    /// <summary>
    /// Model of the ApiKey settings
    /// </summary>
    public class ApiKeysConfig
    {
        /// <summary>
        /// Section name in configuration
        /// </summary>
        public const string SectionName = "ApiKeys";

        /// <summary>
        /// private key to sign authorisation information data to Auth0 (or other external authentication providers)
        /// </summary>
        public Dictionary<string, string> Keys = new();
    }
}
