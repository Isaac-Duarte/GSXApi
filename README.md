# GSX REST Api Client
This is a library to interface with the GSX Api.

Currently, there are no valid requests however once I gain access to the GSX API I made it super easy to add api calls.

## Example Calls
For more information look at the **[interface](/GSXApi/Interfaces/IApiCall.cs)** and the **[ExampleCall](/GSXApi/ApiCalls/ExampleCall.cs)**.

## Samples

### Implementing a new GSX request.  
```cs
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
```


## Sample Usage
```cs
GSXApiClient client = new GSXApiClient(gsxConfiguration)

var result = await client.GetExampleAsync();

Console.WriteLine(result.Secret);
```

## Credits
[Rest Sharp](https://restsharp.dev/) - Made my life easier