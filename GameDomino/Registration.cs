using Domino2;
using GameDomino;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace Domino
{
    /// <summary>
    /// класс формы регистрации
    /// </summary>
    public partial class Registration : Form
    {
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
        }

        private void btnRegistration2_Click_1(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string pass = textBoxPassword.Text;
            string passRepeate = txtPasswordRepeate.Text;


            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(passRepeate))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (pass != passRepeate)
            {
                MessageBox.Show("Пароли не совпадают.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(pass, @"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
            {
                MessageBox.Show("Пароль должен содержать минимум 8 символов, хотя бы одну цифру или спецсимвол, а также хотя бы одну заглавную и одну строчную латинскую букву.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(login, @"^[a-zA-Z][a-zA-Z0-9]{1,19}$"))
            {
                MessageBox.Show("Логин должен содержать от 2 до 20 символов, начинаться с буквы и состоять только из латинских букв и цифр.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_userService.LoginIsTaken(login))
            {
                MessageBox.Show("Такой логин уже занят!", "Ошибка регистрации",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLogin.Focus();
                textBoxLogin.SelectAll();
                return;
            }
            try
            {
                Guid userId = _userService.RegisterNewUser(login, pass);
                MessageBox.Show("Регистрация прошла успешно!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                var mainForm = Program.Container.Resolve<MainWindow>();
                mainForm.SetUserId(userId);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при регистрации: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
