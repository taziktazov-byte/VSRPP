using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Lab01.Helpers;
using Lab01.Models;
using Lab01.Services;

namespace Lab01.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly UserService _userService;

        public string RegisteredLogin { get; private set; } = string.Empty;

        public RegisterForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
            dtpBirthDate.MaxDate = DateTime.Today;
            dtpBirthDate.Value = DateTime.Today.AddYears(-19);
            if (cmbFaculty.Items.Count > 0)
            {
                cmbFaculty.SelectedIndex = 0;
            }
            UpdateGenderVisuals();
        }

        private string SelectedGender => rbFemale.Checked ? "Женский" : "Мужской";

        private void UpdateGenderVisuals()
        {
            ThemeHelper.ApplyGenderTheme(this, SelectedGender, btnSubmit);
            ThemeHelper.SetAvatar(picAvatar, SelectedGender);
        }

        private void Gender_CheckedChanged(object? sender, EventArgs e)
        {
            UpdateGenderVisuals();
        }

        private void ChkSubscribe_CheckedChanged(object? sender, EventArgs e)
        {
            txtEmail.Enabled = chkSubscribe.Checked;
            if (!chkSubscribe.Checked)
            {
                txtEmail.Clear();
            }
        }

        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text;
            string confirm = txtConfirm.Text;
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || fullName.Length < 3)
            {
                ShowValidationError("Введите корректное ФИО (не менее 3 символов).");
                return;
            }

            if (string.IsNullOrWhiteSpace(login) || login.Length < 3)
            {
                ShowValidationError("Логин должен содержать не менее 3 символов.");
                return;
            }

            if (password.Length < 4)
            {
                ShowValidationError("Пароль должен содержать не менее 4 символов.");
                return;
            }

            if (password != confirm)
            {
                ShowValidationError("Пароль и подтверждение пароля не совпадают.");
                return;
            }

            if (User.CalculateAge(dtpBirthDate.Value) < 14)
            {
                ShowValidationError("Возраст пользователя должен быть не менее 14 лет.");
                return;
            }

            if (cmbFaculty.SelectedItem == null)
            {
                ShowValidationError("Выберите факультет.");
                return;
            }

            if (chkSubscribe.Checked)
            {
                if (string.IsNullOrWhiteSpace(email) ||
                    !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    ShowValidationError("Введите корректный Email для подписки.");
                    return;
                }
            }

            var newUser = new User
            {
                FullName = fullName,
                Login = login,
                Password = password,
                BirthDate = dtpBirthDate.Value.Date,
                Gender = SelectedGender,
                Faculty = cmbFaculty.SelectedItem.ToString() ?? string.Empty,
                IsSubscribed = chkSubscribe.Checked,
                Email = chkSubscribe.Checked ? email : string.Empty
            };

            if (!_userService.Register(newUser, out string error))
            {
                ShowValidationError(error);
                return;
            }

            RegisteredLogin = newUser.Login;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private static void ShowValidationError(string message)
        {
            MessageBox.Show(message, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
