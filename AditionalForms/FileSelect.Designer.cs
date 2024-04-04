namespace TestWinForm.AditionalForms
{
    partial class FileSelect
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
            checkBoxAll = new CheckBox();
            PrevBtn = new Button();
            NextBtn = new Button();
            label = new Label();
            MBtn = new Button();
            MRBtn = new Button();
            MCBtn = new Button();
            CBtn = new Button();
            SuspendLayout();
            // 
            // checkBoxAll
            // 
            checkBoxAll.AutoSize = true;
            checkBoxAll.Checked = true;
            checkBoxAll.CheckState = CheckState.Checked;
            checkBoxAll.Location = new Point(554, 11);
            checkBoxAll.Name = "checkBoxAll";
            checkBoxAll.Size = new Size(40, 19);
            checkBoxAll.TabIndex = 23;
            checkBoxAll.Text = "All";
            checkBoxAll.UseVisualStyleBackColor = true;
            checkBoxAll.CheckedChanged += checkBoxAll_CheckedChanged;
            // 
            // PrevBtn
            // 
            PrevBtn.Enabled = false;
            PrevBtn.Location = new Point(12, 8);
            PrevBtn.Name = "PrevBtn";
            PrevBtn.Size = new Size(75, 23);
            PrevBtn.TabIndex = 27;
            PrevBtn.Text = "Prev";
            PrevBtn.UseVisualStyleBackColor = true;
            PrevBtn.Click += PrevBtn_Click;
            // 
            // NextBtn
            // 
            NextBtn.Enabled = false;
            NextBtn.Location = new Point(991, 8);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(75, 23);
            NextBtn.TabIndex = 28;
            NextBtn.Text = "Next";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(13, 644);
            label.Name = "label";
            label.Size = new Size(0, 15);
            label.TabIndex = 29;
            // 
            // MBtn
            // 
            MBtn.Location = new Point(460, 8);
            MBtn.Name = "MBtn";
            MBtn.Size = new Size(36, 23);
            MBtn.TabIndex = 30;
            MBtn.Text = "M";
            MBtn.UseVisualStyleBackColor = true;
            MBtn.Click += MBtn_Click;
            // 
            // MRBtn
            // 
            MRBtn.Enabled = false;
            MRBtn.Location = new Point(418, 8);
            MRBtn.Name = "MRBtn";
            MRBtn.Size = new Size(36, 23);
            MRBtn.TabIndex = 31;
            MRBtn.Text = "MR";
            MRBtn.UseVisualStyleBackColor = true;
            MRBtn.Click += MRBtn_Click;
            // 
            // MCBtn
            // 
            MCBtn.Enabled = false;
            MCBtn.Location = new Point(376, 8);
            MCBtn.Name = "MCBtn";
            MCBtn.Size = new Size(36, 23);
            MCBtn.TabIndex = 32;
            MCBtn.Text = "MC";
            MCBtn.UseVisualStyleBackColor = true;
            MCBtn.Click += MCBtn_Click;
            // 
            // CBtn
            // 
            CBtn.Location = new Point(502, 8);
            CBtn.Name = "CBtn";
            CBtn.Size = new Size(36, 23);
            CBtn.TabIndex = 33;
            CBtn.Text = "C";
            CBtn.UseVisualStyleBackColor = true;
            CBtn.Click += CBtn_Click;
            // 
            // FileSelect
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 901);
            Controls.Add(CBtn);
            Controls.Add(MCBtn);
            Controls.Add(MRBtn);
            Controls.Add(MBtn);
            Controls.Add(label);
            Controls.Add(NextBtn);
            Controls.Add(PrevBtn);
            Controls.Add(checkBoxAll);
            Name = "FileSelect";
            Text = "FileSelect";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckBox checkBoxAll;
        private Button PrevBtn;
        private Button NextBtn;
        private Label label;
        private Button MBtn;
        private Button MRBtn;
        private Button MCBtn;
        private Button CBtn;
    }
}