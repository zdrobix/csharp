namespace NumericType
{
	public partial class NumericType : Form
	{
		public NumericType()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string minValue = this.minValueTextBox.Text;
			string maxValue = this.maxValueTextBox.Text;

			if (minValue.Length * maxValue.Length == 0)
			{
				this.resultLabelModification.Text = "Not enough data";
				return;
			}
			
		}

		private void wholeNumberCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			this.veryPreciseCheckBox.Visible = !this.wholeNumberCheckBox.Checked;
			this.veryPreciseCheckBox.Enabled = !this.wholeNumberCheckBox.Checked;
			this.veryPreciseCheckBox.Checked = this.wholeNumberCheckBox.Checked;
		}
	}
}
