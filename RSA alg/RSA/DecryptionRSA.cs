using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{
    static class DecryptionRSA
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
        /// метод нахождения байтов из блока(большого числа)
        /// </summary>
        /// <param name="block"></param>
        /// <returns></returns>
        static private List<byte> GetBytesStartMessage(BigInteger block)//передаем расшифрованный блок
        {
            string blockOnBase2 = block.FromBigNumberToBase2();//переводим в 2сс для выделения байтов
            List<byte> bytes = new List<byte>();
            int start = 0, count = 8;//считываем 8 бит
            for (int i = blockOnBase2.Length - 1; i >= 0; i -= count)
            {
                if (i - count + 1 < 0)
                {
                    start = 0;
                    count = i + 1;
                }
                else
                    start = i - count + 1;
                byte tmp = Convert.ToByte(blockOnBase2.Substring(start, count), 2);
                if (tmp != 0)
                    bytes.Add(tmp);
            }
            bytes.Reverse();
            return bytes;
        }

        /// <summary>
        /// метод нахождения большого числа из блока определенным размером
        /// </summary>
        /// <param name="text"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static private BigInteger FindBigNumberForEncryption(string text, int start, int end)
        {
            StringBuilder result = new StringBuilder();
            if (end >= text.Length) end = text.Length;
            for (int i = end - 1; i >= start; i--)
            {

                string tmp = Convert.ToString(text[i], 2).PadLeft(8, '0');  //переводим в 2 сс
                if (i != start || tmp != "00000000") //если в самом начале нет фиктивного нуля, то добавляем, иначе просто его игнорируем
                    result.Append(tmp); //добавляем к результату
            }
            BigInteger resultNumber = 0;
            return resultNumber.FromBase2ToBigInteger(result.ToString());
        }

        /// <summary>
        /// метод дешифрования.
        /// подается зашифрованный текст, после чего разбивается на блоки
        /// каждый блок дешифруется, и из него извлекаются байты - 
        /// будущие символы исходного сообщения
        /// </summary>
        /// <param name="text"></param>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns>
        /// исходное сообщение-массив байтов
        /// </returns>
        static public byte[] Decrypt(string text, BigInteger d, BigInteger n)
        {
            List<byte> allBytesMessage = new List<byte>();
            int k = FindLengthBlocks(n) + 1;//берем длину блока на один больше
            for (int i = 0; i < text.Length; i += k)
            {
                BigInteger encBlock = FindBigNumberForEncryption(text, i, i + k);
                BigInteger decBlock = BigInteger.ModPow(encBlock, d, n);//расшифрованный блок
                allBytesMessage.AddRange(GetBytesStartMessage(decBlock));
            }
            return allBytesMessage.ToArray();
        }
    }
}
