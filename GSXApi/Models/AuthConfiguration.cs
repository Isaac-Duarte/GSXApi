namespace GSXApi.Models
{
    public class AuthConfiguration
    {
        /// <summary>
        /// Sold to account number that is provided by Apple.
        /// </summary>
        public int SoldTo { get; set; }

        /// <summary>
        /// This is the certificate bundle provided by Apple
        /// Structured with your private key appended to the end of the file.
        /// </summary>
        public string PartnerCertPath { get; set; }

        /// <summary>
        /// Password for your private key.
        /// </summary>
        public string CertPassword { get; set; }
    }
}