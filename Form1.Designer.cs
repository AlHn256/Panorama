namespace TestWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Требуемая переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистите все используемые ресурсы.
        /// </summary>
        /// <param name = "Утилизация"> Если размещенный ресурс должен быть освобожден, true; в противном случае false. </ param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// дизайнер поддерживает требуемый метод - не модифицируйте
        /// Используйте редактор кода для изменения содержимого этого метода.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectImg1 = new Button();
            label1 = new Label();
            FirstImgTxtBox = new TextBox();
            SecondImgTxtBox = new TextBox();
            label2 = new Label();
            btnSelectImg2 = new Button();
            pbImg1 = new PictureBox();
            label3 = new Label();
            label4 = new Label();
            pbImg2 = new PictureBox();
            pbResult = new PictureBox();
            label5 = new Label();
            btnStart1 = new Button();
            label6 = new Label();
            panel1 = new Panel();
            rcbType2 = new RadioButton();
            rcbType1 = new RadioButton();
            SaveBtn = new Button();
            button1 = new Button();
            TestBtn = new Button();
            NextBtn = new Button();
            PrevBtn = new Button();
            DirectoryTextBox = new TextBox();
            button2 = new Button();
            FileNumbrLabel = new Label();
            SaveFileLabel = new Label();
            comboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbImg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImg2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectImg1
            // 
            btnSelectImg1.Location = new Point(1119, 9);
            btnSelectImg1.Margin = new Padding(4);
            btnSelectImg1.Name = "btnSelectImg1";
            btnSelectImg1.Size = new Size(25, 29);
            btnSelectImg1.TabIndex = 0;
            btnSelectImg1.Text = "...";
            btnSelectImg1.UseVisualStyleBackColor = true;
            btnSelectImg1.Click += btnSelectImg1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Изображение 1:";
            // 
            // FirstImgTxtBox
            // 
            FirstImgTxtBox.Location = new Point(112, 11);
            FirstImgTxtBox.Margin = new Padding(4);
            FirstImgTxtBox.Name = "FirstImgTxtBox";
            FirstImgTxtBox.ReadOnly = true;
            FirstImgTxtBox.Size = new Size(999, 23);
            FirstImgTxtBox.TabIndex = 2;
            FirstImgTxtBox.TextChanged += FirstImgTxtBox_TextChanged;
            // 
            // SecondImgTxtBox
            // 
            SecondImgTxtBox.Location = new Point(112, 45);
            SecondImgTxtBox.Margin = new Padding(4);
            SecondImgTxtBox.Name = "SecondImgTxtBox";
            SecondImgTxtBox.ReadOnly = true;
            SecondImgTxtBox.Size = new Size(999, 23);
            SecondImgTxtBox.TabIndex = 5;
            SecondImgTxtBox.TextChanged += SecondImgTxtBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 49);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 4;
            label2.Text = "Изображение 2:";
            // 
            // btnSelectImg2
            // 
            btnSelectImg2.Location = new Point(1119, 42);
            btnSelectImg2.Margin = new Padding(4);
            btnSelectImg2.Name = "btnSelectImg2";
            btnSelectImg2.Size = new Size(25, 29);
            btnSelectImg2.TabIndex = 3;
            btnSelectImg2.Text = "...";
            btnSelectImg2.UseVisualStyleBackColor = true;
            btnSelectImg2.Click += btnSelectImg2_Click;
            // 
            // pbImg1
            // 
            pbImg1.BackgroundImageLayout = ImageLayout.Zoom;
            pbImg1.BorderStyle = BorderStyle.FixedSingle;
            pbImg1.Location = new Point(14, 111);
            pbImg1.Margin = new Padding(4);
            pbImg1.Name = "pbImg1";
            pbImg1.Size = new Size(340, 358);
            pbImg1.TabIndex = 6;
            pbImg1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(159, 480);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 7;
            label3.Text = "picture 1";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(159, 885);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 9;
            label4.Text = "picture 2";
            // 
            // pbImg2
            // 
            pbImg2.BackgroundImageLayout = ImageLayout.Zoom;
            pbImg2.BorderStyle = BorderStyle.FixedSingle;
            pbImg2.Location = new Point(14, 518);
            pbImg2.Margin = new Padding(4);
            pbImg2.Name = "pbImg2";
            pbImg2.Size = new Size(340, 363);
            pbImg2.TabIndex = 8;
            pbImg2.TabStop = false;
            // 
            // pbResult
            // 
            pbResult.BackgroundImageLayout = ImageLayout.Zoom;
            pbResult.BorderStyle = BorderStyle.FixedSingle;
            pbResult.Location = new Point(391, 111);
            pbResult.Margin = new Padding(4);
            pbResult.Name = "pbResult";
            pbResult.Size = new Size(752, 770);
            pbResult.TabIndex = 10;
            pbResult.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(747, 885);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 11;
            label5.Text = "result";
            // 
            // btnStart1
            // 
            btnStart1.Location = new Point(667, 80);
            btnStart1.Margin = new Padding(4);
            btnStart1.Name = "btnStart1";
            btnStart1.Size = new Size(64, 23);
            btnStart1.TabIndex = 12;
            btnStart1.Text = "Start";
            btnStart1.UseVisualStyleBackColor = true;
            btnStart1.Click += btnStart1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 84);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(143, 15);
            label6.TabIndex = 13;
            label6.Text = "Направление сшивания:";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(rcbType2);
            panel1.Controls.Add(rcbType1);
            panel1.Location = new Point(167, 80);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(216, 23);
            panel1.TabIndex = 14;
            // 
            // rcbType2
            // 
            rcbType2.AutoSize = true;
            rcbType2.Checked = true;
            rcbType2.Location = new Point(2, 1);
            rcbType2.Margin = new Padding(4);
            rcbType2.Name = "rcbType2";
            rcbType2.Size = new Size(108, 19);
            rcbType2.TabIndex = 1;
            rcbType2.TabStop = true;
            rcbType2.Text = "горизонтально";
            rcbType2.UseVisualStyleBackColor = true;
            // 
            // rcbType1
            // 
            rcbType1.AutoSize = true;
            rcbType1.Location = new Point(121, 1);
            rcbType1.Margin = new Padding(4);
            rcbType1.Name = "rcbType1";
            rcbType1.Size = new Size(95, 19);
            rcbType1.TabIndex = 0;
            rcbType1.TabStop = true;
            rcbType1.Text = "вертикально";
            rcbType1.UseVisualStyleBackColor = true;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(338, 938);
            SaveBtn.Margin = new Padding(4);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(79, 23);
            SaveBtn.TabIndex = 15;
            SaveBtn.Text = "Сохранить карту результатов";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += btnSave_Click;
            // 
            // button1
            // 
            button1.Location = new Point(391, 80);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(141, 23);
            button1.TabIndex = 16;
            button1.Text = "обычная строчка";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TestBtn
            // 
            TestBtn.Location = new Point(13, 907);
            TestBtn.Name = "TestBtn";
            TestBtn.Size = new Size(97, 23);
            TestBtn.TabIndex = 17;
            TestBtn.Text = "Made Panaram";
            TestBtn.UseVisualStyleBackColor = true;
            TestBtn.Click += TestBtn_Click;
            // 
            // NextBtn
            // 
            NextBtn.Location = new Point(279, 482);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(75, 23);
            NextBtn.TabIndex = 18;
            NextBtn.Text = "Next";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // PrevBtn
            // 
            PrevBtn.Location = new Point(15, 482);
            PrevBtn.Name = "PrevBtn";
            PrevBtn.Size = new Size(75, 23);
            PrevBtn.TabIndex = 19;
            PrevBtn.Text = "Prev";
            PrevBtn.UseVisualStyleBackColor = true;
            PrevBtn.Click += PrevBtn_Click;
            // 
            // DirectoryTextBox
            // 
            DirectoryTextBox.Location = new Point(117, 907);
            DirectoryTextBox.Margin = new Padding(4);
            DirectoryTextBox.Name = "DirectoryTextBox";
            DirectoryTextBox.ReadOnly = true;
            DirectoryTextBox.Size = new Size(994, 23);
            DirectoryTextBox.TabIndex = 20;
            DirectoryTextBox.TextChanged += DirectoryTextBox_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(1119, 907);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(25, 23);
            button2.TabIndex = 21;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FileNumbrLabel
            // 
            FileNumbrLabel.AutoSize = true;
            FileNumbrLabel.Location = new Point(15, 947);
            FileNumbrLabel.Margin = new Padding(4, 0, 4, 0);
            FileNumbrLabel.Name = "FileNumbrLabel";
            FileNumbrLabel.Size = new Size(0, 15);
            FileNumbrLabel.TabIndex = 22;
            // 
            // SaveFileLabel
            // 
            SaveFileLabel.AutoSize = true;
            SaveFileLabel.Location = new Point(425, 942);
            SaveFileLabel.Margin = new Padding(4, 0, 4, 0);
            SaveFileLabel.Name = "SaveFileLabel";
            SaveFileLabel.Size = new Size(0, 15);
            SaveFileLabel.TabIndex = 23;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(539, 80);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(121, 23);
            comboBox.TabIndex = 24;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 975);
            Controls.Add(comboBox);
            Controls.Add(SaveFileLabel);
            Controls.Add(FileNumbrLabel);
            Controls.Add(button2);
            Controls.Add(DirectoryTextBox);
            Controls.Add(PrevBtn);
            Controls.Add(NextBtn);
            Controls.Add(TestBtn);
            Controls.Add(button1);
            Controls.Add(SaveBtn);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(btnStart1);
            Controls.Add(label5);
            Controls.Add(pbResult);
            Controls.Add(label4);
            Controls.Add(pbImg2);
            Controls.Add(label3);
            Controls.Add(pbImg1);
            Controls.Add(SecondImgTxtBox);
            Controls.Add(label2);
            Controls.Add(btnSelectImg2);
            Controls.Add(FirstImgTxtBox);
            Controls.Add(label1);
            Controls.Add(btnSelectImg1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "сращивание картинки";
            ((System.ComponentModel.ISupportInitialize)pbImg1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbImg2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnSelectImg1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FirstImgTxtBox;
        private System.Windows.Forms.TextBox SecondImgTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectImg2;
        private System.Windows.Forms.PictureBox pbImg1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbImg2;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rcbType2;
        private System.Windows.Forms.RadioButton rcbType1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button button1;
        private Button TestBtn;
        private Button NextBtn;
        private Button PrevBtn;
        private TextBox DirectoryTextBox;
        private Button button2;
        private Label FileNumbrLabel;
        private Label SaveFileLabel;
        private ComboBox comboBox;
    }
}
