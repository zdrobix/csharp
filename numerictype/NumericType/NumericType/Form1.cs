namespace NumericType
{
	public partial class NumericType : Form
	{
		public NumericType()
		{
			InitializeComponent();
			this.wholeNumberCheckBox.Checked = true;
			this.veryPreciseCheckBox.Checked = false;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string minValue = this.minValueTextBox.Text;
			string maxValue = this.maxValueTextBox.Text;

			try
			{
				if (!Data.validateData(minValue, maxValue, this.wholeNumberCheckBox.Checked, this.veryPreciseCheckBox.Checked))
				{
					this.maxValueTextBox.BackColor = Color.Red;
					this.resultLabelModification.Text = "Min value larger than Max value";
				}
				else this.maxValueTextBox.BackColor = Color.White;
				this.resultLabelModification.Text = Numeric.getType(
					minValue,
					maxValue,
					this.wholeNumberCheckBox.Checked,
					this.veryPreciseCheckBox.Checked);
			}
			catch (Exception ex)
			{
				this.resultLabelModification.Text = ex.Message;
				return;
			}

		}

		private void wholeNumberCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (this.wholeNumberCheckBox.Checked)
			{
				this.veryPreciseCheckBox.Visible = false;
				this.veryPreciseCheckBox.Enabled = false;
				this.veryPreciseCheckBox.Checked = false;
			} else
			{
				this.veryPreciseCheckBox.Visible = true;
				this.veryPreciseCheckBox.Enabled = true;
			}
		}

	}
}
