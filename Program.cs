using System;
using System.Linq;
using System.Collections.Generic;

namespace GenerateGoodRandamNumber
{
    class Program
    {
        private static readonly int RICHITR = 5;
        private static readonly int ITRNUM = 10000;

        public static int GeneratGoodRandamNumbers(int itrNum)
        {
            if(itrNum < 0) return 0;

            int richRand = 0;
            Random geneRand = new Random();
            for(int i = 0; i <= itrNum; ++i)
            {
                richRand += geneRand.Next(1, 11);
            }
            return richRand / itrNum;
        }
        public static void GoodRandamNumber(int itrNum)
        {
            Random geneRand = new Random();
            List<int> randNumList = new List<int>();
            var randNumArray = Enumerable.Range(0, itrNum).Select(rand => GeneratGoodRandamNumbers(RICHITR)).ToArray();
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
