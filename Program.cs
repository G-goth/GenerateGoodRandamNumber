using System;
using System.Linq;
using System.Collections.Generic;

namespace GenerateGoodRandamNumber
{
    class Program
    {
        // private static readonly int RICHITR = 5;
        private static readonly int ITRNUM = 10000;

        // 好きな偏り方の乱数を作るためのリストを返す
        public static List<int> OneselfGeneratStairBiasRandamNumbers(int repeatCount, int num)
        {
            List<int> selfSource = new List<int>();
            selfSource = Enumerable.Repeat(num, repeatCount).ToList();
            return selfSource;
        }
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
        // List<int>を渡すバージョン
        public static List<int> GeneratStairBiasRandamNumbers(int itrNum, List<int> seedList)
        {
            List<int> source = seedList;
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
            for(int i = 0; i < richRandNum.Length; ++i)
            {
                Console.WriteLine("Number " + (i + 1) + " is " + richRandNum[i]);
            }
        }
        public static void GoodRandamNumber(int itrNum, List<int> seedList)
        {
            Random geneRand = new Random();
            List<int> randNumList = new List<int>();
            // var randNumArray = Enumerable.Range(0, itrNum).Select(rand => GeneratGoodRandamNumbers(RICHITR)).ToArray();
            var randNumArray = GeneratStairBiasRandamNumbers(itrNum, seedList).ToArray();
            var richRandNum = Enumerable.Range(1, 5).Select(index => randNumArray.Count(n => n == index)).ToArray();
            for(int i = 0; i < richRandNum.Length; ++i)
            {
                Console.WriteLine("Number " + (i + 1) + " is " + richRandNum[i]);
            }
        }
        static void Main(string[] args)
        {
            // GoodRandamNumber(ITRNUM);
            List<int> seedList = new List<int>();
            seedList.AddRange(OneselfGeneratStairBiasRandamNumbers(50, 1));
            seedList.AddRange(OneselfGeneratStairBiasRandamNumbers(25, 2));
            seedList.AddRange(OneselfGeneratStairBiasRandamNumbers(15, 3));
            seedList.AddRange(OneselfGeneratStairBiasRandamNumbers(8, 4));
            seedList.AddRange(OneselfGeneratStairBiasRandamNumbers(2, 5));
            GoodRandamNumber(ITRNUM, seedList);
        }
    }
}