using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace devWarsztaty_GatewayService
{
    public class GatewayModule
    {
        private readonly ScoringService scoringService;

        private readonly MatchingService matchingService;

        public GatewayModule(ScoringService scoringService, MatchingService matchingService)
        {
            this.scoringService = scoringService;
            this.matchingService = matchingService;
        }

        public Task GetLoan(HttpContext httpContext)
        {
            var gatewayRequest = new GatewayRequest();
            var applicantRequest = new ApplicantRequest
            {
            };
            var quoteRequest = new QuoteRequest
            {
                Name = "Test",
                LastName = "Kowalski",
                Country = "Poland",
                Income = 30000,
                Mortgage = false
            };
            var scoringResult = scoringService.GetScore(quoteRequest);
            if (scoringResult.Elig)
            {
                //var matchingResult = matchingService.GetMatching(quoteRequest);
                return httpContext.Response.WriteAsync("Done!");
            }
            return httpContext.Response.WriteAsync("Not Done!");
        }
    }

    public class GatewayResponse
    {
        public bool Elighb { get; set; }

        public decimal AmountToRepay { get; set; }
    }

    public class GatewayRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public double Income { get; set; }

        public bool Mortgage { get; set; }

        public int Amount { get; set; }
    }

    public class QuoteRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public double Income { get; set; }

        public bool Mortgage { get; set; }
    }

    public class ApplicantRequest
    {
        public int Amount { get; set; }
    }
}