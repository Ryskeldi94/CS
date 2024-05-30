using System;
using System.Windows.Forms;

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
