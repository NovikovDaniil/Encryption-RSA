using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{
    static class GenerateNumber
    {
        static Random rand=new Random();

        /// <summary>
        /// Генератор псевдослучайных чисел с помощью
        /// метода Фибоначчи с запаздываниями
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        static public BigInteger GenerateBigNumber(int size)//метод фибоначчи с запаздываниями
        {
            int mod = 10, a = 17, b = 5;//a,b-запаздывания
            StringBuilder num = new StringBuilder();
            if (size > Math.Max(a, b))
            {
                for (int i = 0; i < Math.Max(a, b); i++)//генерируем начальное состояние, из которого будем находить цифры для случайного числа
                    num.Append(rand.Next(10).ToString());
                for (int i = Math.Max(a, b); i < size; i++)
                    num.Append((Convert.ToInt32(num[i - a]) + Convert.ToInt32((num[i - b]))) % mod);
            }
            else
            {
                for (int i = 0; i < size; i++)//генерируем начальное состояние, из которого будем находить цифры для случайного числа
                    num.Append(rand.Next(10).ToString());

            }
            BigInteger newNumber = BigInteger.Parse(num.ToString());
            while (newNumber % 2 == 0 || newNumber % 5 == 0)
                ++newNumber;

            return newNumber;
        }


        /// <summary>
        /// Генератор простых чисел, которые проходят проверку
        /// используемого алгоритма
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        static public BigInteger GeneratePrimeNumber(int size)
        {
            BigInteger s = GenerateBigNumber(size);
            while (!PrimalityTests.MillerRabinTest(s, 5))
            {
                s = GenerateBigNumber(size);
            }
            return s;
        }
    }
}
