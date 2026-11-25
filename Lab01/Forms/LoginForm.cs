using System;
using System.Windows.Forms;
using Lab01.Services;

namespace Lab01.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Введите логин и пароль.";
                return;
            }

            var user = _userService.Authenticate(login, password);
            if (user == null)
            {
                lblStatus.Text = "Неверный логин или пароль.";
                return;
            }

            Hide();
            using (var profileForm = new ProfileForm(user, _userService))
            {
                profileForm.ShowDialog(this);
            }

            txtPassword.Clear();
            lblStatus.Text = string.Empty;
            Show();
        }

        private void BtnRegister_Click(object? sender, EventArgs e)
        {
            lblStatus.Text = string.Empty;
            using var regForm = new RegisterForm(_userService);
            if (regForm.ShowDialog(this) == DialogResult.OK && !string.IsNullOrEmpty(regForm.RegisteredLogin))
            {
                txtLogin.Text = regForm.RegisteredLogin;
                txtPassword.Clear();
                txtPassword.Focus();
                MessageBox.Show("Регистрация прошла успешно! Теперь вы можете войти.", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
