using System;
using System.Windows.Forms;

namespace Version2
{
    public partial class MainPage : Form
    {
        private DBMetals dbMetalsForm; // Объявляем форму DBMetals
        private EnterPro enterProForm; // Объявляем форму EnterPro

        public MainPage()
        {
            InitializeComponent();
        }

        private void ChoiceIn_Click(object sender, EventArgs e)
        {
            // Очищаем панель panel1 перед добавлением нового контента
            panel1.Controls.Clear();

            // Создаем экземпляр формы EnterPro (если еще не создан)
            if (enterProForm == null)
            {
                enterProForm = new EnterPro();
                enterProForm.TopLevel = false;
                enterProForm.FormBorderStyle = FormBorderStyle.None;
                enterProForm.Dock = DockStyle.Fill;
            }

            // Добавляем форму EnterPro на панель panel1
            panel1.Controls.Add(enterProForm);

            // Отображаем форму EnterPro на панели panel1
            enterProForm.Show();
        }

        private void ChoiceShow_Click_1(object sender, EventArgs e)
        {
            // Очищаем панель panel1 перед добавлением нового контента
            panel1.Controls.Clear();

            // Создаем экземпляр формы DBMetals (если еще не создан)
            if (dbMetalsForm == null)
            {
                dbMetalsForm = new DBMetals();
                dbMetalsForm.TopLevel = false;
                dbMetalsForm.FormBorderStyle = FormBorderStyle.None;
                dbMetalsForm.Dock = DockStyle.Fill;
            }

            // Добавляем форму DBMetals на панель panel1
            panel1.Controls.Add(dbMetalsForm);

            // Отображаем форму DBMetals на панели panel1
            dbMetalsForm.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
