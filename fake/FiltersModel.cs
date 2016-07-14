using System.Collections.Generic;

namespace fake
{
    public class FiltersModel
    {
        public List<DynamicAttribute> attributes { get; set; }

        public FiltersModel()
        {
            attributes = new List<DynamicAttribute>();
        }

        public List<DynamicAttribute> getAttributes()
        {
            return attributes;
        }
    }
}