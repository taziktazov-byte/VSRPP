namespace Lab01.Forms
{
    partial class ProfileForm
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.grpProfile = new System.Windows.Forms.GroupBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblFaculty = new System.Windows.Forms.Label();
            this.lblRegisteredAt = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.grpSubscription = new System.Windows.Forms.GroupBox();
            this.chkSubscribed = new System.Windows.Forms.CheckBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnSaveSubscription = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.grpProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.grpSubscription.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblHeader.Location = new System.Drawing.Point(20, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(260, 28);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Личный кабинет";
            // 
            // picAvatar
            // 
            this.picAvatar.Location = new System.Drawing.Point(20, 56);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(140, 140);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 1;
            this.picAvatar.TabStop = false;
            // 
            // grpProfile
            // 
            this.grpProfile.Controls.Add(this.lblFullName);
            this.grpProfile.Controls.Add(this.lblLogin);
            this.grpProfile.Controls.Add(this.lblBirthDate);
            this.grpProfile.Controls.Add(this.lblAge);
            this.grpProfile.Controls.Add(this.lblGender);
            this.grpProfile.Controls.Add(this.lblFaculty);
            this.grpProfile.Controls.Add(this.lblRegisteredAt);
            this.grpProfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpProfile.Location = new System.Drawing.Point(176, 52);
            this.grpProfile.Name = "grpProfile";
            this.grpProfile.Size = new System.Drawing.Size(404, 218);
            this.grpProfile.TabIndex = 2;
            this.grpProfile.TabStop = false;
            this.grpProfile.Text = "Сведения о пользователе";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblFullName.Location = new System.Drawing.Point(16, 26);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(100, 19);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(16, 54);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(100, 19);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Логин:";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(16, 80);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(120, 19);
            this.lblBirthDate.TabIndex = 2;
            this.lblBirthDate.Text = "Дата рождения:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(16, 106);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(100, 19);
            this.lblAge.TabIndex = 3;
            this.lblAge.Text = "Возраст:";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(16, 132);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(100, 19);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Пол:";
            // 
            // lblFaculty
            // 
            this.lblFaculty.AutoSize = true;
            this.lblFaculty.Location = new System.Drawing.Point(16, 158);
            this.lblFaculty.Name = "lblFaculty";
            this.lblFaculty.Size = new System.Drawing.Size(100, 19);
            this.lblFaculty.TabIndex = 5;
            this.lblFaculty.Text = "Факультет:";
            // 
            // lblRegisteredAt
            // 
            this.lblRegisteredAt.AutoSize = true;
            this.lblRegisteredAt.Location = new System.Drawing.Point(16, 184);
            this.lblRegisteredAt.Name = "lblRegisteredAt";
            this.lblRegisteredAt.Size = new System.Drawing.Size(140, 19);
            this.lblRegisteredAt.TabIndex = 6;
            this.lblRegisteredAt.Text = "Дата регистрации:";
            // 
            // grpSubscription
            // 
            this.grpSubscription.Controls.Add(this.chkSubscribed);
            this.grpSubscription.Controls.Add(this.lblEmail);
            this.grpSubscription.Controls.Add(this.txtEmail);
            this.grpSubscription.Controls.Add(this.btnSaveSubscription);
            this.grpSubscription.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.grpSubscription.Location = new System.Drawing.Point(20, 282);
            this.grpSubscription.Name = "grpSubscription";
            this.grpSubscription.Size = new System.Drawing.Size(560, 108);
            this.grpSubscription.TabIndex = 3;
            this.grpSubscription.TabStop = false;
            this.grpSubscription.Text = "Управление подпиской";
            // 
            // chkSubscribed
            // 
            this.chkSubscribed.AutoSize = true;
            this.chkSubscribed.Location = new System.Drawing.Point(16, 28);
            this.chkSubscribed.Name = "chkSubscribed";
            this.chkSubscribed.Size = new System.Drawing.Size(220, 23);
            this.chkSubscribed.TabIndex = 0;
            this.chkSubscribed.Text = "Подписка на email-рассылку";
            this.chkSubscribed.CheckedChanged += new System.EventHandler(this.ChkSubscribed_CheckedChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(16, 62);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 19);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(70, 59);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(306, 25);
            this.txtEmail.TabIndex = 2;
            // 
            // btnSaveSubscription
            // 
            this.btnSaveSubscription.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSaveSubscription.Location = new System.Drawing.Point(392, 56);
            this.btnSaveSubscription.Name = "btnSaveSubscription";
            this.btnSaveSubscription.Size = new System.Drawing.Size(150, 32);
            this.btnSaveSubscription.TabIndex = 3;
            this.btnSaveSubscription.Text = "Сохранить";
            this.btnSaveSubscription.Click += new System.EventHandler(this.BtnSaveSubscription_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(430, 404);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 36);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Выйти";
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 456);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.grpSubscription);
            this.Controls.Add(this.grpProfile);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.lblHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №1 — Профиль";
            this.grpProfile.ResumeLayout(false);
            this.grpProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.grpSubscription.ResumeLayout(false);
            this.grpSubscription.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblHeader = null!;
        private System.Windows.Forms.PictureBox picAvatar = null!;
        private System.Windows.Forms.GroupBox grpProfile = null!;
        private System.Windows.Forms.Label lblFullName = null!;
        private System.Windows.Forms.Label lblLogin = null!;
        private System.Windows.Forms.Label lblBirthDate = null!;
        private System.Windows.Forms.Label lblAge = null!;
        private System.Windows.Forms.Label lblGender = null!;
        private System.Windows.Forms.Label lblFaculty = null!;
        private System.Windows.Forms.Label lblRegisteredAt = null!;
        private System.Windows.Forms.GroupBox grpSubscription = null!;
        private System.Windows.Forms.CheckBox chkSubscribed = null!;
        private System.Windows.Forms.Label lblEmail = null!;
        private System.Windows.Forms.TextBox txtEmail = null!;
        private System.Windows.Forms.Button btnSaveSubscription = null!;
        private System.Windows.Forms.Button btnLogout = null!;
    }
}
