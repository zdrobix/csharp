using System;

namespace loginApplicationUI
{
	partial class Form1
	{
		private System.ComponentModel.IContainer components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			loginPanel = new Panel();
			loginButton = new Button();
			passwordTextBox = new TextBox();
			usernameTextBox = new TextBox();
			signupPanel = new Panel();
			panelSignupOrganizator = new Panel();
			tipOrganizatorComboBox = new ComboBox();
			signupButtonOrganizator = new Button();
			cuiOrganizatorTextBox = new TextBox();
			numeOrganizatorTextBox = new TextBox();
			panelSignupUser = new Panel();
			ocupatieComboBox = new ComboBox();
			signupButtonUser = new Button();
			cnpSignupTextBox = new TextBox();
			numeSignupTextBox = new TextBox();
			signupButton = new Button();
			passwordSignupTextBox = new TextBox();
			phoneTextBox = new TextBox();
			usernameSignupTextBox = new TextBox();
			isOrganizatorCheckBox = new CheckBox();
			emailTextBox = new TextBox();
			labelPanel = new Panel();
			labelLogin = new Label();
			labelSignup = new Label();
			loginPanel.SuspendLayout();
			signupPanel.SuspendLayout();
			panelSignupOrganizator.SuspendLayout();
			panelSignupUser.SuspendLayout();
			labelPanel.SuspendLayout();
			SuspendLayout();
			// 
			// loginPanel
			// 
			loginPanel.BackColor = SystemColors.ActiveCaption;
			loginPanel.Controls.Add(loginButton);
			loginPanel.Controls.Add(passwordTextBox);
			loginPanel.Controls.Add(usernameTextBox);
			loginPanel.Location = new Point(250, 150);
			loginPanel.Name = "loginPanel";
			loginPanel.Size = new Size(300, 275);
			loginPanel.TabIndex = 0;
			// 
			// loginButton
			// 
			loginButton.Location = new Point(100, 158);
			loginButton.Name = "loginButton";
			loginButton.Size = new Size(100, 25);
			loginButton.TabIndex = 2;
			loginButton.Text = "log in";
			loginButton.UseVisualStyleBackColor = true;
			// 
			// passwordTextBox
			// 
			passwordTextBox.Location = new Point(100, 129);
			passwordTextBox.Name = "passwordTextBox";
			passwordTextBox.PasswordChar = '*';
			passwordTextBox.PlaceholderText = "password";
			passwordTextBox.Size = new Size(100, 23);
			passwordTextBox.TabIndex = 1;
			passwordTextBox.UseSystemPasswordChar = true;
			// 
			// usernameTextBox
			// 
			usernameTextBox.Location = new Point(100, 100);
			usernameTextBox.Name = "usernameTextBox";
			usernameTextBox.PlaceholderText = "username";
			usernameTextBox.Size = new Size(100, 23);
			usernameTextBox.TabIndex = 0;
			// 
			// signupPanel
			// 
			signupPanel.BackColor = SystemColors.ActiveCaption;
			signupPanel.Controls.Add(signupButton);
			signupPanel.Controls.Add(passwordSignupTextBox);
			signupPanel.Controls.Add(phoneTextBox);
			signupPanel.Controls.Add(usernameSignupTextBox);
			signupPanel.Controls.Add(isOrganizatorCheckBox);
			signupPanel.Controls.Add(emailTextBox);
			signupPanel.Location = new Point(250, 150);
			signupPanel.Name = "signupPanel";
			signupPanel.Size = new Size(300, 275);
			signupPanel.TabIndex = 3;
			// 
			// panelSignupOrganizator
			// 
			panelSignupOrganizator.BackColor = SystemColors.ActiveCaption;
			panelSignupOrganizator.Controls.Add(tipOrganizatorComboBox);
			panelSignupOrganizator.Controls.Add(signupButtonOrganizator);
			panelSignupOrganizator.Controls.Add(cuiOrganizatorTextBox);
			panelSignupOrganizator.Controls.Add(numeOrganizatorTextBox);
			panelSignupOrganizator.Location = new Point(0, 0);
			panelSignupOrganizator.Name = "panelSignupOrganizator";
			panelSignupOrganizator.Size = new Size(300, 275);
			panelSignupOrganizator.TabIndex = 8;
			// 
			// tipOrganizatorComboBox
			// 
			tipOrganizatorComboBox.FormattingEnabled = true;
			tipOrganizatorComboBox.Location = new Point(100, 156);
			tipOrganizatorComboBox.Name = "tipOrganizatorComboBox";
			tipOrganizatorComboBox.Size = new Size(100, 23);
			tipOrganizatorComboBox.TabIndex = 6;
			tipOrganizatorComboBox.Text = "Tip";
			// 
			// signupButtonOrganizator
			// 
			signupButtonOrganizator.Location = new Point(102, 183);
			signupButtonOrganizator.Name = "signupButtonOrganizator";
			signupButtonOrganizator.Size = new Size(100, 25);
			signupButtonOrganizator.TabIndex = 4;
			signupButtonOrganizator.Text = "create account";
			signupButtonOrganizator.UseVisualStyleBackColor = true;
			// 
			// cuiOrganizatorTextBox
			// 
			cuiOrganizatorTextBox.Location = new Point(102, 129);
			cuiOrganizatorTextBox.Name = "cuiOrganizatorTextBox";
			cuiOrganizatorTextBox.PlaceholderText = "CUI";
			cuiOrganizatorTextBox.Size = new Size(100, 23);
			cuiOrganizatorTextBox.TabIndex = 5;
			// 
			// numeOrganizatorTextBox
			// 
			numeOrganizatorTextBox.Location = new Point(102, 100);
			numeOrganizatorTextBox.Name = "numeOrganizatorTextBox";
			numeOrganizatorTextBox.PlaceholderText = "nume";
			numeOrganizatorTextBox.Size = new Size(100, 23);
			numeOrganizatorTextBox.TabIndex = 4;
			// 
			// panelSignupUser
			// 
			panelSignupUser.BackColor = SystemColors.ActiveCaption;
			panelSignupUser.Controls.Add(ocupatieComboBox);
			panelSignupUser.Controls.Add(signupButtonUser);
			panelSignupUser.Controls.Add(cnpSignupTextBox);
			panelSignupUser.Controls.Add(numeSignupTextBox);
			panelSignupUser.Location = new Point(0, 0);
			panelSignupUser.Name = "panelSignupUser";
			panelSignupUser.Size = new Size(300, 275);
			panelSignupUser.TabIndex = 9;
			// 
			// ocupatieComboBox
			// 
			ocupatieComboBox.FormattingEnabled = true;
			ocupatieComboBox.Location = new Point(100, 156);
			ocupatieComboBox.Name = "ocupatieComboBox";
			ocupatieComboBox.Size = new Size(100, 23);
			ocupatieComboBox.TabIndex = 6;
			ocupatieComboBox.Text = "Ocupatie";
			// 
			// signupButtonUser
			// 
			signupButtonUser.Location = new Point(102, 183);
			signupButtonUser.Name = "signupButtonUser";
			signupButtonUser.Size = new Size(100, 25);
			signupButtonUser.TabIndex = 4;
			signupButtonUser.Text = "create account";
			signupButtonUser.UseVisualStyleBackColor = true;
			// 
			// cnpSignupTextBox
			// 
			cnpSignupTextBox.Location = new Point(102, 129);
			cnpSignupTextBox.Name = "cnpSignupTextBox";
			cnpSignupTextBox.PlaceholderText = "CNP";
			cnpSignupTextBox.Size = new Size(100, 23);
			cnpSignupTextBox.TabIndex = 5;
			// 
			// numeSignupTextBox
			// 
			numeSignupTextBox.Location = new Point(102, 100);
			numeSignupTextBox.Name = "numeSignupTextBox";
			numeSignupTextBox.PlaceholderText = "nume";
			numeSignupTextBox.Size = new Size(100, 23);
			numeSignupTextBox.TabIndex = 4;
			// 
			// signupButton
			// 
			signupButton.Location = new Point(102, 183);
			signupButton.Name = "signupButton";
			signupButton.Size = new Size(100, 25);
			signupButton.TabIndex = 4;
			signupButton.Text = "sign up";
			signupButton.UseVisualStyleBackColor = true;
			signupButton.Click += signupButton_Click;
			// 
			// passwordSignupTextBox
			// 
			passwordSignupTextBox.Location = new Point(102, 158);
			passwordSignupTextBox.Name = "passwordSignupTextBox";
			passwordSignupTextBox.PlaceholderText = "password";
			passwordSignupTextBox.Size = new Size(100, 23);
			passwordSignupTextBox.TabIndex = 6;
			passwordSignupTextBox.UseSystemPasswordChar = true;
			// 
			// phoneTextBox
			// 
			phoneTextBox.Location = new Point(102, 129);
			phoneTextBox.Name = "phoneTextBox";
			phoneTextBox.PlaceholderText = "phone";
			phoneTextBox.Size = new Size(100, 23);
			phoneTextBox.TabIndex = 5;
			// 
			// usernameSignupTextBox
			// 
			usernameSignupTextBox.Location = new Point(102, 100);
			usernameSignupTextBox.Name = "usernameSignupTextBox";
			usernameSignupTextBox.PlaceholderText = "username";
			usernameSignupTextBox.Size = new Size(100, 23);
			usernameSignupTextBox.TabIndex = 4;
			// 
			// isOrganizatorCheckBox
			// 
			isOrganizatorCheckBox.AutoSize = true;
			isOrganizatorCheckBox.Location = new Point(102, 46);
			isOrganizatorCheckBox.Name = "isOrganizatorCheckBox";
			isOrganizatorCheckBox.Size = new Size(88, 19);
			isOrganizatorCheckBox.TabIndex = 7;
			isOrganizatorCheckBox.Text = "Organizator";
			isOrganizatorCheckBox.UseVisualStyleBackColor = true;
			// 
			// emailTextBox
			// 
			emailTextBox.Location = new Point(102, 71);
			emailTextBox.Name = "emailTextBox";
			emailTextBox.PlaceholderText = "email";
			emailTextBox.Size = new Size(100, 23);
			emailTextBox.TabIndex = 3;
			// 
			// labelPanel
			// 
			labelPanel.BackColor = SystemColors.ActiveCaption;
			labelPanel.Controls.Add(labelLogin);
			labelPanel.Controls.Add(labelSignup);
			labelPanel.Location = new Point(350, 360);
			labelPanel.Name = "labelPanel";
			labelPanel.Size = new Size(100, 30);
			labelPanel.TabIndex = 1;
			// 
			// labelLogin
			// 
			labelLogin.AutoSize = true;
			labelLogin.Location = new Point(0, 9);
			labelLogin.Name = "labelLogin";
			labelLogin.Size = new Size(37, 15);
			labelLogin.TabIndex = 3;
			labelLogin.Text = "LogIn";
			labelLogin.Click += labelLogin_Click;
			// 
			// labelSignup
			// 
			labelSignup.AutoSize = true;
			labelSignup.Location = new Point(55, 9);
			labelSignup.Name = "labelSignup";
			labelSignup.Size = new Size(45, 15);
			labelSignup.TabIndex = 4;
			labelSignup.Text = "SignUp";
			labelSignup.Click += labelSignup_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(784, 561);
			Controls.Add(labelPanel);
			Controls.Add(signupPanel);
			Controls.Add(loginPanel);
			Name = "Form1";
			Text = "Application";
			loginPanel.ResumeLayout(false);
			loginPanel.PerformLayout();
			signupPanel.ResumeLayout(false);
			signupPanel.PerformLayout();
			panelSignupOrganizator.ResumeLayout(false);
			panelSignupOrganizator.PerformLayout();
			panelSignupUser.ResumeLayout(false);
			panelSignupUser.PerformLayout();
			labelPanel.ResumeLayout(false);
			labelPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel loginPanel;
		private TextBox passwordTextBox;
		private TextBox usernameTextBox;
		private Button loginButton;
		private Label labelLogin;
		private Label labelSignup;
		private Panel labelPanel;
		private Panel signupPanel;
		private TextBox passwordSignupTextBox;
		private TextBox phoneTextBox;
		private TextBox usernameSignupTextBox;
		private TextBox emailTextBox;
		private Button signupButton;
		private CheckBox isOrganizatorCheckBox;
		private Panel panelSignupOrganizator;
		private Button signupButtonOrganizator;
		private TextBox cuiOrganizatorTextBox;
		private TextBox numeOrganizatorTextBox;
		private ComboBox tipOrganizatorComboBox;
		private Panel panelSignupUser;
		private ComboBox ocupatieComboBox;
		private Button signupButtonUser;
		private TextBox cnpSignupTextBox;
		private TextBox numeSignupTextBox;
	}
}
