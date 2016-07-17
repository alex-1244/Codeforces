using System;
using System.Collections.Generic;
using System.Linq;

namespace _476B
{
    class Program
    {
        static void Main(string[] args)
        {
            string actual = Console.ReadLine();
            string received = Console.ReadLine();

            actual = actual.Replace("+-", ""); //delete +- and -+ because they doon't change anything
            actual = actual.Replace("-+", "");
            received = received.Replace("+-", "");
            received = received.Replace("-+", "");

            int actualNumber = CountActual(actual);

            List<int> receivedVariants = CountReceivedVariants(received);

            double probability = CountProbability(actualNumber, receivedVariants);
            Console.Write(String.Format("{0:0.000000000000}", probability));
            //Console.ReadKey();
        }

        private static double CountProbability(int actualNumber, List<int> receivedVariants)
        {
            int occurancesOfActual = 0;
            receivedVariants.ForEach(x => { if (x == actualNumber) occurancesOfActual++; });

            double probability = (double)occurancesOfActual / (double)receivedVariants.Count;
            return probability;
        }

        private static List<int> CountReceivedVariants(string received)
        {
            List<int> variants = new List<int>() { 0 };
            foreach (char command in received)
            {
                if (command == '+')
                    variants = variants.incrementAll();
                else if (command == '-')
                    variants = variants.decrementAll();
                else if (command == '?')
                    variants = variants.addNewVariants();
            }
            return variants;
        }

        private static int CountActual(string actual)
        {
            int actualNumber = 0;
            foreach (char command in actual)
            {
                if (command == '+')
                    actualNumber++;
                else
                    actualNumber--;
            }
            return actualNumber;
        }
    }
    static class Extensionsd
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
