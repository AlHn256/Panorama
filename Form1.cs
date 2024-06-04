using OpenCvSharp;
using OpenCvSharp.Extensions;
using Panorama.AditionalForms;
using Panorama.Models;
using System.Diagnostics;
using System.Drawing.Imaging;
//https://blog.csdn.net/shanglianlm/article/details/84338133
//https://russianblogs.com/article/34762434934/
//https://pyimagesearch.com/2016/01/11/opencv-panorama-stitching/

namespace Panorama
{
    public partial class Form1 : Form
    {
        private Mat LasttryStitchedImg = new Mat();
        private FileEdit FileEdit = new FileEdit();
        private List<SelectedFiles> FileList = new List<SelectedFiles>();
        private string FileSaveString = string.Empty, RezultDir = @"D:\Work\Exampels\Result\", saveFileRecords = @"RecordsSave.json";
        private int FileSaveIndex = 0;
        private int FileNumber = 1;
        public int Test = 10;
        public string[] fileFilter = ["*.jpeg", "*.jpg", "*.png", "*.bmp"];

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
        private void MadePnrmBtn_Click(object sender, EventArgs e)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            pbResult.BackgroundImage = null;
            var name = FileList.Where(x => x.Name != "Result.jpg" && x.IsSelected).Select(x => x.File).ToArray();
            RezultRTB.Text = string.Join(" ", FileList.Where(x => x.Name != "Result.jpg" && x.IsSelected).Select(x => x.Name));

            var images = name.Select(x => new Mat(x)).ToArray();
            if (images != null && images.Length != 0) StitcheImg(images);

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;
            RezultRTB.Text += "\nTime " + String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
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
            if (string.IsNullOrEmpty(FirstImgTxtBox.Text.Trim()) || string.IsNullOrEmpty(FirstImgTxtBox.Text.Trim()))
            {
                MessageBox.Show("Пожалуйста, выберите картинки");
                return;
            }

            Image image1 = Image.FromFile(FirstImgTxtBox.Text.Trim());
            Image image2 = Image.FromFile(SecondImgTxtBox.Text.Trim());
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

            Mat srcImg1 = new Mat(FirstImgTxtBox.Text.Trim());
            Mat srcImg2 = new Mat(SecondImgTxtBox.Text.Trim());

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
            string file = "Result" + FileSaveIndex + ".jpg";
            FileSaveString = FileEdit.DirFile(DirectoryTextBox.Text, file);

            if (pbResult.BackgroundImage == null)
            {
                RezultRTB.Text = "Err pbResult.BackgroundImage == null !!!";
                return;
            }

            if (FileEdit.ChkFile(FileSaveString))
            {
                using (FileStream ms = new FileStream(FileSaveString, FileMode.Truncate, FileAccess.Write, FileShare.Read))
                {
                    pbResult.BackgroundImage.Save(ms, ImageFormat.Jpeg);
                    byte[] ar = new byte[ms.Length];
                    ms.Write(ar, 0, ar.Length);
                    ms.Close();
                    RezultRTB.Text = "File saved to:" + FileSaveString + "\n";
                }
            }
        }

        private void StitcheImg(Mat[] images) // Сшивание изображений
        {
            Stitcher stitcher;
            Mat pano = new Mat();
            try
            {
                if (comboBox.SelectedItem?.ToString() == "Panorama") stitcher = Stitcher.Create(Stitcher.Mode.Panorama);
                else stitcher = Stitcher.Create(Stitcher.Mode.Scans);

                Stitcher.Status status = stitcher.Stitch(images, pano);
                if (status != Stitcher.Status.OK)
                {
                    MessageBox.Show("Err.StitcheImg: " + status.ToString(), status.ToString() + "!!!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Err.StitcheImg: " + ex.Message + "!!!");
            }

            pbResult.BackgroundImage = BitmapConverter.ToBitmap(pano);
        }

        private void LoadeFiles()
        {
            if (string.IsNullOrEmpty(DirectoryTextBox.Text)) DirectoryTextBox.Text = FileEdit.GetDefoltDirectory();
            FileInfo[] fileList = FileEdit.SearchFiles(DirectoryTextBox.Text, fileFilter, 1);
            fileList = fileList.Where(f => f.Name.IndexOf("Result") == -1).ToArray();

            FileNumbrLabel.Text = fileList.Length + " файлов найдено";
            pbResult.BackgroundImage = null;
            if (fileList.Length > 1)
            {
                FileSaveString = FileEdit.DirFile(DirectoryTextBox.Text, "Result.jpg");
                FirstImgTxtBox.Text = fileList[0].FullName;
                SecondImgTxtBox.Text = fileList[1].FullName;
                FileNumber = 1;
                EnableBtn();
            }
            else
            {
                FileSaveString = string.Empty;
                FirstImgTxtBox.Text = string.Empty;
                SecondImgTxtBox.Text = string.Empty;
                DisEnableBtn();
                return;
            }

            int id = 0;
            FileList = fileList.Select(x => new SelectedFiles()
            {
                Id = id++,
                File = x.FullName,
                Name = x.Name,
                IsSelected = true
            }).ToList();
            FileNumbrLabel.Text += " \\ " + FileList.Count() + " выбранно";
        }

        private void FirstImgTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FirstImgTxtBox.Text)) pbImg1.BackgroundImage = Image.FromFile(FirstImgTxtBox.Text);
        }
        private void SecondImgTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(SecondImgTxtBox.Text)) pbImg2.BackgroundImage = Image.FromFile(SecondImgTxtBox.Text);
        }

        private void EnableBtn()
        {
            MadePnrmBtn.Enabled = true;
            NextBtn.Enabled = true;
            PrevBtn.Enabled = true;
            SaveBtn.Enabled = true;
        }
        private void DisEnableBtn()
        {
            MadePnrmBtn.Enabled = false;
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
            var fileList = FileList.Where(x => x.IsSelected).Select(x => x.File).ToList();

            if (fileList.Count != 0)
            {
                FileNumber = FileNumber + incr;
                if (FileNumber >= fileList.Count) FileNumber = 0;
                if (FileNumber < 0) FileNumber = fileList.Count - 1;
                SecondImgTxtBox.Text = fileList[FileNumber];
                if (FileNumber == 0) FirstImgTxtBox.Text = fileList[fileList.Count - 1];
                else FirstImgTxtBox.Text = fileList[FileNumber - 1];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK) DirectoryTextBox.Text = dialog.SelectedPath;
            }
        }

        private void DirectoryTextBox_TextChanged(object sender, EventArgs e) => LoadeFiles();
        private void ReloadBtn_Click(object sender, EventArgs e) => LoadeFiles();
        private void DistortionBtn_Click(object sender, EventArgs e)
        {
            DistortionTest distortionTest = new DistortionTest(DirectoryTextBox.Text);
            distortionTest.Show();
        }
        private void _CorrectFile(object file)
        {
            var newSelectedFiles = (SelectedFiles)file;
            var oldSelectedFiles = FileList.Where(x => x == newSelectedFiles).FirstOrDefault();
            if (oldSelectedFiles != null) { oldSelectedFiles = newSelectedFiles; }

            UpdateMessage();
        }

        private void _UpdateTable(object saveFile)
        {
            var SaveList = (List<int>)saveFile;
            for (int i = 0; i < FileList.Count; i++)
            {
                if (SaveList.Any(x => x == i)) FileList[i].IsSelected = true;
                else FileList[i].IsSelected = false;
            }

            UpdateMessage();
        }

        private void UpdateMessage()
        {
            RezultRTB.Text = string.Join(" ", FileList.Where(x => x.IsSelected).Select(x => x.Name));
            FileNumbrLabel.Text = FileList.Count() + " файлов найдено \\ " + FileList.Where(x => x.IsSelected).Count() + " выбранно";
        }

        private void SelectFilesBtn_Click(object sender, EventArgs e)
        {
            FileSelect fileSelect = new FileSelect(FileList);
            fileSelect.UpdateTable += _UpdateTable;
            fileSelect.CorrectFile += _CorrectFile;
            fileSelect.Show();
        }
        private void CrearBtn_Click(object sender, EventArgs e)
        {
            pbResult.BackgroundImage = null;
            FileSaveIndex = 0;
        }
        private void TryToStitchBtn_Click(object sender, EventArgs e) => CreatePanoram();
        private void CreatePanoram()
        {
            PanoramicMerge panoramicMerge = new PanoramicMerge();

            List<Records> recordsList = new List<Records>();
            if (ReserchAndSaveChkBox.Checked)
            {
                recordsList = panoramicMerge.StartReserchV2(FileList);

                if (recordsList != null || recordsList?.Count != 0) FileEdit.SaveRecords(saveFileRecords, recordsList);
            }

            recordsList = FileEdit.LoadRecords(saveFileRecords);

            List<string[]> bloksForLoad = panoramicMerge.MergingSeparateFrames(recordsList);

            if (bloksForLoad.Count != 0 && FileEdit.DelAllFileFromDir(RezultDir)) panoramicMerge.TriplStitching(bloksForLoad);

            panoramicMerge.tryStitchAllFileInDir(RezultDir, FileEdit.fileFilter);
        }

        private List<CopyList> CheckFileList;
        private FileList fileList;

        private void DelCopyBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DirectoryTextBox.Text)) return;
            FindCopyAndDel(DirectoryTextBox.Text);
        }
        private async void FindCopyAndDel(string Dir)
        {
            string rezulText = string.Empty;
            CheckFileList = new List<CopyList>();
            if (!Directory.Exists(Dir)) return;

            long maxLenghtFile = 16777216;
            fileList = new FileList(Dir, maxLenghtFile);
            //fileList.ProcessChanged += worker_ProcessChanged;

            string text = string.Empty;
            rezulText += "Start search" + "\nDir - " + Dir;
            await Task.Run(() => { fileList.MadeList(); });
            CheckFileList = fileList.GetList();
            rezulText += "\nFinish " + CheckFileList.Count();

            int i = 0, j = 0;
            for (i = 0; i < CheckFileList.Count() - 1; i++)
            {
                if (CheckFileList[i].Copy > -1) continue;
                string heshI = CheckFileList[i].Hesh;
                long fileLength = CheckFileList[i].FileLength;


                for (j = i + 1; j < CheckFileList.Count(); j++)
                {
                    if (CheckFileList[j].Copy > -1) continue;
                    if (fileLength != 0)
                    {
                        if (CheckFileList[j].Copy == -1 && fileLength == CheckFileList[j].FileLength)
                        {
                            CheckFileList[i].Copy = i;
                            CheckFileList[j].Copy = i;
                        }
                    }
                    else
                    {
                        if (CheckFileList[j].Copy == -1 && heshI == CheckFileList[j].Hesh)
                        {
                            CheckFileList[i].Copy = i;
                            CheckFileList[j].Copy = i;
                        }
                    }
                }
            }

            var copyList = CheckFileList.Where(x => x.Copy != -1).OrderBy(y => y.Copy).ToList();
            if (copyList.Count > 0)
            {
                i = -1;
                int nDelFiles = 0;
                foreach (var elem in copyList)
                {
                    if (i == elem.Copy)
                    {
                        elem.ForDel = true;

                        File.Delete(elem.File);
                        if (!File.Exists(elem.File)) nDelFiles++;
                        if (elem.FileLength == 0) text += "\n" + i + " " + elem.Copy + " " + elem.File + " " + elem.Hesh + "  - DELETED by HeshCOPY";
                        else text += "\n" + i + " " + elem.Copy + " " + elem.File + " " + elem.FileLength + "  - DELETED by LengthCOPY";

                    }
                    else
                    {
                        if (elem.FileLength == 0) text += "\n" + i + " " + elem.Copy + " " + elem.File + " " + elem.Hesh + "  -  HeshCOPY";
                        else text += "\n" + i + " " + elem.Copy + " " + elem.File + " " + elem.FileLength + "  -  LengthCOPY";
                    }
                    i = elem.Copy;
                }
                if (nDelFiles > 0) text += "\n" + nDelFiles + " Deleted Files!!!";
            }

            if (copyList.Count == 0) rezulText = text + "\n" + "Kопий Nет!";
            else rezulText = text + "\n" + copyList.Count + " kопий ";

            RezultRTB.Text = rezulText;
        }

        // Переименование файлов в обратном направлении
        //private void TestBtn_Click(object sender, EventArgs e)
        //{

        //    string Dir = "D:\\Work\\Exampels\\20";
        //    var files = fileEdit.SearchFiles(Dir);

        //    files = files.OrderByDescending(x=>x.Name).ToArray();

        //    if (files.Length > 0)
        //    {
        //        for (int i = 0;i< files.Length; i++)
        //        {
        //            string file = i<10? "00" + i + ".bmp":  "0" +i+".bmp";
        //            string newfilename = Dir +"\\"+ file;
        //            File.Move(files[i].FullName, newfilename);
        //        }
        //    }
        //}

        private void TestBtn_Click(object sender, EventArgs e)
        {
            var NewList= FileList.OrderByDescending(f => f.Name).ToList();
            int i = 0;
            string newDir = @"E:\Left\";
            foreach (var item in NewList)
            {
                string newFileName = newDir + i +".bmp";
                if(i<100) newFileName = newDir +"0" + i + ".bmp";
                if(i<10) newFileName = newDir +"00" + i + ".bmp";

                File.Move(item.File, newFileName);
                i++;
            }
        }
    }
}
