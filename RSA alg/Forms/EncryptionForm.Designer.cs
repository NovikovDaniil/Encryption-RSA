namespace RSA_alg
{
    partial class EncryptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GenerationKeysRadio = new System.Windows.Forms.RadioButton();
            this.TakeKeysRadio = new System.Windows.Forms.RadioButton();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.textFileNameLabel = new System.Windows.Forms.Label();
            this.GenerationKeysButton = new System.Windows.Forms.Button();
            this.keysFileNameLabel = new System.Windows.Forms.Label();
            this.TakeOldKeysTextBox = new System.Windows.Forms.TextBox();
            this.EncryptionButton = new System.Windows.Forms.Button();
            this.OpenTextFileButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveTextLabel = new System.Windows.Forms.Label();
            this.SaveTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PublicKeyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenerationKeysRadio
            // 
            this.GenerationKeysRadio.AutoSize = true;
            this.GenerationKeysRadio.Location = new System.Drawing.Point(12, 29);
            this.GenerationKeysRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GenerationKeysRadio.Name = "GenerationKeysRadio";
            this.GenerationKeysRadio.Size = new System.Drawing.Size(274, 24);
            this.GenerationKeysRadio.TabIndex = 0;
            this.GenerationKeysRadio.TabStop = true;
            this.GenerationKeysRadio.Text = "Сгенерировать новые ключи";
            this.GenerationKeysRadio.UseVisualStyleBackColor = true;
            this.GenerationKeysRadio.CheckedChanged += new System.EventHandler(this.GenerationKeysRadio_CheckedChanged);
            // 
            // TakeKeysRadio
            // 
            this.TakeKeysRadio.AutoSize = true;
            this.TakeKeysRadio.Location = new System.Drawing.Point(369, 29);
            this.TakeKeysRadio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TakeKeysRadio.Name = "TakeKeysRadio";
            this.TakeKeysRadio.Size = new System.Drawing.Size(161, 24);
            this.TakeKeysRadio.TabIndex = 1;
            this.TakeKeysRadio.TabStop = true;
            this.TakeKeysRadio.Text = "Выбрать ключи";
            this.TakeKeysRadio.UseVisualStyleBackColor = true;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameTextBox.Location = new System.Drawing.Point(358, 120);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(216, 26);
            this.fileNameTextBox.TabIndex = 8;
            // 
            // textFileNameLabel
            // 
            this.textFileNameLabel.AutoSize = true;
            this.textFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textFileNameLabel.Location = new System.Drawing.Point(9, 120);
            this.textFileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textFileNameLabel.Name = "textFileNameLabel";
            this.textFileNameLabel.Size = new System.Drawing.Size(344, 20);
            this.textFileNameLabel.TabIndex = 7;
            this.textFileNameLabel.Text = "Имя файла c текстом для шифрования\r\n";
            // 
            // GenerationKeysButton
            // 
            this.GenerationKeysButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerationKeysButton.Location = new System.Drawing.Point(48, 60);
            this.GenerationKeysButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.GenerationKeysButton.Name = "GenerationKeysButton";
            this.GenerationKeysButton.Size = new System.Drawing.Size(212, 38);
            this.GenerationKeysButton.TabIndex = 6;
            this.GenerationKeysButton.Text = "Генерация ключей";
            this.GenerationKeysButton.UseVisualStyleBackColor = true;
            this.GenerationKeysButton.Click += new System.EventHandler(this.GenerationKeysButton_Click);
            // 
            // keysFileNameLabel
            // 
            this.keysFileNameLabel.AutoSize = true;
            this.keysFileNameLabel.Location = new System.Drawing.Point(365, 68);
            this.keysFileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.keysFileNameLabel.Name = "keysFileNameLabel";
            this.keysFileNameLabel.Size = new System.Drawing.Size(103, 20);
            this.keysFileNameLabel.TabIndex = 9;
            this.keysFileNameLabel.Text = "Имя файла";
            // 
            // TakeOldKeysTextBox
            // 
            this.TakeOldKeysTextBox.Location = new System.Drawing.Point(474, 65);
            this.TakeOldKeysTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TakeOldKeysTextBox.Name = "TakeOldKeysTextBox";
            this.TakeOldKeysTextBox.Size = new System.Drawing.Size(100, 26);
            this.TakeOldKeysTextBox.TabIndex = 10;
            // 
            // EncryptionButton
            // 
            this.EncryptionButton.Location = new System.Drawing.Point(158, 222);
            this.EncryptionButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EncryptionButton.Name = "EncryptionButton";
            this.EncryptionButton.Size = new System.Drawing.Size(340, 48);
            this.EncryptionButton.TabIndex = 11;
            this.EncryptionButton.Text = "Зашифровать";
            this.EncryptionButton.UseVisualStyleBackColor = true;
            this.EncryptionButton.Click += new System.EventHandler(this.EncryptionButton_Click);
            // 
            // OpenTextFileButton
            // 
            this.OpenTextFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenTextFileButton.Location = new System.Drawing.Point(582, 121);
            this.OpenTextFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenTextFileButton.Name = "OpenTextFileButton";
            this.OpenTextFileButton.Size = new System.Drawing.Size(66, 26);
            this.OpenTextFileButton.TabIndex = 12;
            this.OpenTextFileButton.Text = "Обзор";
            this.OpenTextFileButton.UseVisualStyleBackColor = true;
            this.OpenTextFileButton.Click += new System.EventHandler(this.OpenTextFileButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // saveTextLabel
            // 
            this.saveTextLabel.AutoSize = true;
            this.saveTextLabel.Location = new System.Drawing.Point(9, 166);
            this.saveTextLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.saveTextLabel.Name = "saveTextLabel";
            this.saveTextLabel.Size = new System.Drawing.Size(114, 20);
            this.saveTextLabel.TabIndex = 13;
            this.saveTextLabel.Text = "Сохранить в";
            // 
            // SaveTextBox
            // 
            this.SaveTextBox.Location = new System.Drawing.Point(127, 166);
            this.SaveTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveTextBox.Name = "SaveTextBox";
            this.SaveTextBox.Size = new System.Drawing.Size(216, 26);
            this.SaveTextBox.TabIndex = 14;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(347, 167);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(66, 26);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Обзор";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PublicKeyButton
            // 
            this.PublicKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PublicKeyButton.Location = new System.Drawing.Point(580, 65);
            this.PublicKeyButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PublicKeyButton.Name = "PublicKeyButton";
            this.PublicKeyButton.Size = new System.Drawing.Size(68, 26);
            this.PublicKeyButton.TabIndex = 16;
            this.PublicKeyButton.Text = "Обзор";
            this.PublicKeyButton.UseVisualStyleBackColor = true;
            this.PublicKeyButton.Click += new System.EventHandler(this.PublicKeyButton_Click);
            // 
            // EncryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 280);
            this.Controls.Add(this.PublicKeyButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SaveTextBox);
            this.Controls.Add(this.saveTextLabel);
            this.Controls.Add(this.OpenTextFileButton);
            this.Controls.Add(this.EncryptionButton);
            this.Controls.Add(this.TakeOldKeysTextBox);
            this.Controls.Add(this.keysFileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.textFileNameLabel);
            this.Controls.Add(this.GenerationKeysButton);
            this.Controls.Add(this.TakeKeysRadio);
            this.Controls.Add(this.GenerationKeysRadio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "EncryptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Шифрование данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton GenerationKeysRadio;
        private System.Windows.Forms.RadioButton TakeKeysRadio;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label textFileNameLabel;
        private System.Windows.Forms.Button GenerationKeysButton;
        private System.Windows.Forms.Label keysFileNameLabel;
        private System.Windows.Forms.TextBox TakeOldKeysTextBox;
        private System.Windows.Forms.Button EncryptionButton;
        private System.Windows.Forms.Button OpenTextFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Label saveTextLabel;
        private System.Windows.Forms.TextBox SaveTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button PublicKeyButton;
    }
}