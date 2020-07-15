using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{
    static class EncryptionRSA
    {

        /// <summary>
        /// метод нахождения размера блока(количество байтов)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static private int FindLengthBlocks(BigInteger n)
        {
            BigInteger a = 256;
            int k = 1;
            while (BigInteger.Pow(a, k) < n)
                ++k;
            --k;
            return k;//заполняю блоки размером в половину, потому что они после шифрования могут увеличиваться, в оставшееся место буду дописывать нули
        }

        /// <summary>
        /// метод нахождения числа из заданного количества байтов
        /// </summary>
        /// <param name="text"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static private BigInteger FindBigNumberForEncryption(byte[] text, int start, int end)
        {
            StringBuilder result = new StringBuilder();
            if (end >= text.Length) end = text.Length;
            for (int i = start; i < end; i++)
            {
                string tmp = Convert.ToString(text[i], 2).PadLeft(8, '0');//переводим в 2 сс
                result.Append(tmp);//добавляем к результату
            }
            BigInteger resultNumber = 0;
            return resultNumber.FromBase2ToBigInteger(result.ToString());
        }

        /// <summary>
        /// метод перевода зашифрованного большого числа в
        /// двочиную систему и извлечения байтов с целью записи файл
        /// извлеченные байты-часть зашифрованного сообщения
        /// </summary>
        /// <param name="bigNumber"></param>
        /// <param name="sizeBlock"></param>
        /// <returns></returns>
        static private string EncryptBigNumberForEachBlock(BigInteger bigNumber, int sizeBlock)
        {
            string number = bigNumber.FromBigNumberToBase2();//переводим большое число в 2 сс
            StringBuilder text = new StringBuilder();
            int start, count = 8;//позиция начала 7 бит
            for (int i = number.Length - 1; i > 0; i -= count)
            {
                if (i - count + 1 < 0)//если осталось меньше 8 бит, то считываем оставшиеся
                {
                    start = 0;
                    count = i + 1;
                }
                else
                    start = i - count + 1;
                text.Append(Convert.ToChar(Convert.ToInt32(number.Substring(start, count), 2)));//преобразуем каждые 8 бит в 10сс и букву с таким номером
            }
            if (text.Length < sizeBlock + 1)//если количество байтов меньше чем размер блока+1, то дополняем, чтобы мы могли спокойно расшифровать
                text.Insert(0, '\0');
            return text.ToString();
        }

        /// <summary>
        /// метод шифрования массива байтов
        /// выбирается блок и шифруется отдельно, после чего записывается в результирующую строку
        /// </summary>
        /// <param name="text"></param>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static public string Encrypt(byte[] text, BigInteger e, BigInteger n)
        {
            int k = FindLengthBlocks(n);    //находим длину блока для шифрования
            BigInteger encryptSymbol;   //зашифрованный символ
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < text.Length; i += k)    //шифруем по каждому блоку
            {
                BigInteger tmp = FindBigNumberForEncryption(text, i, i + k);    //блок байтов представляем в виде числа
                encryptSymbol = BigInteger.ModPow(tmp, e, n);   //шифруем это число
                result.Append(EncryptBigNumberForEachBlock(encryptSymbol, k));
            }
            return result.ToString();
        }
    }
}
