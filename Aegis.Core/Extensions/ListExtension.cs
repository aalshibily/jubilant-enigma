using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aegis.Core.Extensions
{
    public static class ListExtension
    {
        public static bool AddUnique<T>(this List<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            }

            return false;
        }
        public static bool AddUniques<T>(this List<T> list, List<T> items)
        {
            var originalSize = list.Count;
            var uniques = items.Where(item => !list.Contains(item)).ToList();
            
            list.AddRange(uniques);

            return list.Count > originalSize;
        }
    }
}
