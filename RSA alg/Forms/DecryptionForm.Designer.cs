namespace RSA_alg
{
    partial class DecryptionForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PrivateKeyTextBox = new System.Windows.Forms.TextBox();
            this.DecryptionButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveTextBox = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.InputTextButton = new System.Windows.Forms.Button();
            this.PrivateKeyButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя файла для дешифрования";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(350, 20);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(148, 26);
            this.fileNameTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Имя файла с закрытым ключом";
            // 
            // PrivateKeyTextBox
            // 
            this.PrivateKeyTextBox.Location = new System.Drawing.Point(350, 57);
            this.PrivateKeyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.PrivateKeyTextBox.Name = "PrivateKeyTextBox";
            this.PrivateKeyTextBox.Size = new System.Drawing.Size(148, 26);
            this.PrivateKeyTextBox.TabIndex = 1;
            // 
            // DecryptionButton
            // 
            this.DecryptionButton.Location = new System.Drawing.Point(158, 144);
            this.DecryptionButton.Name = "DecryptionButton";
            this.DecryptionButton.Size = new System.Drawing.Size(226, 60);
            this.DecryptionButton.TabIndex = 3;
            this.DecryptionButton.Text = "Дешифровать";
            this.DecryptionButton.UseVisualStyleBackColor = true;
            this.DecryptionButton.Click += new System.EventHandler(this.DecryptionButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сохранить в";
            // 
            // SaveTextBox
            // 
            this.SaveTextBox.Location = new System.Drawing.Point(140, 95);
            this.SaveTextBox.Name = "SaveTextBox";
            this.SaveTextBox.Size = new System.Drawing.Size(148, 26);
            this.SaveTextBox.TabIndex = 2;
            // 
            // InputTextButton
            // 
            this.InputTextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputTextButton.Location = new System.Drawing.Point(505, 18);
            this.InputTextButton.Name = "InputTextButton";
            this.InputTextButton.Size = new System.Drawing.Size(63, 28);
            this.InputTextButton.TabIndex = 7;
            this.InputTextButton.Text = "Обзор";
            this.InputTextButton.UseVisualStyleBackColor = true;
            this.InputTextButton.Click += new System.EventHandler(this.InputTextButton_Click);
            // 
            // PrivateKeyButton
            // 
            this.PrivateKeyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PrivateKeyButton.Location = new System.Drawing.Point(505, 57);
            this.PrivateKeyButton.Name = "PrivateKeyButton";
            this.PrivateKeyButton.Size = new System.Drawing.Size(63, 26);
            this.PrivateKeyButton.TabIndex = 8;
            this.PrivateKeyButton.Text = "Обзор";
            this.PrivateKeyButton.UseVisualStyleBackColor = true;
            this.PrivateKeyButton.Click += new System.EventHandler(this.PrivateKeyButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.Location = new System.Drawing.Point(294, 94);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(65, 27);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Обзор";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // DecryptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 217);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PrivateKeyButton);
            this.Controls.Add(this.InputTextButton);
            this.Controls.Add(this.SaveTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DecryptionButton);
            this.Controls.Add(this.PrivateKeyTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DecryptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Дешифрование информации";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PrivateKeyTextBox;
        private System.Windows.Forms.Button DecryptionButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SaveTextBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button InputTextButton;
        private System.Windows.Forms.Button PrivateKeyButton;
        private System.Windows.Forms.Button SaveButton;
    }
}