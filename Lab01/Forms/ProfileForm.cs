using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Lab01.Helpers;
using Lab01.Models;
using Lab01.Services;

namespace Lab01.Forms
{
    public partial class ProfileForm : Form
    {
        private readonly User _user;
        private readonly UserService _userService;

        public ProfileForm(User user, UserService userService)
        {
            InitializeComponent();
            _user = user;
            _userService = userService;

            LoadUserData();
            ThemeHelper.ApplyGenderTheme(this, _user.Gender, btnSaveSubscription, btnLogout);
            ThemeHelper.SetAvatar(picAvatar, _user.Gender);
        }

        private void LoadUserData()
        {
            lblFullName.Text = $"ФИО: {_user.FullName}";
            lblLogin.Text = $"Логин: {_user.Login}";
            lblBirthDate.Text = $"Дата рождения: {_user.BirthDate:dd.MM.yyyy}";
            lblAge.Text = $"Возраст: {_user.Age} лет";
            lblGender.Text = $"Пол: {_user.Gender}";
            lblFaculty.Text = $"Факультет: {_user.Faculty}";
            lblRegisteredAt.Text = $"Дата регистрации: {_user.RegisteredAt:dd.MM.yyyy HH:mm}";

            chkSubscribed.Checked = _user.IsSubscribed;
            txtEmail.Text = _user.Email;
            txtEmail.Enabled = _user.IsSubscribed;
        }

        private void ChkSubscribed_CheckedChanged(object? sender, EventArgs e)
        {
            txtEmail.Enabled = chkSubscribed.Checked;
            if (!chkSubscribed.Checked)
            {
                txtEmail.Clear();
            }
        }

        private void BtnSaveSubscription_Click(object? sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (chkSubscribed.Checked &&
                (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")))
            {
                MessageBox.Show("Введите корректный Email для оформления подписки.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _user.IsSubscribed = chkSubscribed.Checked;
            _user.Email = chkSubscribed.Checked ? email : string.Empty;
            _userService.UpdateSubscription(_user.Id, _user.IsSubscribed, _user.Email);

            MessageBox.Show("Настройки подписки сохранены в users.json.", "Успех",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}
