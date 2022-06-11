using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace KrabbelModerationFunctions
{
    public class Function : IHttpFunction
    {
        /// <summary>
        /// Logic for your function goes here.
        /// </summary>
        /// <param name="context">The HTTP context, containing the request and the response.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task HandleAsync(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            ContentType contentType = new ContentType(request.ContentType);


            if(contentType.MediaType == "application/json")
            {
                using TextReader reader = new StreamReader(request.Body);
                string json = await reader.ReadToEndAsync();
                JsonElement body = JsonSerializer.Deserialize<JsonElement>(json);
                if (body.TryGetProperty("text", out JsonElement property) && property.ValueKind == JsonValueKind.String)
                {
                    string text = null;
                    text = property.GetString();

                    var badWords = new List<string>()
                    {
                        "avans",
                        "ajax",
                        "kut",
                        "godverdomme"
                    };

                    foreach (var badWord in badWords)
                    {
                        text = text.Replace(badWord, "bobba");
                    }

                    await context.Response.WriteAsync(text);

                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            } else
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }     
        }
    }
}
