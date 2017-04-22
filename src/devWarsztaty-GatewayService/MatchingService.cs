namespace devWarsztaty_GatewayService
{
    public class MatchingResponse
    {
        public int AmountRequested { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal Apr { get; set; }

        public decimal MonthlyRepaymentAmount { get; set; }
    }

    public class MatchingService
    {
        public MatchingResponse GetMatching(QuoteRequest quoteRequest)
        {
            return new MatchingResponse();
        }
    }
}