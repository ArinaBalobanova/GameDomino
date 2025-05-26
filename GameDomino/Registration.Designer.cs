namespace Domino
{
    partial class Registration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registration));
            lblRegistration = new Label();
            lblPassword = new Label();
            lblLogin = new Label();
            lblPasswortRepeate = new Label();
            btnRegistration2 = new Button();
            textBoxLogin = new TextBox();
            txtPasswordRepeate = new TextBox();
            textBoxPassword = new TextBox();
            btnCheckPassword = new Button();
            btnCheckRepPassword = new Button();
            SuspendLayout();
            // 
            // lblRegistration
            // 
            lblRegistration.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRegistration.Location = new Point(323, 75);
            lblRegistration.Name = "lblRegistration";
            lblRegistration.Size = new Size(227, 46);
            lblRegistration.TabIndex = 0;
            lblRegistration.Text = "Регистрация";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPassword.Location = new Point(298, 204);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(69, 23);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLogin.Location = new Point(298, 139);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(58, 23);
            lblLogin.TabIndex = 2;
            lblLogin.Text = "Логин";
            // 
            // lblPasswortRepeate
            // 
            lblPasswortRepeate.AutoSize = true;
            lblPasswortRepeate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPasswortRepeate.Location = new Point(298, 267);
            lblPasswortRepeate.Name = "lblPasswortRepeate";
            lblPasswortRepeate.Size = new Size(156, 23);
            lblPasswortRepeate.TabIndex = 3;
            lblPasswortRepeate.Text = "Повторите пароль";
            // 
            // btnRegistration2
            // 
            btnRegistration2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnRegistration2.Location = new Point(323, 347);
            btnRegistration2.Name = "btnRegistration2";
            btnRegistration2.Size = new Size(205, 36);
            btnRegistration2.TabIndex = 5;
            btnRegistration2.Text = "Зарегистрироваться";
            btnRegistration2.UseVisualStyleBackColor = true;
            btnRegistration2.Click += btnRegistration2_Click_1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(298, 165);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(268, 27);
            textBoxLogin.TabIndex = 7;
            // 
            // txtPasswordRepeate
            // 
            txtPasswordRepeate.Location = new Point(298, 293);
            txtPasswordRepeate.Name = "txtPasswordRepeate";
            txtPasswordRepeate.Size = new Size(268, 27);
            txtPasswordRepeate.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(298, 230);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(268, 27);
            textBoxPassword.TabIndex = 9;
            // 
            // btnCheckPassword
            // 
            btnCheckPassword.BackgroundImage = (Image)resources.GetObject("btnCheckPassword.BackgroundImage");
            btnCheckPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnCheckPassword.Location = new Point(528, 228);
            btnCheckPassword.Name = "btnCheckPassword";
            btnCheckPassword.Size = new Size(38, 29);
            btnCheckPassword.TabIndex = 10;
            btnCheckPassword.UseVisualStyleBackColor = true;
            btnCheckPassword.Click += btnCheckPassword_Click_1;
            // 
            // btnCheckRepPassword
            // 
            btnCheckRepPassword.BackgroundImage = (Image)resources.GetObject("btnCheckRepPassword.BackgroundImage");
            btnCheckRepPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnCheckRepPassword.Location = new Point(528, 292);
            btnCheckRepPassword.Name = "btnCheckRepPassword";
            btnCheckRepPassword.Size = new Size(38, 29);
            btnCheckRepPassword.TabIndex = 11;
            btnCheckRepPassword.UseVisualStyleBackColor = true;
            btnCheckRepPassword.Click += btnCheckRepPassword_Click_1;
            // 
            // Registration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCheckRepPassword);
            Controls.Add(btnCheckPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(txtPasswordRepeate);
            Controls.Add(textBoxLogin);
            Controls.Add(btnRegistration2);
            Controls.Add(lblPasswortRepeate);
            Controls.Add(lblLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblRegistration);
            Name = "Registration";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegistration;
        private Label lblPassword;
        private Label lblLogin;
        private Label lblPasswortRepeate;
        private Button btnRegistration2;
        private TextBox textBoxLogin;
        private TextBox txtPasswordRepeate;
        private TextBox textBoxPassword;
        private Button btnCheckPassword;
        private Button btnCheckRepPassword;
    }
}