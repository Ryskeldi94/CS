namespace Version2
{
    partial class MainPage
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChoiceIn = new System.Windows.Forms.Button();
            this.ChoiceShow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.ChoiceIn);
            this.panel1.Controls.Add(this.ChoiceShow);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 729);
            this.panel1.TabIndex = 0;
            // 
            // ChoiceIn
            // 
            this.ChoiceIn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ChoiceIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceIn.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceIn.Location = new System.Drawing.Point(98, 454);
            this.ChoiceIn.Name = "ChoiceIn";
            this.ChoiceIn.Size = new System.Drawing.Size(449, 111);
            this.ChoiceIn.TabIndex = 3;
            this.ChoiceIn.Text = "Ввести свои свойства металла";
            this.ChoiceIn.UseVisualStyleBackColor = true;
            this.ChoiceIn.Click += new System.EventHandler(this.ChoiceIn_Click);
            // 
            // ChoiceShow
            // 
            this.ChoiceShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.ChoiceShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChoiceShow.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChoiceShow.Location = new System.Drawing.Point(98, 248);
            this.ChoiceShow.Name = "ChoiceShow";
            this.ChoiceShow.Size = new System.Drawing.Size(449, 111);
            this.ChoiceShow.TabIndex = 2;
            this.ChoiceShow.Text = "Выбрать металл из списка";
            this.ChoiceShow.UseVisualStyleBackColor = true;
            this.ChoiceShow.Click += new System.EventHandler(this.ChoiceShow_Click_1);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 136);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберети опцию:\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 729);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.DarkRed;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ChoiceIn;
        private System.Windows.Forms.Button ChoiceShow;
    }
}

