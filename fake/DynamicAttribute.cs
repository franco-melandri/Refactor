using System.Collections.Generic;

namespace fake
{
    public class DynamicAttribute
    {
        public bool selected { get; set; }
        public string code { get; set; }
        public List<DynamicAttribute> attributes { get; set; }
        public List<DynamicAttribute> refinements { get; set; }

        public DynamicAttribute()
        {
            attributes = new List<DynamicAttribute>();
            refinements = new List<DynamicAttribute>();
        }

        public DynamicAttribute(bool selected, string code)
            : this()
        {
            this.selected = selected;
            this.code = code;
        }

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

        public List<DynamicAttribute> getRefinements()
        {
            return refinements;
        }
    }
}