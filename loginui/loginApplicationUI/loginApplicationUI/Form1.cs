using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;

namespace loginApplicationUI
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.showLogin();
			this.panelSignupOrganizator.Visible = false;
			this.panelSignupUser.Visible = false;
		}

		public void showLogin()
		{
			this.loginPanel.Visible = true;
			this.signupPanel.Visible = false;
			this.labelLogin.Font = new Font(this.labelLogin.Font, FontStyle.Underline);
			this.labelSignup.Font = new Font(this.labelSignup.Font, FontStyle.Regular);

		}
		private void showSignup()
		{
			this.loginPanel.Visible = false;
			this.signupPanel.Visible = true;
			this.labelLogin.Font = new Font(this.labelLogin.Font, FontStyle.Regular);
			this.labelSignup.Font = new Font(this.labelSignup.Font, FontStyle.Underline);
		}

		private void labelLogin_Click(object sender, EventArgs e)
		{
			this.showLogin();
		}

		private void labelSignup_Click(object sender, EventArgs e)
		{
			this.showSignup();
		}

		private void showSignupOrganizator()
		{
			this.panelSignupOrganizator.Visible = true;
			this.panelSignupUser.Visible = false;
		}

		private void showSignupUser()
		{
			this.panelSignupUser.Visible = true;
			this.panelSignupOrganizator.Visible = false;
		}

		private bool areFieldsCompleted()
		{
			if (this.usernameSignupTextBox.Text.Length == 0)
				return false;
			if (this.passwordSignupTextBox.Text.Length == 0)
				return false;
			if (this.emailTextBox.Text.Length == 0)
				return false;
			if (this.phoneTextBox.Text.Length == 0)
				return false;
			return true;
		}

		private void signupButton_Click(object sender, EventArgs e)
		{
			if (!this.areFieldsCompleted())
				return;
			this.labelPanel.Visible = false;
			this.signupPanel.Visible = false;
			if (this.isOrganizatorCheckBox.Checked)
				this.showSignupOrganizator();
			else this.showSignupUser();
		}
	}
}
