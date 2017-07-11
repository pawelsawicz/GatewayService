using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace devWarsztaty_GatewayService
{
    public class ScoringResult
    {
        public bool Eligible { get; set; }
    }

    public class ScoringService
    {
        public ScoringResult GetScore(QuoteRequest quoteRequest)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://172.17.0.2:5001");
            var json = JsonConvert.SerializeObject(quoteRequest);
            var requestBody = new StringContent(json);
            requestBody.Headers.Remove("Content-Type");
            requestBody.Headers.Add("Content-Type", "application/json");

            var result = httpClient.PostAsync("/scores", requestBody).Result;
            var resultObject = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ScoringResult>(resultObject);
        }
    }
}