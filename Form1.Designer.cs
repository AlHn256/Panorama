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
            if (disposing && (components != null))components.Dispose();
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
            pbImg2 = new PictureBox();
            pbResult = new PictureBox();
            StitchBtn = new Button();
            label6 = new Label();
            panel1 = new Panel();
            rcbType2 = new RadioButton();
            rcbType1 = new RadioButton();
            SaveBtn = new Button();
            JoinBtn = new Button();
            MadePnrmBtn = new Button();
            NextBtn = new Button();
            PrevBtn = new Button();
            DirectoryTextBox = new TextBox();
            button2 = new Button();
            FileNumbrLabel = new Label();
            comboBox = new ComboBox();
            DistortionBtn = new Button();
            ReloadBtn = new Button();
            SelectFilesBtn = new Button();
            TryToStitchBtn = new Button();
            CrearBtn = new Button();
            ReserchAndSaveChkBox = new CheckBox();
            RezultRTB = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)pbImg1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbImg2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbResult).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnSelectImg1
            // 
            btnSelectImg1.Location = new Point(1008, 42);
            btnSelectImg1.Margin = new Padding(4);
            btnSelectImg1.Name = "btnSelectImg1";
            btnSelectImg1.Size = new Size(25, 26);
            btnSelectImg1.TabIndex = 0;
            btnSelectImg1.Text = "...";
            btnSelectImg1.UseVisualStyleBackColor = true;
            btnSelectImg1.Click += btnSelectImg1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 47);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 1;
            label1.Text = "Изображение 1:";
            // 
            // FirstImgTxtBox
            // 
            FirstImgTxtBox.Location = new Point(112, 43);
            FirstImgTxtBox.Margin = new Padding(4);
            FirstImgTxtBox.Name = "FirstImgTxtBox";
            FirstImgTxtBox.ReadOnly = true;
            FirstImgTxtBox.Size = new Size(888, 23);
            FirstImgTxtBox.TabIndex = 2;
            FirstImgTxtBox.TextChanged += FirstImgTxtBox_TextChanged;
            // 
            // SecondImgTxtBox
            // 
            SecondImgTxtBox.Location = new Point(112, 77);
            SecondImgTxtBox.Margin = new Padding(4);
            SecondImgTxtBox.Name = "SecondImgTxtBox";
            SecondImgTxtBox.ReadOnly = true;
            SecondImgTxtBox.Size = new Size(888, 23);
            SecondImgTxtBox.TabIndex = 5;
            SecondImgTxtBox.TextChanged += SecondImgTxtBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 81);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 4;
            label2.Text = "Изображение 2:";
            // 
            // btnSelectImg2
            // 
            btnSelectImg2.Location = new Point(1008, 76);
            btnSelectImg2.Margin = new Padding(4);
            btnSelectImg2.Name = "btnSelectImg2";
            btnSelectImg2.Size = new Size(25, 26);
            btnSelectImg2.TabIndex = 3;
            btnSelectImg2.Text = "...";
            btnSelectImg2.UseVisualStyleBackColor = true;
            btnSelectImg2.Click += btnSelectImg2_Click;
            // 
            // pbImg1
            // 
            pbImg1.BackgroundImageLayout = ImageLayout.Zoom;
            pbImg1.BorderStyle = BorderStyle.FixedSingle;
            pbImg1.Location = new Point(14, 142);
            pbImg1.Margin = new Padding(4);
            pbImg1.Name = "pbImg1";
            pbImg1.Size = new Size(369, 358);
            pbImg1.TabIndex = 6;
            pbImg1.TabStop = false;
            // 
            // pbImg2
            // 
            pbImg2.BackgroundImageLayout = ImageLayout.Zoom;
            pbImg2.BorderStyle = BorderStyle.FixedSingle;
            pbImg2.Location = new Point(14, 549);
            pbImg2.Margin = new Padding(4);
            pbImg2.Name = "pbImg2";
            pbImg2.Size = new Size(369, 363);
            pbImg2.TabIndex = 8;
            pbImg2.TabStop = false;
            // 
            // pbResult
            // 
            pbResult.BackgroundImageLayout = ImageLayout.Zoom;
            pbResult.BorderStyle = BorderStyle.FixedSingle;
            pbResult.Location = new Point(391, 142);
            pbResult.Margin = new Padding(4);
            pbResult.Name = "pbResult";
            pbResult.Size = new Size(752, 770);
            pbResult.TabIndex = 10;
            pbResult.TabStop = false;
            // 
            // StitchBtn
            // 
            StitchBtn.Location = new Point(237, 513);
            StitchBtn.Margin = new Padding(4);
            StitchBtn.Name = "StitchBtn";
            StitchBtn.Size = new Size(64, 23);
            StitchBtn.TabIndex = 12;
            StitchBtn.Text = "Start";
            StitchBtn.UseVisualStyleBackColor = true;
            StitchBtn.Click += btnStart1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 116);
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
            panel1.Location = new Point(167, 112);
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
            SaveBtn.Location = new Point(13, 914);
            SaveBtn.Margin = new Padding(4);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(111, 53);
            SaveBtn.TabIndex = 15;
            SaveBtn.Text = "Сохранить";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += btnSave_Click;
            // 
            // JoinBtn
            // 
            JoinBtn.Location = new Point(97, 513);
            JoinBtn.Margin = new Padding(4);
            JoinBtn.Name = "JoinBtn";
            JoinBtn.Size = new Size(75, 23);
            JoinBtn.TabIndex = 16;
            JoinBtn.Text = "Join";
            JoinBtn.UseVisualStyleBackColor = true;
            JoinBtn.Click += button1_Click;
            // 
            // MadePnrmBtn
            // 
            MadePnrmBtn.Location = new Point(1040, 12);
            MadePnrmBtn.Name = "MadePnrmBtn";
            MadePnrmBtn.Size = new Size(105, 90);
            MadePnrmBtn.TabIndex = 17;
            MadePnrmBtn.Text = "Made Panaram";
            MadePnrmBtn.UseVisualStyleBackColor = true;
            MadePnrmBtn.Click += TestBtn_Click;
            // 
            // NextBtn
            // 
            NextBtn.Location = new Point(308, 513);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new Size(75, 23);
            NextBtn.TabIndex = 18;
            NextBtn.Text = "Next";
            NextBtn.UseVisualStyleBackColor = true;
            NextBtn.Click += NextBtn_Click;
            // 
            // PrevBtn
            // 
            PrevBtn.Location = new Point(13, 513);
            PrevBtn.Name = "PrevBtn";
            PrevBtn.Size = new Size(77, 23);
            PrevBtn.TabIndex = 19;
            PrevBtn.Text = "Prev";
            PrevBtn.UseVisualStyleBackColor = true;
            PrevBtn.Click += PrevBtn_Click;
            // 
            // DirectoryTextBox
            // 
            DirectoryTextBox.Location = new Point(19, 12);
            DirectoryTextBox.Margin = new Padding(4);
            DirectoryTextBox.Name = "DirectoryTextBox";
            DirectoryTextBox.ReadOnly = true;
            DirectoryTextBox.Size = new Size(981, 23);
            DirectoryTextBox.TabIndex = 20;
            DirectoryTextBox.Text = "D:\\Work\\Exampels\\13Out";
            DirectoryTextBox.TextChanged += DirectoryTextBox_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(1008, 12);
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
            FileNumbrLabel.Location = new Point(675, 118);
            FileNumbrLabel.Margin = new Padding(4, 0, 4, 0);
            FileNumbrLabel.Name = "FileNumbrLabel";
            FileNumbrLabel.Size = new Size(0, 15);
            FileNumbrLabel.TabIndex = 22;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(391, 112);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(116, 23);
            comboBox.TabIndex = 24;
            // 
            // DistortionBtn
            // 
            DistortionBtn.Location = new Point(132, 914);
            DistortionBtn.Margin = new Padding(4);
            DistortionBtn.Name = "DistortionBtn";
            DistortionBtn.Size = new Size(121, 53);
            DistortionBtn.TabIndex = 25;
            DistortionBtn.Text = "Distortion";
            DistortionBtn.UseVisualStyleBackColor = true;
            DistortionBtn.Click += DistortionBtn_Click;
            // 
            // ReloadBtn
            // 
            ReloadBtn.Location = new Point(514, 112);
            ReloadBtn.Margin = new Padding(4);
            ReloadBtn.Name = "ReloadBtn";
            ReloadBtn.Size = new Size(64, 23);
            ReloadBtn.TabIndex = 26;
            ReloadBtn.Text = "Reload";
            ReloadBtn.UseVisualStyleBackColor = true;
            ReloadBtn.Click += ReloadBtn_Click;
            // 
            // SelectFilesBtn
            // 
            SelectFilesBtn.Location = new Point(586, 112);
            SelectFilesBtn.Margin = new Padding(4);
            SelectFilesBtn.Name = "SelectFilesBtn";
            SelectFilesBtn.Size = new Size(74, 23);
            SelectFilesBtn.TabIndex = 27;
            SelectFilesBtn.Text = "Select Files";
            SelectFilesBtn.UseVisualStyleBackColor = true;
            SelectFilesBtn.Click += SelectFilesBtn_Click;
            // 
            // TryToStitchBtn
            // 
            TryToStitchBtn.Location = new Point(948, 111);
            TryToStitchBtn.Margin = new Padding(4);
            TryToStitchBtn.Name = "TryToStitchBtn";
            TryToStitchBtn.Size = new Size(85, 23);
            TryToStitchBtn.TabIndex = 28;
            TryToStitchBtn.Text = "Try to stitch";
            TryToStitchBtn.UseVisualStyleBackColor = true;
            TryToStitchBtn.Click += TryToStitchBtn_Click;
            // 
            // CrearBtn
            // 
            CrearBtn.Location = new Point(261, 914);
            CrearBtn.Margin = new Padding(4);
            CrearBtn.Name = "CrearBtn";
            CrearBtn.Size = new Size(122, 53);
            CrearBtn.TabIndex = 29;
            CrearBtn.Text = "Crear";
            CrearBtn.UseVisualStyleBackColor = true;
            CrearBtn.Click += CrearBtn_Click;
            // 
            // ReserchAndSaveChkBox
            // 
            ReserchAndSaveChkBox.AutoSize = true;
            ReserchAndSaveChkBox.Location = new Point(1052, 112);
            ReserchAndSaveChkBox.Name = "ReserchAndSaveChkBox";
            ReserchAndSaveChkBox.Size = new Size(91, 19);
            ReserchAndSaveChkBox.TabIndex = 31;
            ReserchAndSaveChkBox.Text = "Reserch&Save";
            ReserchAndSaveChkBox.UseVisualStyleBackColor = true;
            // 
            // RezultRTB
            // 
            RezultRTB.Location = new Point(391, 914);
            RezultRTB.Name = "RezultRTB";
            RezultRTB.Size = new Size(754, 53);
            RezultRTB.TabIndex = 32;
            RezultRTB.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 971);
            Controls.Add(RezultRTB);
            Controls.Add(ReserchAndSaveChkBox);
            Controls.Add(CrearBtn);
            Controls.Add(TryToStitchBtn);
            Controls.Add(SelectFilesBtn);
            Controls.Add(ReloadBtn);
            Controls.Add(DistortionBtn);
            Controls.Add(comboBox);
            Controls.Add(FileNumbrLabel);
            Controls.Add(button2);
            Controls.Add(DirectoryTextBox);
            Controls.Add(PrevBtn);
            Controls.Add(NextBtn);
            Controls.Add(MadePnrmBtn);
            Controls.Add(JoinBtn);
            Controls.Add(SaveBtn);
            Controls.Add(panel1);
            Controls.Add(label6);
            Controls.Add(StitchBtn);
            Controls.Add(pbResult);
            Controls.Add(pbImg2);
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
        private System.Windows.Forms.PictureBox pbImg2;
        private System.Windows.Forms.PictureBox pbResult;
        private System.Windows.Forms.Button StitchBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rcbType2;
        private System.Windows.Forms.RadioButton rcbType1;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button JoinBtn;
        private Button MadePnrmBtn;
        private Button NextBtn;
        private Button PrevBtn;
        private TextBox DirectoryTextBox;
        private Button button2;
        private Label FileNumbrLabel;
        private ComboBox comboBox;
        private Button DistortionBtn;
        private Button ReloadBtn;
        private Button SelectFilesBtn;
        private Button TryToStitchBtn;
        private Button CrearBtn;
        private CheckBox ReserchAndSaveChkBox;
        private RichTextBox RezultRTB;
    }
}
