namespace Lab01.Forms
{
    partial class LoginForm
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
            this.panelCard = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 58, 102);
            this.lblTitle.Location = new System.Drawing.Point(95, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Авторизация";
            // 
            // panelCard
            // 
            this.panelCard.BackColor = System.Drawing.Color.White;
            this.panelCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard.Controls.Add(this.lblLogin);
            this.panelCard.Controls.Add(this.txtLogin);
            this.panelCard.Controls.Add(this.lblPassword);
            this.panelCard.Controls.Add(this.txtPassword);
            this.panelCard.Controls.Add(this.btnLogin);
            this.panelCard.Controls.Add(this.btnRegister);
            this.panelCard.Location = new System.Drawing.Point(32, 68);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(336, 232);
            this.panelCard.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLogin.Location = new System.Drawing.Point(22, 20);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(50, 19);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLogin.Location = new System.Drawing.Point(22, 44);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(290, 25);
            this.txtLogin.TabIndex = 1;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.Location = new System.Drawing.Point(22, 82);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 19);
            this.lblPassword.TabIndex = 2;
            this.lblPassword.Text = "Пароль:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(22, 106);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(290, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(42, 110, 206);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(22, 152);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(138, 36);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Войти";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(236, 240, 245);
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRegister.Location = new System.Drawing.Point(174, 152);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(138, 36);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Регистрация";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblStatus.Location = new System.Drawing.Point(32, 310);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(336, 28);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 246, 252);
            this.ClientSize = new System.Drawing.Size(400, 350);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторная работа №1 — Вход";
            this.panelCard.ResumeLayout(false);
            this.panelCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.Panel panelCard = null!;
        private System.Windows.Forms.Label lblLogin = null!;
        private System.Windows.Forms.TextBox txtLogin = null!;
        private System.Windows.Forms.Label lblPassword = null!;
        private System.Windows.Forms.TextBox txtPassword = null!;
        private System.Windows.Forms.Button btnLogin = null!;
        private System.Windows.Forms.Button btnRegister = null!;
        private System.Windows.Forms.Label lblStatus = null!;
    }
}
