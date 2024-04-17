using ImageMagick;
using TestWinForm.Models;

namespace TestWinForm.AditionalForms
{
    public partial class DistortionTest : Form
    {
        private static int fileNumber = 0;
        private decimal A = 0.07m, B = -0.16m, C = -0.32m, D = 1.54m, Rotation = 0;
        private string[] fileFilter = ["*.jpeg", "*.jpg", "*.png", "*.bmp"];
        private FileEdit fileEdit = new FileEdit();

        public DistortionTest(string directory)
        {
            InitializeComponent();
            InputDirTxtBox.Text = directory;
            Load += OnLoad;

            this.AllowDrop = true;
            pictureBox1.AllowDrop = true;
            this.DragEnter += new DragEventHandler(WindowsForm_DragEnter);
            this.DragDrop += new DragEventHandler(WindowsForm_DragDrop);
            pictureBox1.DragEnter += new DragEventHandler(WindowsForm_DragEnter);
            pictureBox1.DragDrop += new DragEventHandler(WindowsForm_DragDrop);
        }

        void WindowsForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }
        void WindowsForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string textdir = string.Empty, Dir = string.Empty;
            foreach (string file in files)
            {
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) textdir += file + "\n";
                else textdir += Path.GetDirectoryName(file) + "\n";
                Dir = textdir;
            }
        }

        public class Order
        {
            public string? Name { get; set; }
            public int Value { get; set; }

            public Order(string name, int value)
            {
                Name = name;
                Value = value;
            }
        }

        private void OnLoad(object? sender, EventArgs e)
        {
            ATxtBox.Text = A.ToString();
            BTxtBox.Text = B.ToString();
            CTxtBox.Text = C.ToString();
            DTxtBox.Text = D.ToString();
            RotValTxtBox.Text = Rotation.ToString();


            var distortionMetods = Enum.GetValues(typeof(DistortMethod));
            DistortionMetodComBox.DataSource = distortionMetods;
            DistortionMetodComBox.SelectedItem = DistortMethod.Barrel;

            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(InputDirTxtBox.Text)) return;
            if (!fileEdit.ChkDir(OutputDirTxtBox.Text)) return;

            DistortMethod distortMethod = (DistortMethod)DistortionMetodComBox.SelectedItem;
            FileInfo[] fileList = fileEdit.SearchFiles(InputDirTxtBox.Text, fileFilter, 1);
            foreach (var file in fileList)
            {
                string outputFileNumber = OutputDirTxtBox.Text + "\\" + file.Name;
                File.WriteAllBytes(outputFileNumber, EditImg(file.FullName, distortMethod).ToByteArray());
                Image Img = Image.FromFile(outputFileNumber);
            }
        }

        private void ReloadImg()
        {
            string file = fileEdit.DirFile(InputDirTxtBox.Text, InputFileTxtBox.Text);
            if (!File.Exists(file)) return;

            DistortMethod distortMethod = new DistortMethod();
            if (DistortionMetodComBox.SelectedItem != null) distortMethod = (DistortMethod)DistortionMetodComBox.SelectedItem;
            else distortMethod = DistortMethod.Undefined;
            if (distortMethod == DistortMethod.Undefined) return;

            if (fileNumber > 10) fileNumber = 0;
            string outputFileNumber = "output" + fileNumber++ + ".jpg";

            //var fileToSave = EditImg(InputFileTxtBox.Text, distortMethod).ToByteArray();
            File.WriteAllBytes(outputFileNumber, EditImg(file, distortMethod).ToByteArray());
            pictureBox1.BackgroundImage = Image.FromFile(outputFileNumber);
        }

        //public void ResizeImg()
        //{
        //    using (MagickImage image = new MagickImage(InputFileTxtBox.Text))
        //    {
        //        //image
        //        int Width = image.Width * 80 / 100;
        //        int Height = image.Height * 80 / 100;
        //        //conf.Width = image.Width - (conf.Left * 2);
        //        //conf.Top = image.Height * conf.HeightProcent / 100;
        //        //conf.Height = image.Height - (conf.Top * 2);

        //        MagickGeometry geometry = new MagickGeometry();

        //        geometry.Width = Width;
        //        geometry.Height = Height;
        //        geometry.X = 0;
        //        geometry.Y = 300;
        //        image.Crop(geometry);
        //        image.Format = MagickFormat.Jpeg;

        //        string fileDest = @"D:\Work\Exampels\Result\Result.jpg";
        //        image.Write(fileDest);
        //    }
        //}

        private MagickImage EditImg(string InputFile, DistortMethod distortMethod)
        {
            MagickImage image = new MagickImage(InputFile);

            if (CropBeforeChkBox.Checked)
            {
                int X = 0, Y = 0, HeightPercent = 100, WidthPercent = 100;
                Int32.TryParse(XBeforeTxtBox.Text, out X);
                Int32.TryParse(YBeforeTxtBox.Text, out Y);
                Int32.TryParse(HeightBeforeTxtBox.Text, out HeightPercent);
                Int32.TryParse(WidthBeforeTxtBox.Text, out WidthPercent);

                MagickGeometry geometry = new MagickGeometry();
                geometry.Width = image.Width * WidthPercent / 100;
                geometry.Height = image.Height * HeightPercent / 100;
                geometry.X = X;
                geometry.Y = Y;
                image.Crop(geometry);
            }


            if (Rotation != 0 && RotationChkBox.Checked) image.Rotate((double)Rotation);
            if (DistortionChkBox.Checked)
            {
                if (distortMethod != DistortMethod.Undefined && distortMethod != DistortMethod.Sentinel && distortMethod != DistortMethod.Polynomial && distortMethod != DistortMethod.Perspective && distortMethod != DistortMethod.Arc) image.Distort(distortMethod, [(double)A, (double)B, (double)C, (double)D]);
                // if (distortMethod == DistortMethod.Perspective) image.Distort(DistortMethod.Perspective, new double[] { 0, 0, 20, 60, 90, 0, 70, 63, 0, 90, 5, 83, 90, 90, 85, 88 });
                if (distortMethod == DistortMethod.Perspective) image.Distort(DistortMethod.Perspective, new double[] { 0.0, 20.60, 90.0, 70.63, 0.90, 5.83, 90.90, 85.88 });
                if (distortMethod == DistortMethod.Arc) image.Distort(DistortMethod.Arc, 360);
            }

            if (CropAfterChkBox.Checked)
            {
                int X = 0, Y = 0, HeightPercent = 100, WidthPercent = 100;
                Int32.TryParse(XAfterTxtBox.Text, out X);
                Int32.TryParse(YAfterTxtBox.Text, out Y);
                Int32.TryParse(HeightAfterTxtBox.Text, out HeightPercent);
                Int32.TryParse(WidthAfterTxtBox.Text, out WidthPercent);

                MagickGeometry geometry = new MagickGeometry();
                geometry.Width = image.Width * WidthPercent / 100;
                geometry.Height = image.Height * HeightPercent / 100;
                geometry.X = X;
                geometry.Y = Y;
                image.Crop(geometry);
            }

            return image;
        }


        private void ABtnUp_Click(object sender, EventArgs e)
        {
            A = Convert.ToDecimal(ATxtBox.Text);
            A += 0.01m;
            ATxtBox.Text = A.ToString();
            ReloadImg();
        }

        private void ABtnDn_Click(object sender, EventArgs e)
        {
            A = Convert.ToDecimal(ATxtBox.Text);
            A -= 0.01m;
            ATxtBox.Text = A.ToString();
            ReloadImg();
        }

        private void BBtnUp_Click(object sender, EventArgs e)
        {
            B = Convert.ToDecimal(BTxtBox.Text);
            B += 0.01m;
            BTxtBox.Text = B.ToString();
            ReloadImg();
        }

        private void BBtnDn_Click(object sender, EventArgs e)
        {
            B = Convert.ToDecimal(BTxtBox.Text);
            B -= 0.01m;
            BTxtBox.Text = B.ToString();
            ReloadImg();
        }

        private void CBtnUp_Click(object sender, EventArgs e)
        {
            C = Convert.ToDecimal(CTxtBox.Text);
            C += 0.01m;
            CTxtBox.Text = C.ToString();
            ReloadImg();
        }

        private void CBtnDn_Click(object sender, EventArgs e)
        {
            C = Convert.ToDecimal(CTxtBox.Text);
            C -= 0.01m;
            CTxtBox.Text = C.ToString();
            ReloadImg();
        }

        private void DBtnUp_Click(object sender, EventArgs e)
        {
            D = Convert.ToDecimal(DTxtBox.Text);
            D += 0.01m;
            DTxtBox.Text = D.ToString();
            ReloadImg();
        }

        private void DBtnDn_Click(object sender, EventArgs e)
        {
            D = Convert.ToDecimal(DTxtBox.Text);
            D -= 0.01m;
            DTxtBox.Text = D.ToString();
            ReloadImg();
        }

        private void RBtnUp001_Click(object sender, EventArgs e)
        {
            Decimal.TryParse(RotValTxtBox.Text, out Rotation);
            Rotation += 0.01m;
            RotValTxtBox.Text = Rotation.ToString();
            ReloadImg();
        }

        private void RBtnDn001_Click(object sender, EventArgs e)
        {
            Decimal.TryParse(RotValTxtBox.Text, out Rotation);
            Rotation -= 0.01m;
            RotValTxtBox.Text = Rotation.ToString();
            ReloadImg();
        }

        private void RBtnUp01_Click(object sender, EventArgs e)
        {
            Decimal.TryParse(RotValTxtBox.Text, out Rotation);
            Rotation += 0.1m;
            RotValTxtBox.Text = Rotation.ToString();
            ReloadImg();
        }

        private void RBtnDn01_Click(object sender, EventArgs e)
        {
            Decimal.TryParse(RotValTxtBox.Text, out Rotation);
            Rotation -= 0.1m;
            RotValTxtBox.Text = Rotation.ToString();
            ReloadImg();
        }

        private void DTxtBox_TextChanged(object sender, EventArgs e)
        {
            D = Convert.ToDecimal(DTxtBox.Text);
            ReloadImg();
        }

        private void CTxtBox_TextChanged(object sender, EventArgs e)
        {
            C = Convert.ToDecimal(CTxtBox.Text);
            ReloadImg();
        }

        private void BTxtBox_TextChanged(object sender, EventArgs e)
        {
            B = Convert.ToDecimal(BTxtBox.Text);
            ReloadImg();
        }

        private void ATxtBox_TextChanged(object sender, EventArgs e)
        {
            A = Convert.ToDecimal(ATxtBox.Text);
            ReloadImg();
        }
        private void RotValTxtBox_TextChanged(object sender, EventArgs e)
        {
            Decimal.TryParse(RotValTxtBox.Text, out Rotation);
            ReloadImg();
        }

        private void DistortionMetodComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReloadImg();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)=>ReloadImg();
        private void label5_Click(object sender, EventArgs e)=>CropBeforeChkBox.Checked = !CropBeforeChkBox.Checked;
        private void label3_Click(object sender, EventArgs e)=>RotationChkBox.Checked = !RotationChkBox.Checked;
        private void DistortionMetodLabel_Click(object sender, EventArgs e)=>DistortionChkBox.Checked = !DistortionChkBox.Checked;



        int Xdn = 0, Ydn = 0, Xup = 0, Yup = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Xdn = e.X;
            Ydn = e.Y;
            RezultRTB.Text = "Dn X " + Xdn + " Y " + Ydn + "\n";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Xup = e.X;
            Yup = e.Y;
            RezultRTB.Text += "Up X " + Xup + " Y " + Yup + "\n";
            RezultRTB.Text += "e.Delta " + e.Delta + "e.Button " + e.Button + "e.Clicks " + e.Clicks + "e.Location " + e.Location.ToString();
        }

        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            InputDirTxtBox.Text = Path.GetDirectoryName(files[0]);
            OutputDirTxtBox.Text = Path.GetDirectoryName(files[0]);
            foreach (string filePath in files)
            {
                Console.WriteLine(filePath);
            }
        }

        private void pictur(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string textdir = string.Empty, Dir = string.Empty;
            foreach (string file in files)
            {
                FileAttributes attr = File.GetAttributes(file);
                if ((attr & FileAttributes.Directory) == FileAttributes.Directory) textdir = file;
                else textdir = Path.GetDirectoryName(file);
                Dir = textdir;
            }
        }

        private void InputDirTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputDirTxtBox.Text)) return;
            var files = fileEdit.SearchFiles(InputDirTxtBox.Text, fileEdit.GetFileFilter(), 1);
            if (files.Length > 0)
            {
                InputFileTxtBox.Text = files[0].Name;
                pictureBox1.BackgroundImage = Image.FromFile(files[0].FullName);
            }

            OutputDirTxtBox.Text = InputDirTxtBox.Text.FirstOf('\\') + "\\" + InputDirTxtBox.Text.LastOf('\\')+ "Out";
        }

        private void InputFileTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputFileTxtBox.Text)) return;

            string file = fileEdit.DirFile(InputDirTxtBox.Text, InputFileTxtBox.Text);
            if (File.Exists(file))pictureBox1.BackgroundImage = Image.FromFile(file);
        }
    }
}
