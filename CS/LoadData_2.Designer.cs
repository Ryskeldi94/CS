namespace CS
{
    partial class LoadData_2
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
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.back = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.N_nextLine = new System.Windows.Forms.TextBox();
            this.N_currentLine = new System.Windows.Forms.TextBox();
            this.N_previousLine = new System.Windows.Forms.TextBox();
            this.nextLine = new System.Windows.Forms.TextBox();
            this.currentLine = new System.Windows.Forms.TextBox();
            this.previousLine = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(251, 25);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(555, 26);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(877, 332);
            this.dataGridView1.TabIndex = 1;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.back.Location = new System.Drawing.Point(44, 12);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(160, 47);
            this.back.TabIndex = 9;
            this.back.Text = "Назад";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.N_nextLine);
            this.panel1.Controls.Add(this.N_currentLine);
            this.panel1.Controls.Add(this.N_previousLine);
            this.panel1.Controls.Add(this.nextLine);
            this.panel1.Controls.Add(this.currentLine);
            this.panel1.Controls.Add(this.previousLine);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 582);
            this.panel1.TabIndex = 10;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveButton.Location = new System.Drawing.Point(44, 65);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 47);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "Сохранить данные";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // N_nextLine
            // 
            this.N_nextLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_nextLine.Location = new System.Drawing.Point(25, 201);
            this.N_nextLine.Name = "N_nextLine";
            this.N_nextLine.ReadOnly = true;
            this.N_nextLine.Size = new System.Drawing.Size(87, 26);
            this.N_nextLine.TabIndex = 7;
            // 
            // N_currentLine
            // 
            this.N_currentLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_currentLine.Location = new System.Drawing.Point(25, 169);
            this.N_currentLine.Name = "N_currentLine";
            this.N_currentLine.ReadOnly = true;
            this.N_currentLine.Size = new System.Drawing.Size(87, 26);
            this.N_currentLine.TabIndex = 6;
            // 
            // N_previousLine
            // 
            this.N_previousLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_previousLine.Location = new System.Drawing.Point(25, 137);
            this.N_previousLine.Name = "N_previousLine";
            this.N_previousLine.ReadOnly = true;
            this.N_previousLine.Size = new System.Drawing.Size(87, 26);
            this.N_previousLine.TabIndex = 5;
            // 
            // nextLine
            // 
            this.nextLine.Location = new System.Drawing.Point(138, 201);
            this.nextLine.Name = "nextLine";
            this.nextLine.ReadOnly = true;
            this.nextLine.Size = new System.Drawing.Size(708, 26);
            this.nextLine.TabIndex = 4;
            // 
            // currentLine
            // 
            this.currentLine.Location = new System.Drawing.Point(138, 169);
            this.currentLine.Name = "currentLine";
            this.currentLine.ReadOnly = true;
            this.currentLine.Size = new System.Drawing.Size(708, 26);
            this.currentLine.TabIndex = 3;
            // 
            // previousLine
            // 
            this.previousLine.Location = new System.Drawing.Point(138, 137);
            this.previousLine.Name = "previousLine";
            this.previousLine.ReadOnly = true;
            this.previousLine.Size = new System.Drawing.Size(708, 26);
            this.previousLine.TabIndex = 2;
            // 
            // LoadData_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 582);
            this.Controls.Add(this.back);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoadData_2";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox previousLine;
        private System.Windows.Forms.TextBox nextLine;
        private System.Windows.Forms.TextBox currentLine;
        private System.Windows.Forms.TextBox N_nextLine;
        private System.Windows.Forms.TextBox N_currentLine;
        private System.Windows.Forms.TextBox N_previousLine;
        private System.Windows.Forms.Button saveButton;
    }
}