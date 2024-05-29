namespace Version2
{
    partial class DBMetals
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddMetal = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SelectThis = new System.Windows.Forms.Button();
            this.ShowItems = new System.Windows.Forms.Button();
            this.comboBoxMetals = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.AddMetal);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.SelectThis);
            this.panel1.Controls.Add(this.ShowItems);
            this.panel1.Controls.Add(this.comboBoxMetals);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 724);
            this.panel1.TabIndex = 1;

            // 
            // AddMetal
            // 
            this.AddMetal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.AddMetal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddMetal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AddMetal.Location = new System.Drawing.Point(319, 200);
            this.AddMetal.Name = "AddMetal";
            this.AddMetal.Size = new System.Drawing.Size(288, 73);
            this.AddMetal.TabIndex = 8;
            this.AddMetal.Text = "Добавить металл";
            this.AddMetal.UseVisualStyleBackColor = false;
            this.AddMetal.Click += new System.EventHandler(this.AddMetal_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.back.Location = new System.Drawing.Point(25, 655);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(160, 47);
            this.back.TabIndex = 7;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(322, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(248, 159);
            this.button2.TabIndex = 5;
            this.button2.Text = "Решение на двухмерным плоскости\r\n";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.Location = new System.Drawing.Point(25, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 159);
            this.button1.TabIndex = 4;
            this.button1.Text = "Решение на одномерным плоскости";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectThis
            // 
            this.SelectThis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.SelectThis.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectThis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SelectThis.Location = new System.Drawing.Point(93, 476);
            this.SelectThis.Name = "SelectThis";
            this.SelectThis.Size = new System.Drawing.Size(432, 135);
            this.SelectThis.TabIndex = 3;
            this.SelectThis.Text = "Выбрать металл";
            this.SelectThis.UseVisualStyleBackColor = false;
            this.SelectThis.Click += new System.EventHandler(this.SelectThis_Click);
            // 
            // ShowItems
            // 
            this.ShowItems.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowItems.Location = new System.Drawing.Point(322, 140);
            this.ShowItems.Name = "ShowItems";
            this.ShowItems.Size = new System.Drawing.Size(288, 54);
            this.ShowItems.TabIndex = 2;
            this.ShowItems.Text = "Отобразить свойства";
            this.ShowItems.UseVisualStyleBackColor = true;
            this.ShowItems.Click += new System.EventHandler(this.ShowItems_Click);
            // 
            // comboBoxMetals
            // 
            this.comboBoxMetals.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxMetals.FormattingEnabled = true;
            this.comboBoxMetals.Location = new System.Drawing.Point(25, 140);
            this.comboBoxMetals.Name = "comboBoxMetals";
            this.comboBoxMetals.Size = new System.Drawing.Size(288, 54);
            this.comboBoxMetals.TabIndex = 1;
            this.comboBoxMetals.SelectedIndexChanged += new System.EventHandler(this.comboBoxMetals_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.CausesValidation = false;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(79, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(277, 40);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Данные из таблицы:";
            // 
            // DBMetals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 724);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "DBMetals";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AGDE";
            this.Load += new System.EventHandler(this.DBMetals_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;



        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBoxMetals;
        private System.Windows.Forms.Button SelectThis;
        private System.Windows.Forms.Button ShowItems;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button AddMetal;
    }
}