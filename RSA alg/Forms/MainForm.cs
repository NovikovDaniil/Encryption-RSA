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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            EncryptionForm encryptionForm = new EncryptionForm();
            encryptionForm.ShowDialog();
        }

        private void DecryptionButton_Click(object sender, EventArgs e)
        {
            DecryptionForm decryptionForm = new DecryptionForm();
            decryptionForm.ShowDialog();
        }
    }
}
