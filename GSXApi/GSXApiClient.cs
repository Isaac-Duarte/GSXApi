using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GSXApi.ApiCalls;
using GSXApi.Models;
using GSXApi.Services;
using RestSharp;

namespace GSXApi
{
    /// <summary>
    /// This is a C# Implementation of the GSX Rest API
    /// </summary>
    public class GSXApiClient
    {
        private WebHandler _webHandler;
        private GSXConfiguration _configuration;

        public GSXApiClient(GSXConfiguration configuration)
        {
            // Initalize web handler
            _configuration = configuration;
            _webHandler = new WebHandler(_configuration);
        }

        /// <summary>
        /// This is an example of a call.
        /// </summary>
        /// <returns></returns>
        public async Task<ExampleCallResponse> GetExampleAsync()
        {
            // Create nessary payoads
            ExamplePayload payload = new ExamplePayload
            {
                Id = 0,
                FirstName = "Isaac"
            };
            
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["name"] = "value"; 
            
            // Create and execute the api request
            ExampleCall exampleCall = new ExampleCall(payload, parameters);
            IRestResponse<ExampleCallResponse> response = await _webHandler.ExecuteAsync<ExampleCallResponse>(exampleCall);
            
            // Return data.
            if (response.IsSuccessful)
                return response.Data;
            else
                throw new GSXException($"Unable to send request to {response.ResponseUri}", response.ErrorException);
        }
    }
}
