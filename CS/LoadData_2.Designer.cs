using System.Windows.Forms;

namespace Version2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadData_2));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.N_nextLine = new System.Windows.Forms.TextBox();
            this.N_currentLine = new System.Windows.Forms.TextBox();
            this.N_previousLine = new System.Windows.Forms.TextBox();
            this.nextLine = new System.Windows.Forms.TextBox();
            this.currentLine = new System.Windows.Forms.TextBox();
            this.previousLine = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            resources.ApplyResources(this.numericUpDown1, "numericUpDown1");
            this.numericUpDown1.Name = "numericUpDown1";
            // 
            // dataGridView1
            // 
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.back);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.N_nextLine);
            this.panel1.Controls.Add(this.N_currentLine);
            this.panel1.Controls.Add(this.N_previousLine);
            this.panel1.Controls.Add(this.nextLine);
            this.panel1.Controls.Add(this.currentLine);
            this.panel1.Controls.Add(this.previousLine);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Name = "panel1";
            // 
            // back
            // 
            resources.ApplyResources(this.back, "back");
            this.back.BackColor = System.Drawing.Color.White;
            this.back.FlatAppearance.BorderSize = 0;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Name = "back";
            this.back.UseVisualStyleBackColor = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // N_nextLine
            // 
            resources.ApplyResources(this.N_nextLine, "N_nextLine");
            this.N_nextLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_nextLine.Name = "N_nextLine";
            this.N_nextLine.ReadOnly = true;
            // 
            // N_currentLine
            // 
            resources.ApplyResources(this.N_currentLine, "N_currentLine");
            this.N_currentLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_currentLine.Name = "N_currentLine";
            this.N_currentLine.ReadOnly = true;
            // 
            // N_previousLine
            // 
            resources.ApplyResources(this.N_previousLine, "N_previousLine");
            this.N_previousLine.Cursor = System.Windows.Forms.Cursors.No;
            this.N_previousLine.Name = "N_previousLine";
            this.N_previousLine.ReadOnly = true;
            // 
            // nextLine
            // 
            resources.ApplyResources(this.nextLine, "nextLine");
            this.nextLine.Name = "nextLine";
            this.nextLine.ReadOnly = true;
            // 
            // currentLine
            // 
            resources.ApplyResources(this.currentLine, "currentLine");
            this.currentLine.Name = "currentLine";
            this.currentLine.ReadOnly = true;
            // 
            // previousLine
            // 
            resources.ApplyResources(this.previousLine, "previousLine");
            this.previousLine.Name = "previousLine";
            this.previousLine.ReadOnly = true;
            // 
            // LoadData_2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoadData_2";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox previousLine;
        private System.Windows.Forms.TextBox nextLine;
        private System.Windows.Forms.TextBox currentLine;
        private System.Windows.Forms.TextBox N_nextLine;
        private System.Windows.Forms.TextBox N_currentLine;
        private System.Windows.Forms.TextBox N_previousLine;
        private System.Windows.Forms.Button saveButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button back;
    }
}