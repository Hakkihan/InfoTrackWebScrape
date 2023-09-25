using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrackWebScrape.Tests
{
    internal class WebScraperController
    {
        private Controllers.WebScraperController webScraperController;
        private HttpClient mockHttpClient;
        public WebScraperController()
        {
            mockHttpClient = new HttpClient();
            webScraperController = new Controllers.WebScraperController(mockHttpClient);
        }

        // Should be able to make a successful api call with a response of index positions using the GoogleScrapePositions Method
        [Test]
        public async Task GoogleScrapePositions_Test()
        {
            var responseString = await webScraperController.GoogleScrapePositions(mockHttpClient, "General Relativity", "en.wikipedia", 10);
            Assert.IsTrue(responseString.Length >= 1);
            return;
        }
    }
}
