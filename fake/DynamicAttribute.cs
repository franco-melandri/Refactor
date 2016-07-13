using System.Collections.Generic;

namespace fake
{
    public class DynamicAttribute
    {
        private bool selected;
        private string code;
        private List<DynamicAttribute> attributes;
        private List<DynamicAttribute> refinements;

        public bool isSelected()
        {
            return selected;
        }
        public void setSelected(bool value)
        {
            selected = value;
        } 

        public string getCode()
        {
            return code;
        }
        public void getCode(string value)
        {
            code = value;
        }

        public List<DynamicAttribute> getAttributes()
        {
            return attributes;
        }
        public void getAttributes(List<DynamicAttribute> value)
        {
            attributes = value;
        }

        public List<DynamicAttribute> getRefinements()
        {
            return refinements;
        }
        public void setRefinements(List<DynamicAttribute> value)
        {
            refinements = value;
        }

    }
}