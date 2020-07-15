using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSA_alg
{
    public partial class GenerationKeysForm : Form
    {
        public string fileName;
        BigInteger publicKey, n, privateKey, m;
        int size;
        public GenerationKeysForm()
        {
            InitializeComponent();
        }
        private void generateKeysButton_Click(object sender, EventArgs e)
        {

            bool checkNumber = Int32.TryParse(degreeOfSafety.Text, out size);
            if (size < 10 || size > 160)
            {
                MessageBox.Show("Проверьте корректность ввода криптостойкости ключа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fileName = fileNameTextBox.Text;
            if (fileName == "")
            {
                MessageBox.Show("Проверьте корректность ввода имени файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidateFileName(fileName))
            {
                MessageBox.Show("Проверьте корректность ввода имени файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Операция может занять некоторое время", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            generateKeysButon.Enabled = false;//делаем недопустимым для изменения поля ввода данных во время генерации
            degreeOfSafety.Enabled = false;
            fileNameTextBox.Enabled = false;
            GeneratePublicAndPrivateKeys();
        }
        async private void GeneratePublicAndPrivateKeys()//чтобы программа работала стабильно, асинхронно выполняем данную функцию, где генерация происходит достаточно долго при вводе большого size
        {
            await Task.Run(() =>
            {
                BigInteger p = GenerateNumber.GeneratePrimeNumber(size);
                progressBar.Value += 45;
                BigInteger q = GenerateNumber.GeneratePrimeNumber(size);
                while (q == p)
                    q = GenerateNumber.GeneratePrimeNumber(size);
                progressBar.Value += 45;
                n = p * q;
                m = (p - 1) * (q - 1);//функция Эйлера
                GetAndLoadPublicKey();
                GetAndLoadPrivateKey();
                progressBar.Value += 10;
            });
            MessageBox.Show("Ключи записаны в файлы с именем: " + fileName, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private void GetAndLoadPublicKey()
        {
            publicKey = 65537;
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName + ".txt"))//сохраняем в текстовый файл открытый ключ
                {
                    sw.WriteLine("Открытый ключ");
                    sw.WriteLine("(" + publicKey.ToString() + ";" + n.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("При открытии файла возникла ошибка! Ошибка: " + ex.Message + "\nПопробуйте ввести другое имя файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GetAndLoadPrivateKey()
        {
            BigInteger x, y;
            privateKey = GcdExtended(publicKey, m, out x, out y);
            privateKey = (x % m + m) % m;
            XmlTextWriter textWritter = new XmlTextWriter(fileName + ".xml", Encoding.UTF8);//запись в xml файл
            textWritter.WriteStartDocument();
            textWritter.WriteStartElement("Notes");
            textWritter.WriteEndElement();
            textWritter.Close();

            XmlDocument document = new XmlDocument();
            document.Load(fileName + ".xml");
            XmlElement element = document.CreateElement("PrivateKey");
            document.DocumentElement.AppendChild(element);

            //Добавляем в запись данные
            XmlNode privateKeyElem = document.CreateElement("d");
            privateKeyElem.InnerText = privateKey.ToString();
            element.AppendChild(privateKeyElem);
            XmlNode nElem = document.CreateElement("n");
            nElem.InnerText = n.ToString();
            element.AppendChild(nElem);
            document.Save(fileName + ".xml");
        }

        /// <summary>
        /// Расширенный алгоритм Евклида для нахождения x и y
        /// это поможет в нахождении закрытого ключа
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static private BigInteger GcdExtended(BigInteger a, BigInteger b, out BigInteger x, out BigInteger y)
        {
            if (a == 0)
            {
                x = 1;
                y = 1;
                return b;
            }
            BigInteger x1, y1;
            BigInteger gcd = GcdExtended(b % a, a, out x1, out y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return gcd;
        }

        /// <summary>
        /// проверка на допустимое имя для файла
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool ValidateFileName(string name)
        {
            try
            {
                FileStream fs = File.Open(name, FileMode.Open);
                if (fs != null) fs.Close();
            }
            catch (FileNotFoundException)
            {
                return true;//имя файла введено корректно, но файл не существует
            }
            catch (ArgumentException)
            {
                return false;//имя файла введено некорректно
            }
            return true;
        }
    }
}
