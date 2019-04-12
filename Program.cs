using System;
using System.Linq;
using System.Collections.Generic;

namespace GenerateGoodRandamNumber
{
    class Program
    {
        // private static readonly int RICHITR = 5;
        private static readonly int ITRNUM = 10000;

        public static List<int> GeneratStairBiasRandamNumbers(int itrNum)
        {
            List<int> source = new List<int>() {1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 9, 10};
            List<int> randList = new List<int>();
            Random random = new Random();
            int randomIndex;
            int randomValue;

            for (int i = 0; i < itrNum; ++i)
            {
                randomIndex = random.Next(source.Count);
                randomValue = source[randomIndex];
                randList.Add(randomValue);
            }
            return randList;
        }
        public static int GeneratGoodRandamNumbers(int itrNum)
        {
            if(itrNum < 0) return 0;

            int richRand = 0;
            int itrNumLower = 0;
            int itrNumUpper = 0;
            itrNumLower = itrNum / 2;
            itrNumUpper = itrNumLower;
            Random geneRand = new Random();
            for(int i = 0; i <= itrNumLower; ++i)
            {
                richRand += geneRand.Next(1, 3);
            }
            for(int i = 0; i <= itrNumUpper; ++i)
            {
                richRand += geneRand.Next(1, 11);
            }
            return richRand / itrNum;
        }
        public static void GoodRandamNumber(int itrNum)
        {
            Random geneRand = new Random();
            List<int> randNumList = new List<int>();
            // var randNumArray = Enumerable.Range(0, itrNum).Select(rand => GeneratGoodRandamNumbers(RICHITR)).ToArray();
            var randNumArray = GeneratStairBiasRandamNumbers(itrNum).ToArray();
            var richRandNum = Enumerable.Range(1, 10).Select(index => randNumArray.Count(n => n == index)).ToArray();
            for(int i = 1; i < richRandNum.Length; ++i)
            {
                Console.WriteLine("Number " + i + " is " + richRandNum[i]);
            }
        }
        static void Main(string[] args)
        {
            GoodRandamNumber(ITRNUM);
        }
    }
}
