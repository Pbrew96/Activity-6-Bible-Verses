namespace FileIOAndLINQ.PresentationLayer
{
    partial class FrmVerseList
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
            mnsFileActions = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            tsmSave = new ToolStripMenuItem();
            tsmLoad = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();
            grpAddVerse = new GroupBox();
            lblImportanceError = new Label();
            lblBookError = new Label();
            btnAddVerse = new Button();
            nudVerseImportance = new NumericUpDown();
            textBox1 = new TextBox();
            txtVerseText = new TextBox();
            txtVerseVerse = new TextBox();
            txtVerseChapter = new TextBox();
            cmbVerseBook = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            rdoShowMostImportant = new RadioButton();
            rdoShowLeastImportant = new RadioButton();
            rdoShowAll = new RadioButton();
            trbNumberToShow = new TrackBar();
            dgvVerseDisplay = new DataGridView();
            lblChapterError = new Label();
            lblVerseError = new Label();
            lblTextError = new Label();
            lblMeaningError = new Label();
            mnsFileActions.SuspendLayout();
            grpAddVerse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVerseDisplay).BeginInit();
            SuspendLayout();
            // 
            // mnsFileActions
            // 
            mnsFileActions.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mnsFileActions.Location = new Point(0, 0);
            mnsFileActions.Name = "mnsFileActions";
            mnsFileActions.Size = new Size(800, 24);
            mnsFileActions.TabIndex = 0;
            mnsFileActions.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsmSave, tsmLoad, tsmExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // tsmSave
            // 
            tsmSave.Name = "tsmSave";
            tsmSave.Size = new Size(100, 22);
            tsmSave.Text = "Save";
            // 
            // tsmLoad
            // 
            tsmLoad.Name = "tsmLoad";
            tsmLoad.Size = new Size(100, 22);
            tsmLoad.Text = "Load";
            // 
            // tsmExit
            // 
            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(100, 22);
            tsmExit.Text = "Exit";
            // 
            // grpAddVerse
            // 
            grpAddVerse.Controls.Add(lblMeaningError);
            grpAddVerse.Controls.Add(lblTextError);
            grpAddVerse.Controls.Add(lblVerseError);
            grpAddVerse.Controls.Add(lblChapterError);
            grpAddVerse.Controls.Add(lblImportanceError);
            grpAddVerse.Controls.Add(lblBookError);
            grpAddVerse.Controls.Add(btnAddVerse);
            grpAddVerse.Controls.Add(nudVerseImportance);
            grpAddVerse.Controls.Add(textBox1);
            grpAddVerse.Controls.Add(txtVerseText);
            grpAddVerse.Controls.Add(txtVerseVerse);
            grpAddVerse.Controls.Add(txtVerseChapter);
            grpAddVerse.Controls.Add(cmbVerseBook);
            grpAddVerse.Controls.Add(label6);
            grpAddVerse.Controls.Add(label5);
            grpAddVerse.Controls.Add(label4);
            grpAddVerse.Controls.Add(label3);
            grpAddVerse.Controls.Add(label2);
            grpAddVerse.Controls.Add(label1);
            grpAddVerse.Location = new Point(12, 43);
            grpAddVerse.Name = "grpAddVerse";
            grpAddVerse.Size = new Size(268, 384);
            grpAddVerse.TabIndex = 1;
            grpAddVerse.TabStop = false;
            grpAddVerse.Text = "Add A Bible Verse";
            // 
            // lblImportanceError
            // 
            lblImportanceError.AutoSize = true;
            lblImportanceError.ForeColor = Color.Red;
            lblImportanceError.Location = new Point(73, 338);
            lblImportanceError.Name = "lblImportanceError";
            lblImportanceError.Size = new Size(96, 15);
            lblImportanceError.TabIndex = 18;
            lblImportanceError.Text = "Importance Error";
            // 
            // lblBookError
            // 
            lblBookError.AutoSize = true;
            lblBookError.ForeColor = Color.Red;
            lblBookError.Location = new Point(73, 45);
            lblBookError.Name = "lblBookError";
            lblBookError.Size = new Size(62, 15);
            lblBookError.TabIndex = 13;
            lblBookError.Text = "Book Error";
            // 
            // btnAddVerse
            // 
            btnAddVerse.Location = new Point(97, 356);
            btnAddVerse.Name = "btnAddVerse";
            btnAddVerse.Size = new Size(75, 23);
            btnAddVerse.TabIndex = 12;
            btnAddVerse.Text = "Add";
            btnAddVerse.UseVisualStyleBackColor = true;
            // 
            // nudVerseImportance
            // 
            nudVerseImportance.Location = new Point(73, 312);
            nudVerseImportance.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudVerseImportance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudVerseImportance.Name = "nudVerseImportance";
            nudVerseImportance.Size = new Size(189, 23);
            nudVerseImportance.TabIndex = 11;
            nudVerseImportance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(73, 232);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(189, 60);
            textBox1.TabIndex = 10;
            // 
            // txtVerseText
            // 
            txtVerseText.Location = new Point(73, 152);
            txtVerseText.Multiline = true;
            txtVerseText.Name = "txtVerseText";
            txtVerseText.Size = new Size(189, 60);
            txtVerseText.TabIndex = 9;
            // 
            // txtVerseVerse
            // 
            txtVerseVerse.Location = new Point(78, 108);
            txtVerseVerse.Name = "txtVerseVerse";
            txtVerseVerse.Size = new Size(180, 23);
            txtVerseVerse.TabIndex = 8;
            // 
            // txtVerseChapter
            // 
            txtVerseChapter.Location = new Point(73, 62);
            txtVerseChapter.Name = "txtVerseChapter";
            txtVerseChapter.Size = new Size(189, 23);
            txtVerseChapter.TabIndex = 7;
            // 
            // cmbVerseBook
            // 
            cmbVerseBook.FormattingEnabled = true;
            cmbVerseBook.Location = new Point(73, 19);
            cmbVerseBook.Name = "cmbVerseBook";
            cmbVerseBook.Size = new Size(189, 23);
            cmbVerseBook.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1, 314);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 5;
            label6.Text = "Importance:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 235);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 4;
            label5.Text = "Meaning:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 152);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 3;
            label4.Text = "Text:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 108);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "Verse:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Chapter:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 22);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 0;
            label1.Text = "Book:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdoShowMostImportant);
            groupBox1.Controls.Add(rdoShowLeastImportant);
            groupBox1.Controls.Add(rdoShowAll);
            groupBox1.Location = new Point(12, 433);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(268, 130);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filter and Sort";
            // 
            // rdoShowMostImportant
            // 
            rdoShowMostImportant.AutoSize = true;
            rdoShowMostImportant.Location = new Point(6, 101);
            rdoShowMostImportant.Name = "rdoShowMostImportant";
            rdoShowMostImportant.Size = new Size(140, 19);
            rdoShowMostImportant.TabIndex = 2;
            rdoShowMostImportant.TabStop = true;
            rdoShowMostImportant.Text = "Show Most Important";
            rdoShowMostImportant.UseVisualStyleBackColor = true;
            // 
            // rdoShowLeastImportant
            // 
            rdoShowLeastImportant.AutoSize = true;
            rdoShowLeastImportant.Location = new Point(6, 67);
            rdoShowLeastImportant.Name = "rdoShowLeastImportant";
            rdoShowLeastImportant.Size = new Size(140, 19);
            rdoShowLeastImportant.TabIndex = 1;
            rdoShowLeastImportant.TabStop = true;
            rdoShowLeastImportant.Text = "Show Least Important";
            rdoShowLeastImportant.UseVisualStyleBackColor = true;
            // 
            // rdoShowAll
            // 
            rdoShowAll.AutoSize = true;
            rdoShowAll.Location = new Point(6, 32);
            rdoShowAll.Name = "rdoShowAll";
            rdoShowAll.Size = new Size(71, 19);
            rdoShowAll.TabIndex = 0;
            rdoShowAll.TabStop = true;
            rdoShowAll.Text = "Show All";
            rdoShowAll.UseVisualStyleBackColor = true;
            // 
            // trbNumberToShow
            // 
            trbNumberToShow.Location = new Point(0, 569);
            trbNumberToShow.Name = "trbNumberToShow";
            trbNumberToShow.Size = new Size(280, 45);
            trbNumberToShow.TabIndex = 3;
            // 
            // dgvVerseDisplay
            // 
            dgvVerseDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVerseDisplay.Location = new Point(302, 43);
            dgvVerseDisplay.Name = "dgvVerseDisplay";
            dgvVerseDisplay.Size = new Size(486, 441);
            dgvVerseDisplay.TabIndex = 4;
            // 
            // lblChapterError
            // 
            lblChapterError.AutoSize = true;
            lblChapterError.ForeColor = Color.Red;
            lblChapterError.Location = new Point(73, 88);
            lblChapterError.Name = "lblChapterError";
            lblChapterError.Size = new Size(77, 15);
            lblChapterError.TabIndex = 19;
            lblChapterError.Text = "Chapter Error";
            // 
            // lblVerseError
            // 
            lblVerseError.AutoSize = true;
            lblVerseError.ForeColor = Color.Red;
            lblVerseError.Location = new Point(78, 134);
            lblVerseError.Name = "lblVerseError";
            lblVerseError.Size = new Size(62, 15);
            lblVerseError.TabIndex = 20;
            lblVerseError.Text = "Verse Error";
            // 
            // lblTextError
            // 
            lblTextError.AutoSize = true;
            lblTextError.ForeColor = Color.Red;
            lblTextError.Location = new Point(78, 214);
            lblTextError.Name = "lblTextError";
            lblTextError.Size = new Size(56, 15);
            lblTextError.TabIndex = 21;
            lblTextError.Text = "Text Error";
            // 
            // lblMeaningError
            // 
            lblMeaningError.AutoSize = true;
            lblMeaningError.ForeColor = Color.Red;
            lblMeaningError.Location = new Point(78, 294);
            lblMeaningError.Name = "lblMeaningError";
            lblMeaningError.Size = new Size(82, 15);
            lblMeaningError.TabIndex = 22;
            lblMeaningError.Text = "Meaning Error";
            // 
            // FrmVerseList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 610);
            Controls.Add(dgvVerseDisplay);
            Controls.Add(trbNumberToShow);
            Controls.Add(groupBox1);
            Controls.Add(grpAddVerse);
            Controls.Add(mnsFileActions);
            MainMenuStrip = mnsFileActions;
            Name = "FrmVerseList";
            Text = "Bible Verses";
            mnsFileActions.ResumeLayout(false);
            mnsFileActions.PerformLayout();
            grpAddVerse.ResumeLayout(false);
            grpAddVerse.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudVerseImportance).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbNumberToShow).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVerseDisplay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnsFileActions;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem tsmSave;
        private ToolStripMenuItem tsmLoad;
        private ToolStripMenuItem tsmExit;
        private GroupBox grpAddVerse;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox txtVerseText;
        private TextBox txtVerseVerse;
        private TextBox txtVerseChapter;
        private ComboBox cmbVerseBook;
        private Button btnAddVerse;
        private NumericUpDown nudVerseImportance;
        private Label lblImportanceError;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label lblBookError;
        private GroupBox groupBox1;
        private RadioButton rdoShowMostImportant;
        private RadioButton rdoShowLeastImportant;
        private RadioButton rdoShowAll;
        private TrackBar trbNumberToShow;
        private DataGridView dgvVerseDisplay;
        private Label lblMeaningError;
        private Label lblTextError;
        private Label lblVerseError;
        private Label lblChapterError;
    }
}