namespace fake
{
    public class GetSearchResultResponse
    {
        private RefinementsModel refinements;
        private Filters searchRequest;

        public RefinementsModel getRefinements()
        {
            return refinements;
        }
        public void setRefinements(RefinementsModel value)
        {
            refinements = value;
        }

        public Filters getSearchRequest()
        {
            return searchRequest;
        }
        public void setSearchRequest(Filters value)
        {
            searchRequest = value;
        }
    }
}
