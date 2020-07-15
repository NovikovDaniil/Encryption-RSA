using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_alg
{

    /// <summary>
    /// Класс для больших чисел
    /// в данной работе не используется по причине использования BigInteger
    /// </summary>
    class BigNumber
    {
        int size;//число ячеек под число
        int[] data;//число
        int len = 4;//4 цифры будет в одной яейке массива
        int basis = 10000;//поэтому основание это 10000
        bool minus;//отрицательное или нет

        /// <summary>
        /// конструктор без параметров
        /// </summary>
        public BigNumber()
        {
            size = 0;
            data = null;
            minus = false;
        }

        /// <summary>
        /// конструктор, который выделяет память под число длины length
        /// </summary>
        /// <param name="length"></param>
        public BigNumber(int length)
        {
            if (length % len == 0)//находим количество блоков, в каждом из которых будет 4 цифры
                size = length / len;
            else size = length / len + 1;
            data = new int[size];//идет автоматическое заполнение нулями
            minus = false;
        }

        /// <summary>
        /// конструктор задания числа из строки
        /// </summary>
        /// <param name="input"></param>
        public BigNumber(string input)
        {
            if (input.Length % 4 == 0)
                size = input.Length / 4;
            else size = input.Length / 4 + 1;
            data = new int[size];
            int j = 0;//номер ячейки, куда записывать
            if (input[0] == '-')
            {
                minus = true;
                input = input.Remove(0, 1);
            }
            else minus = false;
            for (int i = input.Length - 1; i >= 0; i -= len)
            {
                int begin = ((i - len + 1) > 0) ? i - len + 1 : 0;//позиция начала блока из 4 цифр
                int end = i - begin + 1;//позиция нконца блока из 4 цифр
                data[j++] = int.Parse(input.Substring(begin, end));
            }

        }
        /// <summary>
        /// констурктор копирования
        /// </summary>
        /// <param name="other"></param>
        public BigNumber(BigNumber other)
        {
            size = other.size;
            data = new int[size];
            Array.Copy(other.data, 0, data, 0, size);
            minus = other.minus;
        }

        /// <summary>
        /// функция для присвоения BigNumber числу число типа int
        /// В основном функция нужна для шифрования, когда 
        /// считываем код ASCII символа
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public BigNumber Set(int a)
        {
            return new BigNumber(a.ToString());
        }

        /// <summary>
        /// перегрузка индексатора
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }

        public int Base => basis;
        public int Size => size;
        
        /// <summary>
        /// функция для сложения чисел a и b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static BigNumber Add(BigNumber a, BigNumber b)
        {
            BigNumber result = new BigNumber(4 * (Math.Max(a.size, b.size) + 1));//выделяем первоначальную память под получившееся число
            int temp = 0;

            ///<summary>
            ///для уменьшения объема кода используем локальную функцию,
            ///которая выполняет процесс, который происходит в 
            ///каждом условии
            ///</summary>
            void AdditionNumberSameSize(int size)
            {
                for (int i = 0; i < size; i++)
                {
                    if (a[i] + b[i] < a.basis)//если переноса не будет
                    {
                        result[i] = a[i] + b[i] + temp;
                        temp = 0;
                    }
                    else//перенос
                    {
                        result[i] = a[i] + b[i] + temp - a.basis;
                        temp = 1;
                    }
                }
            }

            if (a.Size == b.Size)//если числа одинакового размера
            {
                AdditionNumberSameSize(a.Size);
                result[a.Size] += temp;
            }
            else
            {
                if (a.Size > b.Size)
                {

                    AdditionNumberSameSize(b.Size);
                   
                    for (int i = b.Size; i < a.Size; i++)//дописываем оставшиеся разряды
                    {
                        result[i] = a[i] + temp;
                        if (result[i] >= a.basis)
                        {
                            result[i] -= a.basis;
                            temp = 1;
                        }
                        else
                            temp = 0;
                    }
                    result[a.Size] += temp;
                }
                if (a.Size < b.Size)
                {
                    AdditionNumberSameSize(a.Size);
                    
                    for (int i = a.Size; i < b.Size; i++)
                    {
                        result[i] = b[i] + temp;
                        if (result[i] >= a.basis)
                        {
                            result[i] -= a.basis;
                            temp = 1;
                        }
                        else
                            temp = 0;
                    }
                    result[b.Size] += temp;
                }
            }
            result.RemoveLeadingZeroes();
            return result;
        }
        public static BigNumber operator +(BigNumber a, BigNumber b)
        {
            BigNumber result;
            if (a.minus && b.minus)
            {
                result = Add(a, b);
                result.minus = true;
                return result;
            }
            else if (a.minus)
            {
                if (a > b)
                {
                    result = Substraction(a, b);
                    result.minus = true;
                }
                else result = Substraction(b, a);
                return result;
            }
            else if (b.minus)
            {
                if (a < b)
                {
                    result = Substraction(b, a);
                    result.minus = true;
                }
                else result = Substraction(a, b);
                return result;
            }
            result = Add(a, b);
            result.minus = false;
            return result;
        }

        /// <summary>
        ///функция для вычитания из a числа b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static BigNumber Substraction(BigNumber a, BigNumber b)
        {
            if (a == b)
            {
                return new BigNumber(1);//вовзращаем 0
            }
            BigNumber result = new BigNumber(a);
            result.minus = false;
            for (int i = 0; i < b.Size; i++)
            {
                result[i] -= b[i];
                if (result[i] < 0)
                {
                    result[i] += result.basis;
                    result[i + 1]--;
                }
            }
            if (result.Size > b.Size)
            {
                for (int i = b.Size; i < result.Size; i++)
                    if (result[i] < 0)
                    {
                        result[i] += result.basis;
                        result[i + 1]--;
                    }
            }
            result.RemoveLeadingZeroes();
            return result;
        }
        public static BigNumber operator -(BigNumber a, BigNumber b)
        {
            BigNumber result;
            if (a.minus && b.minus)
            {
                if (a > b)
                {
                    result = Substraction(a, b);
                    result.minus = true;
                }
                else
                    result = Substraction(b, a);
            }
            else if (a.minus)
            {
                result = Add(a, b);
                result.minus = true;
            }
            else if (b.minus)
            {
                result = Add(a, b);
            }
            else if (a < b)
            {
                result = Substraction(b, a);
                result.minus = true;
            }
            else result = Substraction(a, b);
            return result;
        }
        /// <summary>
        /// функция для прибавления к числу некоторого числа типа int
        /// </summary>
        /// <param name="a"></param>
        public void Inc(int a)
        {
            int i = 0;
            data[i] += a;
            while (data[i] >= basis)//если там лежало 9999
            {
                data[i] -= basis;
                data[i + 1] += 1;
                i += 1;
            }
        }
        /// <summary>
        /// Инкремент
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static BigNumber operator ++(BigNumber a)
        {
            BigNumber result = new BigNumber(a);
            int i = 0;
            result[i] += 1;
            while (result[i] == result.basis)//если там лежало 9999
            {
                result[i] = 0;
                result[i + 1] += 1;
                i += 1;
            }
            return result;
        }
        public static BigNumber operator -(BigNumber a, int b)
        {
            BigNumber result = new BigNumber(a);
            int i = 0;
            result[i] -= b;//вычитаем из младших разрядов
            while (result[i] < 0)//если разность получилась меньше 0, то занимаем из старших разрядов
            {
                result[i + 1] -= 1;
                result[i] += result.basis;
                ++i;
            }
            result.RemoveLeadingZeroes();
            return result;
        }

        /// <summary>
        /// Умножение столбиком
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static BigNumber operator *(BigNumber a, BigNumber b)
        {
            BigNumber c = new BigNumber(4 * (a.Size + b.Size));
            for (int i = 0; i < a.Size; i++)
            {
                int temp = 0;
                for (int j = 0; j < b.Size; j++)
                {
                    c[i + j] += a[i] * b[j] + temp;
                    temp = c[i + j] / a.basis;
                    c[i + j] -= a.basis * temp;
                }
                if (temp != 0)
                    c[i + b.Size] = temp;
            }
            c.minus = (a.minus ^ b.minus) ? true : false;
            c.RemoveLeadingZeroes();
            return c;
        }


        public static BigNumber operator *(BigNumber a, int b)
        {
            BigNumber result = new BigNumber(4 * a.size + 1);
            int tmp = 0;
            for(int i=0;i<a.size;i++)
            {
                result[i] += a[i] * b + tmp;
                tmp = result[i] / result.basis;
                result[i] -= result.basis * tmp;
            }
            if (tmp != 0)
                result[a.size] = tmp;
            result.RemoveLeadingZeroes();
            if (a.minus)
                result.minus = true;
            return result;
        }

        public static BigNumber operator /(BigNumber a, BigNumber b)//находим с помощью бинарного поиска
        {
            BigNumber result = new BigNumber(4 * a.Size + 1);
            BigNumber currentValue = new BigNumber(4 * b.Size);
            BigNumber remainder = new BigNumber(1);
            for (int i = a.Size - 1; i >= 0; i--)
            {
                remainder = remainder * a.basis;
                remainder[0] = a[i];
                int digit = 0;
                int low = 0;
                int high = result.basis;
                while (low <= high)
                {
                    int m = (low + high) >> 1;
                    currentValue = b * m;
                    if (currentValue <= remainder)
                    {
                        digit = m;
                        low = m + 1;
                    }
                    else
                        high = m - 1;
                }
                result[i] = digit;
                remainder = remainder - b * digit;
            }
            result.RemoveLeadingZeroes();
            result.minus = (a.minus ^ b.minus) ? true : false;
            return result;
        }

        public static BigNumber operator /(BigNumber a, int b)
        {
            BigNumber result = new BigNumber(4 * a.Size);
            int remainder = 0, tmp = 0;
            for (int i = a.Size - 1; i >= 0; i--)
            {
                tmp = a.basis * remainder + a[i];
                result[i] = tmp / b;
                remainder = tmp % b;
            }
            result.RemoveLeadingZeroes();
            if (a.minus) result.minus = true;
            return result;
        }

        public static BigNumber operator %(BigNumber a, BigNumber b)//вычисляем с помощью бинарного поиска
        {
           
            if (a < 0)//если число а меньше 0, то по правилам модульной арифметики прибавляем модуль
            {
                a = b + a;
            }
            if (a < b)
                return a;
            BigNumber currentValue = new BigNumber(b.Size);
            BigNumber remainder = new BigNumber(1);//remainder=0
            for (int i = a.Size - 1; i >= 0; i--)
            {
                remainder = remainder * a.basis;
                remainder[0] = a[i];
                int digit = 0;
                int low = 0;
                int high = a.basis;
                while (low <= high)
                {
                    int m = (low + high) >> 1;
                    currentValue = b * m;
                    if (currentValue <= remainder)
                    {
                        digit = m;
                        low = m + 1;
                    }
                    else
                        high = m - 1;
                }
                remainder = remainder - b * digit;
            }
            remainder.RemoveLeadingZeroes();
            remainder.minus = (a.minus ^ b.minus) ? true : false;
            return remainder;
        }

        /// <summary>
        /// функция %, но возвращает число BigNumber
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public BigNumber Mod(int b)
        {
            int remainder = 0, tmp = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                tmp = basis * remainder + data[i];
                remainder = tmp % b;
            }

            return new BigNumber(remainder.ToString());
        }

        public static int operator %(BigNumber a, int b)
        {
            int remainder = 0, tmp = 0;
            for (int i = a.Size - 1; i >= 0; i--)
            {
                tmp = a.basis * remainder + a[i];
                remainder = tmp % b;
            }
            return remainder;
        }
        /// <summary>
        /// Так как максимальная степень будет 2 в тесте Миллера-Рабина
        /// </summary>
        /// <param name="a"></param>
        /// <param name="_d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static BigNumber PowMod(BigNumber a, int _d, BigNumber n)
        {
            return (a * a) % n;
        }

        public static BigNumber Pow(BigNumber _a,int n)
        {
            BigNumber a = new BigNumber("1");
            for (int i = 1; i <= n; i++)
                a = a * _a;
            return a;
        }
        /// <summary>
        ///  быстрое возведение в степень по модулю
        /// </summary>
        /// <param name="_a"></param>
        /// <param name="_d"></param>
        /// <param name="_n"></param>
        /// <returns></returns>
        public static BigNumber PowMod(BigNumber _a, BigNumber _d, BigNumber _n)//a^d mod n
        {
            BigNumber a = new BigNumber(_a);
            BigNumber d = new BigNumber(_d);
            BigNumber n = new BigNumber(_n);
            BigNumber result = new BigNumber("1");//result=1
            while (d != 0)
            {
                if (d % 2 == 0)
                {
                    d = d / 2;
                    a = a * a;
                    a = a % n;
                }
                else
                {
                    d = d - 1;
                    result = result * a;
                    result = result % n;
                }
            }
            return result % n;
        }


        /// <summary>
        /// перевод в 2сс
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static public string FromBigNumberToBase2(BigNumber num)
        {
            BigNumber number = new BigNumber(num);
            StringBuilder base2 = new StringBuilder();
            while (number != 0)
            {
                base2.Append((number % 2).ToString());
                number = number / 2;
            }
            return new string(base2.ToString().Reverse().ToArray());
        }


        ///<summary>
        ///перевод из 2 системы счисления в десятичное число
        /// </summary>
        static public BigNumber FromBase2ToBigNumber(string num)
        {
            BigNumber current = new BigNumber("1");//будем проходить по каждому биту для перевода в 10сс
            BigNumber result = new BigNumber("0");//конечный результат
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] == '1')
                    result = result + current;
                current = current * 2;
            }
            return result;
        }
    
        public static bool operator >(BigNumber a, BigNumber b)
        {
            if (a.minus && !b.minus) return false;//если а-отрицательное, а b-нет
            else if (!a.minus && b.minus) return true;
            if (a.Size != b.Size)
                return a.Size > b.Size;
            for (int i = a.Size - 1; i >= 0; i--)
                if (a[i] != b[i])
                    return a[i] > b[i];
            return false;//в этом случае они получились равны
        }
        public static bool operator ==(BigNumber a, BigNumber other) => a.Equals(other);

        public static bool operator !=(BigNumber a, BigNumber b) => !(a == b);

        public static bool operator !=(BigNumber a, int _b)
        {
            BigNumber b = new BigNumber(_b.ToString());
            return a != b;
        }
        public static bool operator ==(BigNumber a, int _b)
        {
            BigNumber b = new BigNumber(_b.ToString());
            return a == b;
        }
        public static bool operator <(BigNumber a, int _b)
        {
            BigNumber b = new BigNumber(_b.ToString());
            return a < b;
        }
        public static bool operator >(BigNumber a, int _b)
        {
            BigNumber b = new BigNumber(_b.ToString());
            return a > b;
        }
        public static bool operator <(BigNumber a, BigNumber b) => b > a;

        public static bool operator <=(BigNumber a, BigNumber b) => !(a > b);
        public static bool operator >=(BigNumber a, BigNumber b) => !(b > a);
        public override string ToString()
        {
            StringBuilder number = new StringBuilder();
            number.Append(data[size - 1].ToString());
            for (int i = size - 2; i >= 0; i--)//так как в других яейках лидирующие нули могут быть потеряны, то восстанавливаем их
            {
                StringBuilder tmp = new StringBuilder(data[i].ToString());
                while (tmp.Length != len)
                    tmp.Insert(0, '0');
                number.Append(tmp);
            }
            if (minus) number.Insert(0, '-');
            return number.ToString();
        }
        private void RemoveLeadingZeroes()
        {
            while (data[size - 1] == 0)
            {
                if (data[0] == 0 && size == 1)
                    break;
                size--;
            }
        }

        public override bool Equals(object obj)
        {
            BigNumber other = (BigNumber)obj;
            if (this.minus != other.minus) return false;
            if (this.Size != other.Size) return false;
            for (int i = 0; i < this.Size; i++)
                if (this[i] != other[i])
                    return false;
            return true;
        }
    }
}
