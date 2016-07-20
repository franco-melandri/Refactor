using System;

namespace fake
{
    public class ObjectMapper
    {
        // TODO to be removed when Franco adds attributes to SearchRequest
        public void fillAttributes(GetSearchResultResponse catalog)
        {
            if (catalog.getRefinements() != null)
            {
                if (catalog.getRefinements().getFilters() != null)
                {
                    foreach (DynamicAttribute a in catalog.getRefinements().getFilters().getAttributes())
                    {
                        if (a.isSelected())
                        {
                            String code = a.getCode();
                            foreach (DynamicAttribute aa in a.getAttributes())
                            {
                                if (!aa.getAttributes().isEmpty())
                                {
                                    foreach (DynamicAttribute aaa in aa.getAttributes())
                                    {
                                        if (aaa != null)
                                        {
                                            if (aaa.isSelected())
                                            {
                                                catalog.getSearchRequest().addValueToAttribute(code, aaa.getCode());
                                            }
                                        }
                                    }
                                }

                                if (aa.isSelected())
                                {
                                    catalog.getSearchRequest().addValueToAttribute(code, aa.getCode());
                                }
                            }

                            // Check Refinements attributes under "ctgr" Attributes
                            if (code == Filters.FILTER_CODE_CATEGORY)
                            {
                                if (a.getRefinements() != null && !a.getRefinements().isEmpty())
                                {
                                    foreach (DynamicAttribute ar in a.getRefinements())
                                    {
                                        code = ar.getCode();
                                        if (!ar.getAttributes().isEmpty())
                                        {
                                            foreach (DynamicAttribute aar in ar.getAttributes())
                                            {
                                                if (aar != null)
                                                {
                                                    if (aar.isSelected())
                                                    {
                                                        catalog.getSearchRequest()
                                                            .addValueToAttribute(code, aar.getCode());
                                                    }
                                                }
                                            }
                                        }
                                        if (ar.isSelected())
                                        {
                                            catalog.getSearchRequest().addValueToAttribute(code,
                                                ar.getCode());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void fillAttributesRefactored(GetSearchResultResponse catalog)
        {
            if (catalog.getRefinements() == null) return;

            if (catalog.getRefinements().getFilters() == null) return;


            var dynamicAttributes = catalog.getRefinements().getFilters().getAttributes();
            if (dynamicAttributes == null) return;

            var searchRequest = catalog.getSearchRequest();

            foreach (DynamicAttribute a in dynamicAttributes)
            {
                if (a.getAttributes() == null) continue;

                if (!a.isSelected()) continue;

                String code = a.getCode();
                foreach (DynamicAttribute aa in a.getAttributes())
                {
                    if (aa.getAttributes() == null) continue;

                    foreach (DynamicAttribute aaa in aa.getAttributes())
                    {
                        if (aaa.isSelected())
                        {
                            searchRequest.addValueToAttribute(code, aaa.getCode());
                        }
                    }

                    if (aa.isSelected())
                    {
                        searchRequest.addValueToAttribute(code, aa.getCode());
                    }
                }

                // Check Refinements attributes under "ctgr" Attributes
                if (code == Filters.FILTER_CODE_CATEGORY)
                {
                    if (a.getRefinements() == null) continue;

                    foreach (DynamicAttribute ar in a.getRefinements())
                    {
                        code = ar.getCode();

                        var attributes = ar.getAttributes();
                        
                        if (attributes == null) continue;

                        foreach (DynamicAttribute aar in attributes)
                        {
                            if (aar.isSelected())
                            {
                                searchRequest
                                    .addValueToAttribute(code, aar.getCode());
                            }
                        }
                        if (ar.isSelected())
                        {
                            searchRequest.addValueToAttribute(code,
                                ar.getCode());
                        }
                    }
                }
            }
        }
    }
}
