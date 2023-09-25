using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;
using NLog;
using NLog.Fluent;

namespace InfoTrackWebScrape.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebScraperController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string socsCookie = "SOCS=CAESHAgCEhJnd3NfMjAyMzA5MTItMF9SQzIaAmVuIAEaBgiApp6oBg";
        Logger logger = LogManager.GetCurrentClassLogger();

        public WebScraperController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            
        }

        [HttpGet("GoogleScrapePositions")]
        public async Task<string> GoogleScrapePositions([FromQuery] HttpClient httpClient, string searchString , string urlString = "www.infotrack.co.uk", int numResults = 100 )
        {
            searchString = searchString.Replace(' ', '+');
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://www.google.co.uk/search?num=100&q={searchString}"),        
            };
            //Addition of SOCS Cookie is necessary to avoid running into "Accept Cookies" Modal pop-up.
            request.Headers.Add("Cookie", socsCookie ) ;
         
            try
            {
                string responseAsString;
                using (HttpResponseMessage response = await httpClient.SendAsync(request))
                {                    
                    responseAsString = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(responseAsString) && response.IsSuccessStatusCode )
                    {
                        string stringPositions = HelperClass.ExtractPositionsFromResponse(responseAsString, urlString);
                        return stringPositions;
                    }

                    else if (string.IsNullOrEmpty(responseAsString))
                    {
                        logger.Error("Response string is null or empty.");
                        throw new ArgumentNullException(responseAsString);
                    }
                    else
                    {
                        logger.Error(@"Unsuccessful response: {0}" , response.StatusCode);
                        throw new HttpRequestException("Response status code unsuccessful.");
                    }                 
                }                          
            }
            catch(Exception ex) 
            {
                logger.Error(string.Format("An unexpected exception has occured whilst making the api call"), ex);
                throw;
            }
            

        }
    }
}
