namespace fake
{
    public class RefinementsModel
    {
        public FiltersModel filters { get; set; }

        public RefinementsModel()
        {
            filters = new FiltersModel();
        }

        public FiltersModel getFilters()
        {
            return filters;
        }
    }
}