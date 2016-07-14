namespace fake
{
    public class GetSearchResultResponse
    {
        public RefinementsModel refinements { get; set; }
        public Filters searchRequest { get; set; }

        public GetSearchResultResponse()
        {
            refinements = new RefinementsModel();
            searchRequest = new Filters();
        }

        public RefinementsModel getRefinements()
        {
            return refinements;
        }

        public Filters getSearchRequest()
        {
            return searchRequest;
        }
    }
}
