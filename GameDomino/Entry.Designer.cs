namespace Domino
{
    partial class Entry
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Entry));
            lblTitle = new Label();
            lnlLogin = new Label();
            labelPassword = new Label();
            lblNoAccount = new Label();
            textBoxLogin = new TextBox();
            textBoxPassword = new TextBox();
            btnCheckPassword = new Button();
            btnEntry = new Button();
            btnRegistration = new Button();
            btnRussian = new Button();
            btnEnglish = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(276, 57);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(309, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Доминирование";
            // 
            // lnlLogin
            // 
            lnlLogin.AutoSize = true;
            lnlLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lnlLogin.Location = new Point(276, 122);
            lnlLogin.Name = "lnlLogin";
            lnlLogin.Size = new Size(58, 23);
            lnlLogin.TabIndex = 1;
            lnlLogin.Text = "Логин";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            labelPassword.Location = new Point(276, 188);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(69, 23);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Пароль";
            // 
            // lblNoAccount
            // 
            lblNoAccount.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblNoAccount.Location = new Point(276, 332);
            lblNoAccount.Name = "lblNoAccount";
            lblNoAccount.Size = new Size(156, 29);
            lblNoAccount.TabIndex = 3;
            lblNoAccount.Text = "Нет аккаунта?";
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(276, 148);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(309, 27);
            textBoxLogin.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(276, 214);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(309, 27);
            textBoxPassword.TabIndex = 5;
            // 
            // btnCheckPassword
            // 
            btnCheckPassword.BackgroundImage = (Image)resources.GetObject("btnCheckPassword.BackgroundImage");
            btnCheckPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnCheckPassword.Location = new Point(548, 212);
            btnCheckPassword.Name = "btnCheckPassword";
            btnCheckPassword.Size = new Size(37, 29);
            btnCheckPassword.TabIndex = 6;
            btnCheckPassword.UseVisualStyleBackColor = true;
            btnCheckPassword.Click += btnCheckPassword_Click;
            // 
            // btnEntry
            // 
            btnEntry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnEntry.Location = new Point(340, 272);
            btnEntry.Name = "btnEntry";
            btnEntry.Size = new Size(186, 38);
            btnEntry.TabIndex = 7;
            btnEntry.Text = "Вход";
            btnEntry.UseVisualStyleBackColor = true;
            btnEntry.Click += btnEntry_Click_1;
            // 
            // btnRegistration
            // 
            btnRegistration.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRegistration.Location = new Point(428, 331);
            btnRegistration.Name = "btnRegistration";
            btnRegistration.Size = new Size(157, 30);
            btnRegistration.TabIndex = 8;
            btnRegistration.Text = "Регистрация";
            btnRegistration.UseVisualStyleBackColor = true;
            btnRegistration.Click += btnRegistration_Click_1;
            // 
            // btnRussian
            // 
            btnRussian.Location = new Point(577, 409);
            btnRussian.Name = "btnRussian";
            btnRussian.Size = new Size(112, 38);
            btnRussian.TabIndex = 9;
            btnRussian.Text = "Русский";
            btnRussian.UseVisualStyleBackColor = true;
            btnRussian.Click += btnRussian_Click;
            // 
            // btnEnglish
            // 
            btnEnglish.Location = new Point(695, 409);
            btnEnglish.Name = "btnEnglish";
            btnEnglish.RightToLeft = RightToLeft.No;
            btnEnglish.Size = new Size(123, 38);
            btnEnglish.TabIndex = 10;
            btnEnglish.Text = "Английский";
            btnEnglish.UseVisualStyleBackColor = true;
            btnEnglish.Click += btnEnglish_Click;
            // 
            // Entry
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 459);
            Controls.Add(btnEnglish);
            Controls.Add(btnRussian);
            Controls.Add(btnRegistration);
            Controls.Add(btnEntry);
            Controls.Add(btnCheckPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(lblNoAccount);
            Controls.Add(labelPassword);
            Controls.Add(lnlLogin);
            Controls.Add(lblTitle);
            Name = "Entry";
            Text = "Вход";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lnlLogin;
        private Label labelPassword;
        private Label lblNoAccount;
        private TextBox textBoxLogin;
        private TextBox textBoxPassword;
        private Button btnCheckPassword;
        private Button btnEntry;
        private Button btnRegistration;
        private Button btnRussian;
        private Button btnEnglish;
    }
}