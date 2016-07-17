using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _476B.Extensions
{
    static class Extensions1
    {
        public static List<int> incrementAll(this List<int> list)
        {
            return list.Select(x => x + 1).ToList();
        }

        public static List<int> decrementAll(this List<int> list)
        {
            return list.Select(x => x - 1).ToList();
        }

        public static List<int> addNewVariants(this List<int> list)
        {
            List<int> newVariants = new List<int>();
            int initialLength = list.Count;
            for (int i = 0; i < initialLength; i++)
            {
                newVariants.Add(list[i] + 1);
                list[i]--;
            }
            list.AddRange(newVariants);
            return list;
        }
    }
}
