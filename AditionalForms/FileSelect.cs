
using TestWinForm.Models;

namespace TestWinForm.AditionalForms
{
    public partial class FileSelect : Form
    {
        private List<SelectedFiles> FileList { get; set; }
        private List<int> SaveList = new List<int>();
        public event Action<string> SendMsg;
        public event Action<SelectedFiles> CorrectFile;
        public event Action<List<int>> UpdateTable;
        private static int SelectedPage { get; set; }
        private static int MaximumImgPerPage { get; set; } = 12;
        private int MaxPage { get; set; }
        private const int NumberOfElement = 8;
        public bool AcceptNewList = false;
        private bool IsErr { get; set; } = false;
        private string ErrText { get; set; }
        public FileSelect(List<SelectedFiles> fileList)
        {
            InitializeComponent();
            FileList = fileList;
            if (FileList == null || FileList.Count() == 0)
            {
                SetErr("Err FileList == null || FileList.Count() == 0!!!");
                return;
            }
            else
            {
                MaxPage = FileList.Count() / NumberOfElement;
                if (MaxPage > 1) EnabledBtn();
                //LoadeFile();
                LoadNewElements();
            }

        }

        public void OnSendMsg(object text)
        {
            if (SendMsg != null) SendMsg((string)text);
        }
        public void OnCorrectFile(object file)
        {
            if (CorrectFile != null) CorrectFile((SelectedFiles)file);
        }

        private void OnUpdateTable(object saveList)
        {
            if (UpdateTable != null) UpdateTable((List<int>)saveList);
        }

        private void LoadNewElements()
        {
            //int tmp = 0;
            int i = 0, row = 0;
            //PrevBtn.Enabled = false;
            if (FileList.Count > MaximumImgPerPage) NextBtn.Enabled = true;
            var selectedFiles = FileList.Take(MaximumImgPerPage);

            foreach (var elem in selectedFiles)
            {
                if (i > 3)
                {
                    row++;
                    i = 0;
                }

                PictureBox pb = new PictureBox();
                pb.BackgroundImageLayout = ImageLayout.Zoom;
                pb.BorderStyle = BorderStyle.FixedSingle;
                pb.Location = new Point(13 + 260 * i, 41 + 281 * row);
                pb.Margin = new Padding(4);
                pb.Name = "pb" + i;
                pb.Size = new Size(246, 242);
                pb.TabIndex = 7;
                pb.TabStop = false;
                Controls.Add(pb);
                pb.BackgroundImage = Image.FromFile(elem.File);


                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Location = new Point(117 + 262 * i, 293 + 278 * row);
                checkBox.Name = "checkBox" + i.ToString();
                checkBox.Size = new Size(80, 17);
                checkBox.TabIndex = i++;
                checkBox.Text = elem.Name;
                checkBox.UseVisualStyleBackColor = true;
                checkBox.Checked = elem.IsSelected;
                checkBox.CheckedChanged += checkBoxChanged;
                Controls.Add(checkBox);
            }
        }

        private void ReloadElements()
        {
            int i = 0, j = 0;
            var selectedFiles = FileList.Skip(MaximumImgPerPage * SelectedPage).Take(MaximumImgPerPage).ToList();

            List<string> CheckBoxtestList = new List<string>();
            List<string> PictureBoxtestList = new List<string>();

            foreach (var elem in Controls)
            {
                if (elem is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)elem;
                    if (checkBox.Text != "All")
                    {
                        CheckBoxtestList.Add(checkBox.Text);
                        if (j < selectedFiles.Count)
                        {
                            checkBox.Text = selectedFiles[j].Name;
                            checkBox.Checked = selectedFiles[j++].IsSelected;
                            checkBox.Enabled = true;
                        }
                        else
                        {
                            checkBox.Enabled = false;
                            checkBox.Text = string.Empty;
                        }
                    }
                }

                if (elem is PictureBox)
                {
                    PictureBox pictureBox = (PictureBox)elem;
                    PictureBoxtestList.Add(pictureBox.Text);
                    if (i < selectedFiles.Count)
                    {
                        pictureBox.BackgroundImage = Image.FromFile(selectedFiles[i++].File);
                        pictureBox.Enabled = true;
                    }
                    else
                    {
                        pictureBox.BackgroundImage = null;
                        pictureBox.Enabled = false;
                    }
                }
            }
        }

        private void EnabledBtn()
        {

        }

        private bool SetErr(string errText)
        {
            IsErr = true;
            ErrText = errText;
            return false;
        }


        private void OkBtn_Click(object sender, EventArgs e)
        {
            AcceptNewList = true;
            Close();
        }

        private void CanselBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxChanged(object sender, EventArgs e)
        {
            var chb = (CheckBox)sender;
            SelectedFiles? file = FileList.Where(x => x.Name == chb.Text).FirstOrDefault();
            if (file != null)
            {
                file.IsSelected = chb.Checked;
                OnCorrectFile(file);
            }

            string txt = FileList.Count() + " файлов найдено \\ " + FileList.Where(x => x.IsSelected).Count() + " выбранно";
            OnSendMsg(txt);
        }

        private void checkBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (var elem in FileList) elem.IsSelected = checkBoxAll.Checked;
            foreach (var elem in Controls)
            {
                if (elem is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)elem;
                    checkBox.Checked = checkBoxAll.Checked;
                    // if (checkBox.Checked) strL.Add(checkBox.Text);
                }
            }
            //LoadeFile();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            SelectedPage++;
            PrevBtn.Enabled = true;
            if ((SelectedPage + 1) * MaximumImgPerPage > FileList.Count()) NextBtn.Enabled = false;
            else NextBtn.Enabled = true;
            ReloadElements();
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            SelectedPage--;
            NextBtn.Enabled = true;
            if (SelectedPage <= 0)
            {
                SelectedPage = 0;
                PrevBtn.Enabled = false;
            }
            ReloadElements();
        }

        private void MBtn_Click(object sender, EventArgs e)
        {
            if (SaveList == null) SaveList = new List<int>();
            SaveList.Clear();
            for (int i = 0; i < FileList.Count(); i++)
            {
                if (FileList[i].IsSelected) SaveList.Add(i);
            }
            MCBtn.Enabled = true;
            MRBtn.Enabled = true;
        }

        private void MRBtn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FileList.Count(); i++)
            {
                if (SaveList.Any(x => x == i)) FileList[i].IsSelected = true;
                else FileList[i].IsSelected = false;
            }
            ReloadElements();
            OnUpdateTable(SaveList);
        }

        private void MCBtn_Click(object sender, EventArgs e)
        {
            SaveList.Clear();
            MCBtn.Enabled = false;
            MRBtn.Enabled = false;
        }

        private void CBtn_Click(object sender, EventArgs e)
        {
            SaveList.Clear();
            foreach (var elem in FileList) elem.IsSelected = false;
            MCBtn.Enabled = false;
            MRBtn.Enabled = false;
            checkBoxAll.Checked = false;
            ReloadElements();
        }
    }
}
