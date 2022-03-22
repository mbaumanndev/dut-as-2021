using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBaumann.IUT.TriBulle.Algos
{
    public class TriBulle
    {
        public static IEnumerable<T>
            Run<T>(IEnumerable<T> input)
            where T : IComparable<T>
        {
            T[] temp = input.ToArray();

            for (int i = temp.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    // temp[j + 1] < temp[j]
                    if (temp[j + 1].CompareTo(temp[j]) < 0)
                    {
                        (temp[j + 1], temp[j]) = (temp[j], temp[j + 1]);
                    }
                }
            }

            return temp;
        }
    }
}
