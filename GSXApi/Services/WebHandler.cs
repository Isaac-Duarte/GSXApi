using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GSXApi.Enums;
using GSXApi.Models;
using RestSharp;

namespace GSXApi.Services
{
    public class WebHandler
    {
        private RestClient _client;
        private GSXConfiguration _gsxConfiguration;

        public WebHandler(GSXConfiguration gsxConfiguration)
        {
            _client = new RestClient(gsxConfiguration.BaseUrl); 
            _gsxConfiguration = gsxConfiguration;

            // Add the client certificate to the rest client
            addClientCertificate();

            // Adds the approiate acecpt language header to the rest client
            addAcceptLanguageHeader();

            // Set the user agent
            _client.UserAgent = "Cosmos";
        }

        /// <summary>
        /// Adds a client certificate based on the configuration
        /// </summary>
        private void addClientCertificate()
        {
            // File validation
            if (!File.Exists(_gsxConfiguration.AuthConfiguration.PartnerCertPath))
                throw new FileNotFoundException("Could not find the client certificate", 
                    _gsxConfiguration.AuthConfiguration.PartnerCertPath);
            
            // Generate certificate class
            X509Certificate2 certificate = new X509Certificate2(_gsxConfiguration.AuthConfiguration.PartnerCertPath,
                _gsxConfiguration.AuthConfiguration.CertPassword,
                X509KeyStorageFlags.MachineKeySet);

            // Add that certificate to the file.
            _client.ClientCertificates = new X509CertificateCollection();
            _client.ClientCertificates.Add(certificate);
        }

        /// <summary>
        /// Adds the appropiate header to the client
        /// </summary>
        private void addAcceptLanguageHeader()
        {
            string headerValue = "";

            switch (_gsxConfiguration.AcceptLanguage)
            {
                case AcceptLanguage.EnglishUS:
                    headerValue = "en_US";
                    break;
                default:
                    headerValue = "en_US";
                    break;
            }

            _client.AddDefaultHeader("Accept-Language", headerValue);
        }

        /// <summary>
        /// Executes a call to GSX's REST API
        /// </summary>
        /// <param name="call">The API Call</param>
        /// <typeparam name="T">Expected Response Object</typeparam>
        /// <returns>Expected Response Object</returns>
        public async Task<IRestResponse<T>> ExecuteAsync<T>(IApiCall call)
        {
            // Make request payload.
            IRestRequest request = new RestRequest(call.ApiPath, call.HttpMethod);

            // Add proper json body
            if (call.HttpMethod == Method.POST)
                request.AddJsonBody(call.Payload);
            
            var response = await _client.ExecuteAsync<T>(request);

            return response;
        }
    }
}