namespace Version2
{
    partial class AddMetal
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
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextBoxt = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.alpha = new System.Windows.Forms.TextBox();
            this.specificHeat = new System.Windows.Forms.TextBox();
            this.density = new System.Windows.Forms.TextBox();
            this.ViewButoon = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.NameTextBoxt);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.alpha);
            this.panel1.Controls.Add(this.specificHeat);
            this.panel1.Controls.Add(this.density);
            this.panel1.Controls.Add(this.ViewButoon);
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 789);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 70);
            this.label2.TabIndex = 18;
            this.label2.Text = "Добавление нового маталла:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameTextBoxt
            // 
            this.NameTextBoxt.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBoxt.Location = new System.Drawing.Point(464, 135);
            this.NameTextBoxt.Name = "NameTextBoxt";
            this.NameTextBoxt.Size = new System.Drawing.Size(81, 40);
            this.NameTextBoxt.TabIndex = 17;
            this.NameTextBoxt.Text = "\r\n";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(26, 135);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(411, 40);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "Название\r\n\r\n\r\n\r\n";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(26, 217);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(411, 40);
            this.textBox3.TabIndex = 15;
            this.textBox3.Text = "Плотность\r\n\r\n\r\n\r\n";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(26, 380);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(411, 40);
            this.textBox2.TabIndex = 14;
            this.textBox2.Text = "Коэффициент Теплопроводности";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(26, 302);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(411, 40);
            this.textBox4.TabIndex = 13;
            this.textBox4.Text = "Удельная Теплоемкость";
            // 
            // alpha
            // 
            this.alpha.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alpha.Location = new System.Drawing.Point(464, 380);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(81, 40);
            this.alpha.TabIndex = 12;
            // 
            // specificHeat
            // 
            this.specificHeat.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specificHeat.Location = new System.Drawing.Point(464, 302);
            this.specificHeat.Name = "specificHeat";
            this.specificHeat.Size = new System.Drawing.Size(81, 40);
            this.specificHeat.TabIndex = 11;
            // 
            // density
            // 
            this.density.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.density.Location = new System.Drawing.Point(464, 217);
            this.density.Name = "density";
            this.density.Size = new System.Drawing.Size(81, 40);
            this.density.TabIndex = 10;
            this.density.Text = "\r\n";
            this.density.TextChanged += new System.EventHandler(this.highTempLocation_TextChanged);
            // 
            // ViewButoon
            // 
            this.ViewButoon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ViewButoon.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewButoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ViewButoon.Location = new System.Drawing.Point(79, 470);
            this.ViewButoon.Name = "ViewButoon";
            this.ViewButoon.Size = new System.Drawing.Size(449, 81);
            this.ViewButoon.TabIndex = 9;
            this.ViewButoon.Text = "Отображить своиство\r\n";
            this.ViewButoon.UseVisualStyleBackColor = false;
            this.ViewButoon.Click += new System.EventHandler(this.ViewButoon_Click);
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.back.Location = new System.Drawing.Point(26, 689);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(160, 47);
            this.back.TabIndex = 7;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // AddButton
            // 
            this.AddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.AddButton.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.AddButton.Location = new System.Drawing.Point(79, 576);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(449, 81);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Добавить в список\r\n";
            this.AddButton.UseVisualStyleBackColor = false;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddMetal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 789);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddMetal";
            this.Text = "AddMetal";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ViewButoon;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox alpha;
        private System.Windows.Forms.TextBox specificHeat;
        private System.Windows.Forms.TextBox density;
        private System.Windows.Forms.TextBox NameTextBoxt;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label2;
    }
}
