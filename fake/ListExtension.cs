using System.Collections.Generic;

namespace fake
{
    static class ListExtension
    {
        public static bool isEmpty(this List<DynamicAttribute> list)
        {
            return list.Count == 0;
        }
    }
}
