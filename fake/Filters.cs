﻿using System.Collections.Generic;

namespace fake
{
    public class Filters
    {
        public static string FILTER_CODE_CATEGORY = "ctgr";

        private Dictionary<string, List<string>> attributes;

        public Filters()
        {
            attributes = new Dictionary<string, List<string>>();
        }

        public Dictionary<string, List<string>> getAttributes()
        {
            return attributes;
        }
        public void getAttributes(Dictionary<string, List<string>> value)
        {
            attributes = value;
        }


        public void addValueToAttribute(string attributeName, string value)
        {
            if (attributes.ContainsKey(attributeName))
            {
                if (!attributes[attributeName].Contains(value))
                {
                    attributes[attributeName].Add(value);
                }
            }
            else
            {
                var values = new List<string>
                {
                    value
                };
                attributes.Add(attributeName, values);
            }
        }
    }
}