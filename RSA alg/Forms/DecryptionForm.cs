using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSA_alg
{
    public partial class DecryptionForm : Form
    {
        public byte[] decryptionText;
        public DecryptionForm()
        {
            InitializeComponent();
        }

        private void DecryptionButton_Click(object sender, EventArgs e)
        {
            string fileNameWithText = fileNameTextBox.Text;
            if (!Regex.IsMatch(fileNameWithText, @"\.txt")) fileNameWithText += ".txt";
            string fileText;
            try
            {
                using (StreamReader sr = new StreamReader(fileNameWithText))//считываем зашифрованный текст
                {
                    fileText = sr.ReadToEnd();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла с текстом!\nПопробуйте ввести другое имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fileWithKeyName = PrivateKeyTextBox.Text;
            if (!Regex.IsMatch(fileWithKeyName, @"\.xml")) fileWithKeyName += ".xml";
            BigInteger privateKey = 0, n = 0;//пара закрытого ключа
            XmlDocument xDoc = new XmlDocument();
            try
            {
                xDoc.Load(fileWithKeyName);
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlElement xnode in xRoot)//считываем пару закрытого ключа
                {
                    foreach (XmlNode cnode in xnode.ChildNodes)
                    {
                        if (cnode.Name == "d") privateKey = BigInteger.Parse(cnode.InnerText);
                        if (cnode.Name == "n") n = BigInteger.Parse(cnode.InnerText);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла с ключом!\nПопробуйте ввести другое имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string saveFileName = SaveTextBox.Text;
            if (!ValidateFileName(saveFileName))
            {
                MessageBox.Show("Проверьте корректность ввода имени файла", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Выполнение операции может занять некоторое время", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            try
            {
                decryptionText = DecryptionRSA.Decrypt(fileText, privateKey, n);
            }
            catch
            {
                MessageBox.Show("Ошибка при расшифровании информации.\n Проверьте файл с закрытым ключом на корректность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(saveFileName, @"\.txt")) saveFileName += ".txt";
            try
            {
                File.WriteAllBytes(saveFileName, decryptionText);
            }
            catch
            {
                MessageBox.Show("Ошибка при открытии файла для сохранения!\nПопробуйте ввести другое имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Текст расшифрован и сохранен в " + saveFileName, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void InputTextButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текст|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog.FileName;
            }
        }

        private void PrivateKeyButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текст|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PrivateKeyTextBox.Text = openFileDialog.FileName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Текст|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveTextBox.Text = saveFileDialog.FileName;
            }
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
