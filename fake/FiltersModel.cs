using System.Collections.Generic;

namespace fake
{
    public class FiltersModel
    {
        private List<DynamicAttribute> attributes;

        public List<DynamicAttribute> getAttributes()
        {
            return attributes;
        }
        public void getAttributes(List<DynamicAttribute> value)
        {
            attributes = value;
        }
    }
}