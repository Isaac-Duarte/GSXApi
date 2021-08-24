using System.Collections.Generic;
using GSXApi.Services;
using RestSharp;

namespace GSXApi.ApiCalls
{
    public class ExampleCall : IApiCall
    {
        private ExamplePayload _examplePayload;
        private Dictionary<string, string> _parameters;
        
        /// <summary>
        /// This API Call is a POST Method
        /// </summary>
        public Method HttpMethod 
        {
            get
            {
                return Method.POST;
            }
        }

        /// <summary>
        /// This is the path of the API Call
        /// </summary>
        public string ApiPath
        {
            get
            {
                return "/exmaple";
            }
        }

        /// <summary>
        /// This is the payload for POST objects
        /// </summary>
        /// <value></value>
        public object Payload
        {
            get
            {
                return _examplePayload;
            }
        }


        /// <summary>
        ///  These are the GET parameters
        /// </summary>
        public Dictionary<string, string> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        /// <summary>
        /// Add the payload directrly into the payload
        /// </summary>
        /// <param name="examplePayload"></param>
        public ExampleCall(ExamplePayload examplePayload=null, Dictionary<string, string> parameters=null)
        {
            _examplePayload = examplePayload;
            _parameters = parameters;
        }
    }

    /// <summary>
    /// This would be the request payload
    /// </summary>
    public class ExamplePayload
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    }
    
    /// <summary>
    /// This would be the exepcted response
    /// </summary>
    public class ExampleCallResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Secret { get; set; }
    }
}