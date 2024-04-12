using ImageMagick;

namespace TestWinForm.AditionalForms
{
    public partial class DistortionTest : Form
    {
        private static int fileNumber = 0;
        private decimal A = 0.07m, B = -0.16m, C = -0.32m, D = 1.54m, Rotation = 0;
        private string[] fileFilter = ["*.jpeg", "*.jpg", "*.png", "*.bmp"];
        private FileEdit fileEdit = new FileEdit();

        public DistortionTest()
        {
            InitializeComponent();
            InputFileTxtBox.Text = "43.bmp";
            InputDirTxtBox.Text = @"D:\Work\Exampels\15";
            OutputDirTxtBox.Text = @"D:\Work\Exampels\Out";
            Load += OnLoad;
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

            //if (File.Exists(InputFileTxtBox.Text)) pictureBox1.BackgroundImage = Image.FromFile(InputFileTxtBox.Text);
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(InputDirTxtBox.Text)) return;

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
            if (!File.Exists(InputFileTxtBox.Text)) return;

            DistortMethod distortMethod = new DistortMethod();
            if (DistortionMetodComBox.SelectedItem != null) distortMethod = (DistortMethod)DistortionMetodComBox.SelectedItem;
            else distortMethod = DistortMethod.Undefined;
            if (distortMethod == DistortMethod.Undefined) return;

            if (fileNumber > 10) fileNumber = 0;
            string outputFileNumber = "output" + fileNumber++ + ".jpg";

            //var fileToSave = EditImg(InputFileTxtBox.Text, distortMethod).ToByteArray();
            File.WriteAllBytes(outputFileNumber, EditImg(InputFileTxtBox.Text, distortMethod).ToByteArray());
            pictureBox1.BackgroundImage = Image.FromFile(outputFileNumber);
        }

        public void ResizeImg()
        {
            using (MagickImage image = new MagickImage(InputFileTxtBox.Text))
            {

                //image
                int Width = image.Width * 80 / 100;
                int Height = image.Height * 80 / 100;
                //conf.Width = image.Width - (conf.Left * 2);
                //conf.Top = image.Height * conf.HeightProcent / 100;
                //conf.Height = image.Height - (conf.Top * 2);

                MagickGeometry geometry = new MagickGeometry();

                geometry.Width = Width;
                geometry.Height = Height;
                geometry.X = 0;
                geometry.Y = 300;
                image.Crop(geometry);
                image.Format = MagickFormat.Jpeg;

                string fileDest = @"D:\Work\Exampels\Result\Result.jpg";
                image.Write(fileDest);
            }

        }

        private MagickImage EditImg(string InputFile, DistortMethod distortMethod)
        {
            MagickImage image = new MagickImage(InputFile);

            if (CropChkBox.Checked)
            {
                int X = 0, Y = 0, HeightPercent = 100, WidthPercent = 100;
                Int32.TryParse(XTxtBox.Text, out X);
                Int32.TryParse(YTxtBox.Text, out Y);
                Int32.TryParse(HeightTxtBox.Text, out HeightPercent);
                Int32.TryParse(WidthTxtBox.Text, out WidthPercent);

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

        private void TestBtn_Click(object sender, EventArgs e)
        {
            //ResizeImg();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            ReloadImg();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            CropChkBox.Checked = !CropChkBox.Checked;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            RotationChkBox.Checked = !RotationChkBox.Checked;
        }

        private void DistortionMetodLabel_Click(object sender, EventArgs e)
        {
            DistortionChkBox.Checked = !DistortionChkBox.Checked;
        }

        int Xdn = 0, Ydn = 0, Xup = 0, Yup = 0;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Xdn = e.X;
            Ydn = e.Y;
            RezultRTB.Text ="Dn X "+ Xdn + " Y "+ Ydn + "\n";
            
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

        private void DistortionTest_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void DistortionTest_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}
