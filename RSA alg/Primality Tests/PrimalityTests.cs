using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{
    static class PrimalityTests
    {
        //static public bool FermatTest(BigNumber n, int k)
        //{
        //    if (n % 2 == 0)
        //        return false;
        //    for (int i = 0; i < k; i++)
        //    {
        //        BigNumber a = GenerateNumber.GenerateBigNumber(n.ToString().Length - 1);
        //        if (BigNumber.PowMod(a, n - 1, n) != 1) return false;
        //    }
        //    return true;
        //}
        static public bool MillerRabinTest(BigInteger _n, int k)
        {
            BigInteger n = _n;
            if (n % 2 == 0)
                return false;
            BigInteger t = n - 1;   // представим n − 1 в виде (2^s)·t, где t нечётно, это можно сделать последовательным делением n - 1 на 2
            int s = 0;
            while (t % 2 == 0)
            {
                t = t / 2;
                s += 1;
            }
            for (int i = 0; i < k; i++)
            {
                // выберем случайное целое число a в отрезке [2, n − 2]
                BigInteger a = GenerateNumber.GenerateBigNumber(n.ToString().Length-1);
                if (GetNOD(a, n) > 1) return false;
                BigInteger x = BigInteger.ModPow(a, t, n);
                if (x == 1 || x == n - 1)
                    continue;
                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, n);
                    if (x == 1)
                        return false;
                    if (x == n - 1)
                        break;
                }
                if (x != n - 1)
                    return false;
            }
            // вернуть "вероятно простое"
            return true;
        }


        //static public bool SolovayStrassenTest(BigNumber n, int k)
        //{
        //    for (int i = 0; i < k; i++)
        //    {
        //        BigNumber a = GenerateNumber.GenerateBigNumber(n.ToString().Length - 1);
        //        if (GetNOD(a, n) > 1) return false;
        //        BigNumber r = Jacobi(a, n);
        //        BigNumber tmp = (n - 1) / 2;
        //        r = r % n;
        //        if (r == 0 || BigNumber.PowMod(a, tmp, n) != r % n) return false;
        //    }
        //    return true;
        //}

        public static BigInteger GetNOD(BigInteger a, BigInteger b)
        {
            if (b == 0)
                return a;
            return GetNOD(b, a % b);
        }

        /// <summary>
        /// нахождение символа Якоби
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_b"></param>
        /// <returns></returns>
        //static public BigNumber Jacobi(BigNumber _a, BigNumber _b)
        //{
        //    BigNumber a = new BigNumber(_a);
        //    BigNumber b = new BigNumber(_b);
        //    int r = 1;
        //    while (a != 0)
        //    {
        //        int t = 0;
        //        while (a % 2 == 0)//если а-четное
        //        {
        //            t++;
        //            a = a / 2;
        //        }
        //        if ((t & 1) != 0)//если t-нечетное
        //        {
        //            BigNumber temp = b.Mod(8);
        //            if (temp == 3 || temp == 5)
        //            {
        //                r = -r;
        //            }
        //        }
        //        BigNumber a4 = a.Mod(4), b4 = b.Mod(4);
        //        if (a4 == 3 && b4 == 3)
        //        {
        //            r = -r;
        //        }
        //        BigNumber c = new BigNumber(a);//c=a
        //        a = b % c;
        //        b = new BigNumber(c);
        //    }
        //    return new BigNumber(r.ToString());
        //}

    }
}
