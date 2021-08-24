using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace GSXApi.Services
{
    public interface IApiCall
    {
        /// <summary>
        /// The Http method to use (GET POST ETC)
        /// </summary>
        /// <value></value>
        Method HttpMethod { get; }

        /// <summary>
        /// The path after the base URL. I.E /repair/summary
        /// </summary>
        string ApiPath { get; }
        
        /// <summary>
        /// The POST payload.
        /// </summary>
        object Payload { get; }

        /// <summary>
        /// The URL Parameters wanting to be added.
        /// </summary>
        /// <value></value>
        Dictionary<string, string> Parameters { get; }
    }
}