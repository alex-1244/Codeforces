using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _371A
{
    class Program
    {
        static void Main(string[] args)
        {
            string arguments = Console.ReadLine();
            int arraySize, period;
            getNumOfArguments(arguments, out arraySize, out period);
            int[] array = getArray(arraySize, Console.ReadLine());
            int totalNumOfChanges = 0;
            for(int i = 0; i < period; i++)
            {
                totalNumOfChanges += getMinimalNumOfChanges(period, i, array);
            }
            Console.WriteLine(totalNumOfChanges);
        }

        private static int getMinimalNumOfChanges(int period, int offset, int[] array)
        {
            int periodLen = array.Length / period;
            int numOfOnes = 0;
            int numOfTwos = 0;
            for(int i = 0; i < periodLen; i++)
            {
                if (array[offset + period * i] == 1)
                    numOfOnes += 1;
                else
                    numOfTwos += 1;
            }
            return Math.Min(numOfOnes, numOfTwos);
        }

        private static int[] getArray(int arraySize, string v)
        {
            int[] array = Array.ConvertAll(v.Split(' '), s => int.Parse(s)); ;
            return array;
        }

        private static void getNumOfArguments(string args, out int arraySize, out int period)
        {
            string[] inputsArr = args.Split(' ');
            arraySize = Int32.Parse(inputsArr[0]);
            period = Int32.Parse(inputsArr[1]);
        }
    }
}
