namespace Lab01.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer? components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.chkSubscribe = new System.Windows.Forms.CheckBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.grpVisual = new System.Windows.Forms.GroupBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.lblThemeHint = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpInfo.SuspendLayout();
            this.grpVisual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(260, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Регистрация пользователя";
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.lblFullName);
            this.grpInfo.Controls.Add(this.txtFullName);
            this.grpInfo.Controls.Add(this.lblLogin);
            this.grpInfo.Controls.Add(this.txtLogin);
            this.grpInfo.Controls.Add(this.lblPassword);
            this.grpInfo.Controls.Add(this.txtPassword);
            this.grpInfo.Controls.Add(this.lblConfirm);
            this.grpInfo.Controls.Add(this.txtConfirm);
            this.grpInfo.Controls.Add(this.lblBirthDate);
            this.grpInfo.Controls.Add(this.dtpBirthDate);
            this.grpInfo.Controls.Add(this.lblFaculty);
            this.grpInfo.Controls.Add(this.cmbFaculty);
            this.grpInfo.Controls.Add(this.lblGender);
            this.grpInfo.Controls.Add(this.rbMale);
            this.grpInfo.Controls.Add(this.rbFemale);
            this.grpInfo.Controls.Add(this.chkSubscribe);
            this.grpInfo.Controls.Add(this.lblEmail);
            this.grpInfo.Controls.Add(this.txtEmail);
            this.grpInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpInfo.Location = new System.Drawing.Point(20, 48);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(375, 420);
            this.grpInfo.TabIndex = 1;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Данные профиля";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(16, 26);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(42, 17);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(16, 46);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(340, 24);
            this.txtFullName.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(16, 76);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(46, 17);
            this.lblLogin.TabIndex = 2;
            this.lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(16, 96);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(340, 24);
            this.txtLogin.TabIndex = 3;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 126);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 17);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 146);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(162, 24);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(194, 126);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(112, 17);
            this.lblConfirm.TabIndex = 6;
            this.lblConfirm.Text = "Повтор пароля:";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Location = new System.Drawing.Point(194, 146);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.Size = new System.Drawing.Size(162, 24);
            this.txtConfirm.TabIndex = 7;
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(16, 178);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(108, 17);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "Дата рождения:";
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(16, 198);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(162, 24);
            this.dtpBirthDate.TabIndex = 9;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(194, 178);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 17);
            this.lblGender.TabIndex = 10;
            this.lblGender.Text = "Пол:";
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true;
            this.rbMale.Location = new System.Drawing.Point(194, 200);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(80, 21);
            this.rbMale.TabIndex = 11;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Мужской";
            this.rbMale.CheckedChanged += new System.EventHandler(this.Gender_CheckedChanged);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(280, 200);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(80, 21);
            this.rbFemale.TabIndex = 12;
            this.rbFemale.Text = "Женский";
            this.rbFemale.CheckedChanged += new System.EventHandler(this.Gender_CheckedChanged);
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(16, 234);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(78, 17);
            this.lblFaculty.TabIndex = 13;
            this.lblFaculty.Text = "Факультет:";
            // 
            // cmbFaculty
            // 
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.Items.AddRange(new object[] {
                "Факультет информационных технологий",
                "Факультет компьютерных систем и сетей",
                "Факультет радиотехники и электроники",
                "Инженерно-экономический факультет"
            });
            this.cmbFaculty.Location = new System.Drawing.Point(16, 254);
            this.cmbFaculty.Name = "cmbFaculty";
            this.cmbFaculty.Size = new System.Drawing.Size(340, 24);
            this.cmbFaculty.TabIndex = 14;
            // 
            // chkSubscribe
            // 
            this.chkSubscribe.AutoSize = true;
            this.chkSubscribe.Location = new System.Drawing.Point(16, 294);
            this.chkSubscribe.Name = "chkSubscribe";
            this.chkSubscribe.Size = new System.Drawing.Size(210, 21);
            this.chkSubscribe.TabIndex = 15;
            this.chkSubscribe.Text = "Подписаться на уведомления";
            this.chkSubscribe.CheckedChanged += new System.EventHandler(this.ChkSubscribe_CheckedChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 326);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(44, 17);
            this.lblEmail.TabIndex = 16;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(16, 346);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(340, 24);
            this.txtEmail.TabIndex = 17;
            // 
            // grpVisual
            // 
            this.grpVisual.Controls.Add(this.picAvatar);
            this.grpVisual.Controls.Add(this.lblThemeHint);
            this.grpVisual.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.grpVisual.Location = new System.Drawing.Point(408, 48);
            this.grpVisual.Name = "grpVisual";
            this.grpVisual.Size = new System.Drawing.Size(195, 250);
            this.grpVisual.TabIndex = 2;
            this.grpVisual.TabStop = false;
            this.grpVisual.Text = "Аватар и тема";
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(32, 34);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(130, 130);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // lblThemeHint
            // 
            this.lblThemeHint.Location = new System.Drawing.Point(12, 176);
            this.lblThemeHint.Name = "lblThemeHint";
            this.lblThemeHint.Size = new System.Drawing.Size(171, 60);
            this.lblThemeHint.TabIndex = 1;
            this.lblThemeHint.Text = "Тема оформления и аватар меняются при выборе пола";
            this.lblThemeHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmit.Location = new System.Drawing.Point(408, 380);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(195, 40);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Зарегистрироваться";
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Location = new System.Drawing.Point(408, 428);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(195, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 488);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.grpVisual);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Лабораторная работа №1 — Регистрация";
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            this.grpVisual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.GroupBox grpInfo = null!;
        private System.Windows.Forms.Label lblFullName = null!;
        private System.Windows.Forms.TextBox txtFullName = null!;
        private System.Windows.Forms.Label lblLogin = null!;
        private System.Windows.Forms.TextBox txtLogin = null!;
        private System.Windows.Forms.Label lblPassword = null!;
        private System.Windows.Forms.TextBox txtPassword = null!;
        private System.Windows.Forms.Label lblConfirm = null!;
        private System.Windows.Forms.TextBox txtConfirm = null!;
        private System.Windows.Forms.Label lblBirthDate = null!;
        private System.Windows.Forms.DateTimePicker dtpBirthDate = null!;
        private System.Windows.Forms.Label lblFaculty = null!;
        private System.Windows.Forms.ComboBox cmbFaculty = null!;
        private System.Windows.Forms.Label lblGender = null!;
        private System.Windows.Forms.RadioButton rbMale = null!;
        private System.Windows.Forms.RadioButton rbFemale = null!;
        private System.Windows.Forms.CheckBox chkSubscribe = null!;
        private System.Windows.Forms.Label lblEmail = null!;
        private System.Windows.Forms.TextBox txtEmail = null!;
        private System.Windows.Forms.GroupBox grpVisual = null!;
        private System.Windows.Forms.PictureBox picAvatar = null!;
        private System.Windows.Forms.Label lblThemeHint = null!;
        private System.Windows.Forms.Button btnSubmit = null!;
        private System.Windows.Forms.Button btnCancel = null!;
    }
}
