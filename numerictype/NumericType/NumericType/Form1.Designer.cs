namespace NumericType
{
	partial class NumericType
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			minValueLabel = new Label();
			maxValueLabel = new Label();
			minValueTextBox = new TextBox();
			maxValueTextBox = new TextBox();
			wholeNumberCheckBox = new CheckBox();
			veryPreciseCheckBox = new CheckBox();
			displayResultButton = new Button();
			resultLabelNoModification = new Label();
			resultLabelModification = new Label();
			SuspendLayout();
			// 
			// minValueLabel
			// 
			minValueLabel.AutoSize = true;
			minValueLabel.Location = new Point(30, 20);
			minValueLabel.Name = "minValueLabel";
			minValueLabel.Size = new Size(59, 15);
			minValueLabel.TabIndex = 0;
			minValueLabel.Text = "Min Value";
			// 
			// maxValueLabel
			// 
			maxValueLabel.AutoSize = true;
			maxValueLabel.Location = new Point(30, 50);
			maxValueLabel.Name = "maxValueLabel";
			maxValueLabel.Size = new Size(61, 15);
			maxValueLabel.TabIndex = 1;
			maxValueLabel.Text = "Max Value";
			// 
			// minValueTextBox
			// 
			minValueTextBox.Location = new Point(116, 17);
			minValueTextBox.Name = "minValueTextBox";
			minValueTextBox.Size = new Size(340, 23);
			minValueTextBox.TabIndex = 2;
			// 
			// maxValueTextBox
			// 
			maxValueTextBox.Location = new Point(116, 47);
			maxValueTextBox.Name = "maxValueTextBox";
			maxValueTextBox.Size = new Size(340, 23);
			maxValueTextBox.TabIndex = 3;
			// 
			// wholeNumberCheckBox
			// 
			wholeNumberCheckBox.AutoSize = true;
			wholeNumberCheckBox.Checked = true;
			wholeNumberCheckBox.CheckState = CheckState.Checked;
			wholeNumberCheckBox.Location = new Point(116, 92);
			wholeNumberCheckBox.Name = "wholeNumberCheckBox";
			wholeNumberCheckBox.Size = new Size(107, 19);
			wholeNumberCheckBox.TabIndex = 4;
			wholeNumberCheckBox.Text = "Whole Number";
			wholeNumberCheckBox.UseVisualStyleBackColor = true;
			wholeNumberCheckBox.CheckedChanged += wholeNumberCheckBox_CheckedChanged;
			// 
			// veryPreciseCheckBox
			// 
			veryPreciseCheckBox.AutoSize = true;
			veryPreciseCheckBox.Enabled = false;
			veryPreciseCheckBox.Location = new Point(272, 92);
			veryPreciseCheckBox.Name = "veryPreciseCheckBox";
			veryPreciseCheckBox.Size = new Size(88, 19);
			veryPreciseCheckBox.TabIndex = 5;
			veryPreciseCheckBox.Text = "Very Precise";
			veryPreciseCheckBox.UseVisualStyleBackColor = true;
			veryPreciseCheckBox.Visible = false;
			// 
			// displayResultButton
			// 
			displayResultButton.Location = new Point(116, 127);
			displayResultButton.Name = "displayResultButton";
			displayResultButton.Size = new Size(340, 22);
			displayResultButton.TabIndex = 6;
			displayResultButton.Text = "Press Me To Display The Result";
			displayResultButton.UseVisualStyleBackColor = true;
			displayResultButton.Click += button1_Click;
			// 
			// resultLabelNoModification
			// 
			resultLabelNoModification.AutoSize = true;
			resultLabelNoModification.Location = new Point(30, 171);
			resultLabelNoModification.Name = "resultLabelNoModification";
			resultLabelNoModification.Size = new Size(62, 15);
			resultLabelNoModification.TabIndex = 7;
			resultLabelNoModification.Text = "Suggested";
			// 
			// resultLabelModification
			// 
			resultLabelModification.AutoSize = true;
			resultLabelModification.Location = new Point(116, 171);
			resultLabelModification.Name = "resultLabelModification";
			resultLabelModification.Size = new Size(0, 15);
			resultLabelModification.TabIndex = 8;
			resultLabelModification.Text = "";
			// 
			// NumericType
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Turquoise;
			ClientSize = new Size(484, 261);
			Controls.Add(resultLabelModification);
			Controls.Add(resultLabelNoModification);
			Controls.Add(displayResultButton);
			Controls.Add(veryPreciseCheckBox);
			Controls.Add(wholeNumberCheckBox);
			Controls.Add(maxValueTextBox);
			Controls.Add(minValueTextBox);
			Controls.Add(maxValueLabel);
			Controls.Add(minValueLabel);
			Name = "NumericType";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label minValueLabel;
		private Label maxValueLabel;
		private TextBox minValueTextBox;
		private TextBox maxValueTextBox;
		private CheckBox wholeNumberCheckBox;
		private CheckBox veryPreciseCheckBox;
		private Button displayResultButton;
		private Label resultLabelNoModification;
		private Label resultLabelModification;
	}
}
