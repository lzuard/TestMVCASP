using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Infrastructure.Utils
{
    public static class Helpers
    {
        public static bool NullableEquals<T>(T item1, T? item2) where T : struct
        {
            if (item2 == null)
            {
                return true;
            }

            return item1.Equals(item2);
        }

        public static bool NullableEquals<T>(T item1, T item2) where T : new()
        {
            if (item2 == null)
            {
                return true;
            }

            return item1.Equals(item2);
        }
        
        public static bool NullableEquals(string item1, string  item2) 
        {
            if (item2 == null)
            {
                return true;
            }

            return item1.Equals(item2);
        }
    }
}