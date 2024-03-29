using OpenCvSharp;
using OpenCvSharp.Extensions;
using System.Drawing.Imaging;
//https://blog.csdn.net/shanglianlm/article/details/84338133
//https://russianblogs.com/article/34762434934/
//https://pyimagesearch.com/2016/01/11/opencv-panorama-stitching/

namespace TestWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox.DataSource = Enum.GetValues(typeof(Stitcher.Mode)).Cast<Stitcher.Mode>().Select(p => p.GetEnumDescription()).ToList();
            comboBox.DisplayMember = "Name";

            DisEnableBtn();
            LoadeFiles();
        }

        private OpenFileDialog FileDialog()
        {
            OpenFileDialog openFi = new OpenFileDialog();

            openFi.Filter = "файл изображения (jpeg, gif, bmp и т. Д.) | * .jpg; *. JPEG; *. GIF; *. BMP; *. Tif; * .tiff; * .png | файл изображения JPEG * .jpg; *. JPEG) "
                + "| * .jpg; * .jpeg | файл изображения gif (* .gif) | * .gif | файл изображения BMP (* .bmp) | * .bmp | файл изображения tiff (* .tif; *. tiff) | * .tif; *. Tiff | файл изображения PNG (* .png) "
                + "| * .png | Все файлы (*. *) | *. *";
            return openFi;
        }

        private void btnSelectImg1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFi = FileDialog();
            if (openFi.ShowDialog() == DialogResult.OK) FirstImgTxtBox.Text = openFi.FileName;
        }
        private void btnSelectImg2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFi = FileDialog();
            if (openFi.ShowDialog() == DialogResult.OK) SecondImgTxtBox.Text = openFi.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strImg1 = FirstImgTxtBox.Text.Trim();
            string strImg2 = SecondImgTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(strImg1))
            {
                MessageBox.Show("Пожалуйста, выберите рисунок 1");
                return;
            }
            if (string.IsNullOrEmpty(strImg2))
            {
                MessageBox.Show("Пожалуйста, выберите картинку 2");
                return;
            }
           
            Image image1 = Image.FromFile(strImg1);
            Image image2 = Image.FromFile(strImg2);
            if (rcbType1.Checked)
            {
                if (image1.Width != image2.Width)
                {
                    MessageBox.Show("Ширина изображения несовместима");
                    return;
                }
            }
            else
            {
                if (image1.Height != image2.Height)
                {
                    MessageBox.Show("Высота изображения несовместима");
                    return;
                }
            }
            pbResult.BackgroundImage = null;

            Mat srcImg1 = new Mat(strImg1);
            Mat srcImg2 = new Mat(strImg2);

            Mat ret = new Mat();
            if (rcbType1.Checked)
            {// вверх и вниз сращивание
                Cv2.VConcat(srcImg1, srcImg2, ret);
            }
            else
            {// левый и правый сплайс
                Cv2.HConcat(srcImg1, srcImg2, ret);
            }
            pbResult.BackgroundImage = BitmapConverter.ToBitmap(ret);
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            string strImg1 = FirstImgTxtBox.Text.Trim();
            string strImg2 = SecondImgTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(strImg1))
            {
                MessageBox.Show("Пожалуйста, выберите рисунок 1");
                return;
            }
            if (string.IsNullOrEmpty(strImg2))
            {
                MessageBox.Show("Пожалуйста, выберите картинку 2");
                return;
            }

            Image image1 = Image.FromFile(strImg1);
            Image image2 = Image.FromFile(strImg2);

            pbResult.BackgroundImage = null;

            Mat srcImg1 = new Mat(strImg1);
            Mat srcImg2 = new Mat(strImg2);

            Mat[] images = [srcImg1, srcImg2];
            StitcheImg(images);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (pbResult.BackgroundImage == null || string.IsNullOrEmpty(SaveFileLabel.Text)) return;

            FileEdit fileEdit = new FileEdit();
            if (fileEdit.ChkFile(SaveFileLabel.Text))
            {
                using (FileStream ms = new FileStream(SaveFileLabel.Text, FileMode.Truncate, FileAccess.Write, FileShare.Read))
                {
                    pbResult.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                    byte[] ar = new byte[ms.Length];
                    ms.Write(ar, 0, ar.Length);
                    ms.Close();
                }
                GC.Collect();
            }
        }

        private void StitcheImg(Mat[] images)
        {
            Stitcher stitcher;
            if(comboBox.SelectedItem?.ToString() == "Panorama") stitcher = Stitcher.Create(Stitcher.Mode.Panorama);
            else stitcher = Stitcher.Create(Stitcher.Mode.Scans);
            Mat pano = new Mat();
            var status = stitcher.Stitch(images, pano);
            if (status != Stitcher.Status.OK)
            {
                MessageBox.Show("Отказ: ", status.ToString());
                return;
            }
            pbResult.BackgroundImage = BitmapConverter.ToBitmap(pano);
        }

        void LoadeFiles()
        {
            FileEdit fileEdit = new FileEdit();
            if(string.IsNullOrEmpty(DirectoryTextBox.Text))DirectoryTextBox.Text = fileEdit.GetDefoltDirectory();
            
            FileList = fileEdit.SearchFiles(DirectoryTextBox.Text, ["*.jpeg", "*.jpg"], 1);

            FileNumbrLabel.Text = FileList.Length + " файлов найдено";
            if (FileList.Length > 1)
            {
                SaveFileLabel.Text = fileEdit.DirFile(DirectoryTextBox.Text, "Result.jpg"); 
                FirstImgTxtBox.Text = FileList[0].FullName;
                SecondImgTxtBox.Text = FileList[1].FullName;
                FileNumber = 1;
                EnableBtn();
            }
            else
            {
                SaveFileLabel.Text = string.Empty;
                FirstImgTxtBox.Text = string.Empty;
                SecondImgTxtBox.Text = string.Empty;
                DisEnableBtn();
            }
        }

        FileInfo[] FileList = [];
        int FileNumber = 1;

        private void TestBtn_Click(object sender, EventArgs e)
        {
            var name = FileList.Where(x=> x.Name!= "Result.jpg").Select(x => x.Name).ToArray();
            var images= name.Select(x => new Mat(x)).ToArray();
            if (images != null && images.Length != 0) StitcheImg(images);
        }

        private void FirstImgTxtBox_TextChanged(object sender, EventArgs e)
        {
           if(!string.IsNullOrEmpty(FirstImgTxtBox.Text)) pbImg1.BackgroundImage = Image.FromFile(FirstImgTxtBox.Text);
        }
        private void SecondImgTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SecondImgTxtBox.Text)) pbImg2.BackgroundImage = Image.FromFile(SecondImgTxtBox.Text);
        }

        private void EnableBtn()
        {
            TestBtn.Enabled = true;
            NextBtn.Enabled = true;
            PrevBtn.Enabled = true;
            SaveBtn.Enabled = true;
        }
        private void DisEnableBtn()
        {
            TestBtn.Enabled = false;
            NextBtn.Enabled = false;
            PrevBtn.Enabled = false;
            SaveBtn.Enabled = false;
            pbResult.BackgroundImage = null;
            pbImg1.BackgroundImage = null;
            pbImg2.BackgroundImage = null;
        }

        private void PrevBtn_Click(object sender, EventArgs e) => ChangeFiles(-1);
        private void NextBtn_Click(object sender, EventArgs e) => ChangeFiles(1);
        private void ChangeFiles(int incr)
        {
            FileNumber = FileNumber + incr;
            if (FileNumber >= FileList.Length) FileNumber = 0;
            if (FileNumber < 0) FileNumber = FileList.Length - 1;
            SecondImgTxtBox.Text = FileList[FileNumber].FullName;
            if (FileNumber == 0) FirstImgTxtBox.Text = FileList[FileList.Length - 1].FullName;
            else FirstImgTxtBox.Text = FileList[FileNumber - 1].FullName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DirectoryTextBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void DirectoryTextBox_TextChanged(object sender, EventArgs e)=>LoadeFiles();
    }
}
