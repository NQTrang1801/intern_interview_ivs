namespace FileProcessingApp
{
    partial class MainForm
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
            fileContentTextBox = new TextBox();
            LoadFileButton = new Button();
            SaveFileButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // fileContentTextBox
            // 
            fileContentTextBox.Location = new Point(12, 12);
            fileContentTextBox.Multiline = true;
            fileContentTextBox.Name = "fileContentTextBox";
            fileContentTextBox.Size = new Size(776, 271);
            fileContentTextBox.TabIndex = 0;
            // 
            // LoadFileButton
            // 
            LoadFileButton.Location = new Point(12, 302);
            LoadFileButton.Name = "LoadFileButton";
            LoadFileButton.Size = new Size(129, 29);
            LoadFileButton.TabIndex = 1;
            LoadFileButton.Text = "Load File";
            LoadFileButton.UseVisualStyleBackColor = true;
            LoadFileButton.Click += LoadFileButton_Click;
            // 
            // SaveFileButton
            // 
            SaveFileButton.Location = new Point(175, 302);
            SaveFileButton.Name = "SaveFileButton";
            SaveFileButton.Size = new Size(130, 29);
            SaveFileButton.TabIndex = 2;
            SaveFileButton.Text = "Save File";
            SaveFileButton.UseVisualStyleBackColor = true;
            SaveFileButton.Click += SaveFileButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(810, 344);
            Controls.Add(SaveFileButton);
            Controls.Add(LoadFileButton);
            Controls.Add(fileContentTextBox);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox fileContentTextBox;
        private Button LoadFileButton;
        private Button SaveFileButton;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
    }
}
