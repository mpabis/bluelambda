using System;
using Amazon.Lambda.Core;
using Newtonsoft.Json;

namespace CSharpFunction
{
    public class Headers
    {
        [JsonProperty("Content-Type")]
        public string ContentType { get; set; }
    }

    public class Response
    {
        [JsonProperty("headers")]
        public Headers Headers { get; set; }

        [JsonProperty("statusCode")]
        public int StatusCode { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class HelloWorld
    {
        [LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
        public Response Handler(ILambdaContext context)
        {
            LambdaLogger.Log($"function = {context.FunctionName} time = {DateTime.Now}");
            return new Response
            {
                Headers = new Headers
                {
                    ContentType = "text/plain"
                },
                StatusCode = 200,
                Body = "Hello World!!!"
            };
        }
    }
}