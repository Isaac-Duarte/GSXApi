using GSXApi.Enums;

namespace GSXApi.Models
{
    public class GSXConfiguration
    {
        /// <summary>
        /// The base URL for the REST API
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// GSX authentication configuration
        /// </summary>
        public AuthConfiguration AuthConfiguration { get; set; }
        
        /// <summary>
        /// The accept-language header for GSX
        /// </summary>
        public AcceptLanguage AcceptLanguage { get; set; }
    }
}