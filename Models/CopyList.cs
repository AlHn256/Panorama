namespace TestWinForm.Models
{
    public class CopyList
    {
        public string File { get; set; }
        public bool ForDel { get; set; }
        public string Hesh { get; set; }
        public int Copy { get; set; }
        public long FileLength { get; set; }
        public CopyList(string file, string hesh, int copy)
        {
            File = file;
            Hesh = hesh;
            Copy = copy;
        }

        public CopyList(string file, string hesh, long fileLength)
        {
            File = file;
            Hesh = hesh;
            FileLength = fileLength;
            Copy = -1;
        }

        public CopyList(string file, string hesh)
        {
            File = file;
            Hesh = hesh;
            Copy = -1;
        }
    }

}
