using System.Security.Cryptography;

namespace Panorama.Models
{
    public class FileList
    {
        private List<CopyList> CheckFileList { get; set; }
        private String Dir { get; set; }
        private long MaxLenghtFile { get; set; }
        private SearchOption serrchOption { get; set; }
        private bool _canselled { get; set; }
        public void Cansel()
        {
            _canselled = true;
        }

        public FileList(string dir, long maxLenghtFile, bool srchOptions = false)
        {
            MaxLenghtFile = maxLenghtFile;
            Dir = dir;
            _canselled = false;
            CheckFileList = new List<CopyList>();

            if(srchOptions) serrchOption = SearchOption.AllDirectories;
            else serrchOption = SearchOption.TopDirectoryOnly;
        }

        public List<CopyList> GetList()
        {
            return CheckFileList;
        }

        public void MadeList()
        {
            string[] dirs = Directory.GetFiles(Dir, "*.*", serrchOption);
            int dirsLength = dirs.Length;
            if (dirsLength != 0)
            {
                int i = 0;
                foreach (string file in dirs)
                {
                    if (_canselled) break;

                    FileInfo fileInf = new FileInfo(file);
                    if (MaxLenghtFile == 0)
                    {
                        string md5 = ComputeMD5Checksum(file);
                        CheckFileList.Add(new CopyList(file, md5, fileInf.Length));
                    }
                    else
                    {
                        if (fileInf.Length < MaxLenghtFile)
                        {
                            string md5 = ComputeMD5Checksum(file);
                            CheckFileList.Add(new CopyList(file, md5));
                        }
                        else
                        {
                            CheckFileList.Add(new CopyList(file, "", fileInf.Length));
                        }
                    }

                   
                }
               
            }
        }

        public void OnProgressChanged(object i)
        {
            if (ProcessChanged != null) ProcessChanged((int)i);
        }

        public event Action<int> ProcessChanged;

        private string ComputeMD5Checksum(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                //string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                string result = BitConverter.ToString(checkSum);
                return result;
            }
        }
    }
}
