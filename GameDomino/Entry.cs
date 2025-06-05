using Domino2;
using GameDomino.Resources;
using GameDomino;
using GameDomino.Game;
using NLog;

namespace Domino
{
    /// <summary>
    /// класс формы входа
    /// </summary>
    public partial class Entry : Form
    {
        private readonly IUserService _userService;
        private bool isPasswordVisible = false;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// конструктор формы входа
        /// </summary>
        public Entry(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            this.CenterToScreen();

            LanguageManager.LanguageChanged += UpdateUI;
            UpdateUI();
        }

        private void UpdateUI()
        {

            this.Text = EntryFormResources.EntryFormTitle;
            lblTitle.Text = EntryFormResources.lblTitle;
            lnlLogin.Text = EntryFormResources.lnlLogin;
            labelPassword.Text = EntryFormResources.labelPassword;
            btnEntry.Text = EntryFormResources.btnEntry;
            lblNoAccount.Text = EntryFormResources.lblNoAccount;
            btnRegistration.Text = EntryFormResources.btnRegistration;
            btnRussian.Text = EntryFormResources.btnRussian;
            btnEnglish.Text = EntryFormResources.btnEnglish;

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            LanguageManager.LanguageChanged -= UpdateUI;
            base.OnFormClosed(e);
        }

        private void CheckLogin()
        {
            var login = textBoxLogin.Text;
            logger.Info("Пользователь вводит логин");
            var pass = textBoxPassword.Text;
            logger.Info("Пользователь вводит пароль");

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
            {
                textBoxLogin.BackColor = Color.LightPink;
                textBoxPassword.BackColor = Color.LightPink;
                return;
            }

            if (_userService.UserExists(login, pass, out Guid userId))
            {
               
                MessageBox.Show(EntryFormResources.LoginSuccessMessage,
                              EntryFormResources.LoginSuccessTitle,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                logger.Info("Пользователь входит в приложение");

                var mainForm = new MainWindow(userId,Program.Container.Resolve<IDominoGameService>(),
                Program.Container.Resolve<IUserService>());
                mainForm.Show();
                this.Hide();
                logger.Info("Пользователь переходит на главную страницу");
            }
            else
            {
                MessageBox.Show(EntryFormResources.LoginErrorMessage,
                              EntryFormResources.LoginErrorTitle,
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }

        }

        private void btnRegistration_Click_1(object sender, EventArgs e)
        {
            var registrationForm = Program.Container.Resolve<Registration>();

            registrationForm.Show();

            this.Hide();
            logger.Info("Пользователь переходит на форму регистрации");
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
            logger.Info("Пользователь поменял язык интерфейса на русский");
        }

        private void btnEnglish_Click(object sender, EventArgs e)
        {
            LanguageManager.SetLanguage("en");
            logger.Info("Пользователь поменял язык интерфейса на английский");
        }
    }
}