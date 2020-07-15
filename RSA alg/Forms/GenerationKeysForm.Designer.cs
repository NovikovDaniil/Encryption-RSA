namespace RSA_alg
{
    partial class GenerationKeysForm
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
            this.degreeOfSafety = new System.Windows.Forms.TextBox();
            this.generateKeysButon = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя файла для сохранения\r\n(без расширения)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fileNameTextBox.Location = new System.Drawing.Point(281, 67);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(124, 26);
            this.fileNameTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Криптостойкость ключа\r\n (от 10 до 160)\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // degreeOfSafety
            // 
            this.degreeOfSafety.Location = new System.Drawing.Point(351, 19);
            this.degreeOfSafety.Name = "degreeOfSafety";
            this.degreeOfSafety.Size = new System.Drawing.Size(54, 26);
            this.degreeOfSafety.TabIndex = 0;
            // 
            // generateKeysButon
            // 
            this.generateKeysButon.Location = new System.Drawing.Point(46, 116);
            this.generateKeysButon.Name = "generateKeysButon";
            this.generateKeysButon.Size = new System.Drawing.Size(339, 40);
            this.generateKeysButon.TabIndex = 2;
            this.generateKeysButon.Text = "Сгенерировать и сохранить";
            this.generateKeysButon.UseVisualStyleBackColor = true;
            this.generateKeysButon.Click += new System.EventHandler(this.generateKeysButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(17, 174);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(388, 33);
            this.progressBar.TabIndex = 3;
            // 
            // GenerationKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 219);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.generateKeysButon);
            this.Controls.Add(this.degreeOfSafety);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GenerationKeysForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Генерация ключей";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox degreeOfSafety;
        private System.Windows.Forms.Button generateKeysButon;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}