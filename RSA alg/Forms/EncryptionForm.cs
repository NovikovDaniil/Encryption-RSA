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

namespace RSA_alg
{
    public partial class EncryptionForm : Form
    {
        string fileNameWithKey;//имя файла с ключом
        public EncryptionForm()
        {
            InitializeComponent();
        }

        private void GenerationKeysButton_Click(object sender, EventArgs e)
        {
            GenerationKeysForm generationKeysForm = new GenerationKeysForm();
            generationKeysForm.ShowDialog();
            fileNameWithKey = generationKeysForm.fileName + ".txt";//заоминаем имя файла, в котором содержатся ключи
        }

        /// <summary>
        /// функция для шифрования текста
        /// </summary>
        private string EncryptionText()
        {
            string fileText = "";
            byte[] bytes;
            try
            {
                if (!Regex.IsMatch(fileNameWithKey, @"\.txt")) fileNameWithKey += ".txt";
                using (StreamReader sr = new StreamReader(fileNameWithKey))//считываем ключи
                {
                    fileText = sr.ReadLine();//считываем строку "Открытый ключ"
                    fileText = sr.ReadLine();//считываем строку с ключами
                }
            }
            catch
            {
                MessageBox.Show("Файл с ключом не найден!\nПопробуйте ввести другое имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            try
            {
                string[] keys = Regex.Split(fileText, "[;()]", RegexOptions.IgnorePatternWhitespace);//разделяем строку такими символами
                BigInteger publicKey = BigInteger.Parse(keys[1]);//считываем не с начала, потому что первой всегда пустая строка
                BigInteger n = BigInteger.Parse(keys[2]);
                string fileNameWithText = fileNameTextBox.Text;
                if (!Regex.IsMatch(fileNameWithText, @"\.txt")) fileNameWithText += ".txt";
                try
                {
                    bytes = File.ReadAllBytes(fileNameWithText);//считали текст в массив байтов
                }
                catch
                {
                    MessageBox.Show("Файл с тектом не найден!\nПопробуйте ввести другое имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                MessageBox.Show("Выполнение операции может занять некоторое время", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return EncryptionRSA.Encrypt(bytes, publicKey, n);
            }
            catch
            {
                MessageBox.Show("Проверьте файлы на корректность данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private void EncryptionButton_Click(object sender, EventArgs e)
        {
            if (TakeKeysRadio.Checked)
                fileNameWithKey = TakeOldKeysTextBox.Text;//записываем имя файла с ключами
            string saveFileName = SaveTextBox.Text;
            if (!ValidateFileName(saveFileName))
            {
                MessageBox.Show("Проверьте корректность ввода имени файла для сохранения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string result = EncryptionText();
            if (result != null)
            {
                if (!Regex.IsMatch(saveFileName, @"\.txt")) saveFileName += ".txt";
                using (StreamWriter sw = new StreamWriter(saveFileName))//сохраняем в текстовый файл зашифрованную информацию
                {
                    sw.Write(result);
                }
                MessageBox.Show("Зашифрованный текст записан в файл: " + saveFileName,"Предупреждение",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void GenerationKeysRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (GenerationKeysRadio.Checked)
            {
                GenerationKeysButton.Enabled = true;
                TakeOldKeysTextBox.Enabled = false;
                PublicKeyButton.Enabled = false;
                keysFileNameLabel.Enabled = false;
            }
            else
            {
                GenerationKeysButton.Enabled = false;
                TakeOldKeysTextBox.Enabled = true;
                PublicKeyButton.Enabled = true;
                keysFileNameLabel.Enabled = true;
            }
        }

        private void OpenTextFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текст|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = openFileDialog.FileName;
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

        private void PublicKeyButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Текст|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileNameWithKey = openFileDialog.FileName;
                TakeOldKeysTextBox.Text = fileNameWithKey;
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
