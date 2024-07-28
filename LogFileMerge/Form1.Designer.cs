namespace LogFileMerge
{
    partial class Form1
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
            FileArchiveLocationTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            groupBox1 = new GroupBox();
            messagesLbl = new Label();
            button1 = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
            checkedListBox1 = new CheckedListBox();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // FileArchiveLocationTextBox
            // 
            FileArchiveLocationTextBox.Location = new Point(18, 377);
            FileArchiveLocationTextBox.Name = "FileArchiveLocationTextBox";
            FileArchiveLocationTextBox.Size = new Size(596, 35);
            FileArchiveLocationTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 108);
            label1.Name = "label1";
            label1.Size = new Size(183, 30);
            label1.TabIndex = 3;
            label1.Text = "Log File Locations:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 344);
            label2.Name = "label2";
            label2.Size = new Size(209, 30);
            label2.TabIndex = 4;
            label2.Text = "Archive File Location:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkedListBox1);
            groupBox1.Controls.Add(messagesLbl);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(FileArchiveLocationTextBox);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(498, 268);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(635, 532);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Log File Archiving Utility";
            // 
            // messagesLbl
            // 
            messagesLbl.AutoSize = true;
            messagesLbl.Location = new Point(18, 54);
            messagesLbl.Name = "messagesLbl";
            messagesLbl.Size = new Size(0, 30);
            messagesLbl.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(18, 470);
            button1.Name = "button1";
            button1.Size = new Size(190, 40);
            button1.TabIndex = 5;
            button1.Text = "Archive Log Files";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(22, 155);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(592, 164);
            checkedListBox1.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1590, 990);
            Controls.Add(groupBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox FileArchiveLocationTextBox;
        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private Button button1;
        private FileSystemWatcher fileSystemWatcher1;
        private Label messagesLbl;
        private CheckedListBox checkedListBox1;
    }
}
