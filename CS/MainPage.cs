using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Version2
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChoiceIn_Click(object sender, EventArgs e)
        {
            EnterPro enterPro = new EnterPro();
            enterPro.Show();
            this.Hide();
        }

        private void ChoiceShow_Click_1(object sender, EventArgs e)
        {
            DBMetals form2 = new DBMetals();
            // Показываем новую форму
            form2.Show();

            this.Hide();
        }
    }
}
