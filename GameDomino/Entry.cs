using Domino2;
using Domino2.Resources;
using GameDomino.Resources;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domino
{
    /// <summary>
    /// класс формы входа
    /// </summary>
    public partial class Entry : Form
    {
        private readonly ApplicationDbContext _dbContext;
        private Guid _userId;
        private bool isPasswordVisible = false;

        /// <summary>
        /// конструктор формы входа
        /// </summary>
        public Entry()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            this.CenterToScreen();
            _dbContext = new ApplicationDbContext();

            LanguageManager.LanguageChanged += UpdateUI; // Подписываемся на событие
            UpdateUI();
        }

        private void UpdateUI()
        {
            
            lblTitle.Text = EntryFormResources.lblTitle;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.LanguageChanged -= UpdateUI; // Отписываемся
            base.OnFormClosed(e);
        }

        private void CheckLogin()
        {
            var login = textBoxLogin.Text;
            var pass = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                textBoxLogin.BackColor = Color.LightPink;
                textBoxPassword.BackColor = Color.LightPink;

                return;
            }

            if (UserExists(login, pass))
            {
                MessageBox.Show(EntryFormResources.LoginSuccessMessage, EntryFormResources.LoginSuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                var nextForm = new MainWindow(_userId);
                nextForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(EntryFormResources.LoginErrorMessage, EntryFormResources.LoginErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool UserExists(string login, string password)
        {

            var user = _dbContext.Users.FirstOrDefault(u => u.Login == login && u.Password == RepeateMethod.Hashing(password));
            if (user != null)
            {
                _userId = user.Id;
                return true;
            }
            return false;
        }


        private void btnRegistration_Click_1(object sender, EventArgs e)
        {
            var nextform = new Registration();
            nextform.Show();
            this.Hide();
        }

        private void btnCheckPassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            RepeateMethod.TogglePasswordVisibility(textBoxPassword, isPasswordVisible);
        }

        private void btnEntry_Click_1(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void btnRussian_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("ru");
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("en");
        }
    }
}
