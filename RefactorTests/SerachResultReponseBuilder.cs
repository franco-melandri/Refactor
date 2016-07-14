using System.Linq;
using fake;

namespace RefactorTests
{
    public class SerachResultReponseBuilder
    {
        private GetSearchResultResponse response;

        private SerachResultReponseBuilder()
        {
            response = new GetSearchResultResponse();
        }

        public static SerachResultReponseBuilder Create()
        {
            return new SerachResultReponseBuilder();
        }

        public SerachResultReponseBuilder AddFilterAttribute(string code, bool selected)
        {
            response
                .getRefinements()
                    .getFilters()
                        .getAttributes()
                            .Add(new DynamicAttribute(selected, code));
            return this;
        }

        public SerachResultReponseBuilder AddFilterAttributeInner(string parent, string code, bool selected)
        {
            var att = response
                    .getRefinements()
                        .getFilters()
                            .getAttributes()
                                .FirstOrDefault(a => a.code == parent);
            if (att != null)
            {
                att
                    .getAttributes()
                        .Add(new DynamicAttribute(selected, code));
            }
            return this;
        }

        public SerachResultReponseBuilder AddFilterRefinement(string parent, string code, bool selected)
        {
            var att = response
                    .getRefinements()
                        .getFilters()
                            .getAttributes()
                                .FirstOrDefault(a => a.code == parent);
            if (att != null)
            {
                att
                    .getRefinements()
                        .Add(new DynamicAttribute(selected, code));
            }
            return this;
        }

        public SerachResultReponseBuilder AddFilterRefinementInner(string parentAtt, string parent,  string code, bool selected)
        {
            var att = response
                    .getRefinements()
                        .getFilters()
                            .getAttributes()
                                .FirstOrDefault(a => a.code == parentAtt);
            if (att != null)
            {
                var refinment = att
                            .getRefinements()
                                .FirstOrDefault(a => a.code == parent);
                if (refinment != null)
                    refinment
                        .getAttributes()
                            .Add(new DynamicAttribute(selected, code));
            }
            return this;
        }

        public GetSearchResultResponse Build()
        {
            return response;
        }
    }
}