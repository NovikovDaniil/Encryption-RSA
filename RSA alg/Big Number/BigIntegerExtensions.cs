using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{

    /// <summary>
    /// расширение на перевод в 2сс из 10сс и в 10сс из 2сс
    /// </summary>
    public static class BigIntegerExtensions
    {
        ///<summary>
        ///перевод из 2 системы счисления в десятичное число
        /// </summary>
        static public BigInteger FromBase2ToBigInteger(this BigInteger number, string num)
        {
            BigInteger current = 1, result = 0;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == '1')
                    result += current;
                current = current * 2;
            }
            return result;
        }

        /// <summary>
        /// перевод в 2сс
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static public string FromBigNumberToBase2(this BigInteger num)
        {
            BigInteger number = num;
            StringBuilder base2 = new StringBuilder();
            while (number != 0)
            {
                base2.Append((number % 2).ToString());
                number = number / 2;
            }
            return new string(base2.ToString().Reverse().ToArray());
        }
    }
}
