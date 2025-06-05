using Domino2;
using GameDomino;
using GameDomino.Game;
using GameDomino.Resources;
using NLog;
using System.Text.RegularExpressions;
namespace Domino
{
    /// <summary>
    /// класс формы регистрации
    /// </summary>
    public partial class Registration : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUserService _userService;
        private bool isPasswordVisible = false;
        /// <summary>
        /// конструктор формы регистрации
        /// </summary>
        public Registration(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            txtPasswordRepeate.PasswordChar = '*';
            this.CenterToScreen();
            LanguageManager.LanguageChanged += UpdateUI;
            UpdateUI();
        }
        private void UpdateUI()
        {

            this.Text = RegistrationResources.RegistrationForm;
            lblRegistration.Text = RegistrationResources.lblRegistration;
            lblLogin.Text = RegistrationResources.lblLogin;
            lblPassword.Text = RegistrationResources.lblPassword;
            lblPasswortRepeate.Text = RegistrationResources.lblPasswortRepeate;
            btnRegistration2.Text = RegistrationResources.btnRegistration;
        }

        private void btnRegistration2_Click_1(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            logger.Info("Пользователь вводит логин");
            string pass = textBoxPassword.Text;
            logger.Info("Пользователь вводит пароль");
            string passRepeate = txtPasswordRepeate.Text;
            logger.Info("Пользователь подтверждает пароль");


            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(passRepeate))
            {
                MessageBox.Show(RegistrationResources.EmptyFieldsError, RegistrationResources.RegistrationErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pass != passRepeate)
            {
                MessageBox.Show(RegistrationResources.PasswordMismatchError, RegistrationResources.RegistrationErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(pass, @"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
            {
                MessageBox.Show(RegistrationResources.PasswordRequirementsError, RegistrationResources.RegistrationErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,19}$"))
            {
                MessageBox.Show(RegistrationResources.LoginRequirementsError, RegistrationResources.RegistrationErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_userService.LoginIsTaken(login))
            {
                MessageBox.Show(RegistrationResources.LoginTakenError, RegistrationResources.RegistrationErrorTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Focus();
                textBoxLogin.SelectAll();
                return;
            }
            try
            {
                Guid userId = _userService.RegisterNewUser(login, pass);
                MessageBox.Show(RegistrationResources.RegistrationSuccessMessage, RegistrationResources.RegistrationSuccessTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                var mainForm = new MainWindow(userId,Program.Container.Resolve<IDominoGameService>(),  
                    Program.Container.Resolve<IUserService>());
                mainForm.Show();
                this.Hide();
                logger.Info("Пользователь зарегистрировался");
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(RegistrationResources.RegistrationErrorTitle, ex.Message),
                    RegistrationResources.RegistrationErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Info("Пользователь переходит на первую форму анкеты");
            }
        }

        private void btnCheckPassword_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            RepeateMethod.TogglePasswordVisibility(textBoxPassword, isPasswordVisible);
        }

        private void btnCheckRepPassword_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            RepeateMethod.TogglePasswordVisibility(txtPasswordRepeate, isPasswordVisible);
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

    }
}