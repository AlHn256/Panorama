using OpenCvSharp;

namespace TestWinForm.Models
{
    public class PanoramicMerge
    {
        private string RezultDir = @"D:\Work\Exampels\Result\";


        public List<Records> StartReserchV2(List<SelectedFiles> FileList)
        {
            List<Records> RecordsList = new List<Records>();
            while (true)
            {

            }

            RecordsList.Add(new Records()
            {
                //FileN1 = i,
                //FileN2 = j,
                //FileName1 = FileList[i].Name,
                //FileName2 = FileList[j].Name,
                //FileFullName1 = FileList[i].File,
                //FileFullName2 = FileList[j].File,
                //BlockN = blok,
                //IsStiched = stitchChek,
                //IsRepited = isRepited,
                //IsLastSMFile = isLastSMFile
            });

            return RecordsList;
        }
        public List<Records> StartReserch(List<SelectedFiles> FileList)
        {
            List<Records> RecordsList = new List<Records>();
            int blok = 1;
            bool isLastSMFile = false;
            for (int i = 0; i < FileList.Count(); i++)
            {
                int j = i + 1;
                if (i + 1 > FileList.Count()) break;
                bool stitchChek = true;
                while (stitchChek)
                {
                    if (j + 1 > FileList.Count()) break;
                    stitchChek = tryStitch([FileList[i].File, FileList[j].File]);

                    Records? LastRecord;
                    bool isRepited = false;
                    if (RecordsList != null && RecordsList.Count() > 2)
                    {
                        LastRecord = RecordsList[RecordsList.Count() - 1];
                        isRepited = (LastRecord.FileN1 == i && LastRecord.FileN2 == j) ? true : false;
                        if (isRepited)
                        {
                            LastRecord.IsRepited = true;
                            break;
                        }
                    }

                    if (j == FileList.Count()) break;

                    RecordsList.Add(new Records()
                    {
                        FileN1 = i,
                        FileN2 = j,
                        FileName1 = FileList[i].Name,
                        FileName2 = FileList[j].Name,
                        FileFullName1 = FileList[i].File,
                        FileFullName2 = FileList[j].File,
                        BlockN = blok,
                        IsStiched = stitchChek,
                        IsRepited = isRepited,
                        IsLastSMFile = isLastSMFile
                    });
                    if (isRepited || isLastSMFile) break;
                    j++;
                }

                if (RecordsList[RecordsList.Count() - 1].IsRepited) break;

                i = j - 3;
                blok++;
            }

            return RecordsList;
        }
        public void TriplStitching(List<string[]> bloksForLoad)
        {
            string TextRezult = string.Empty, fileToSave = string.Empty;

            for (int i = 0; i < bloksForLoad.Count(); i++)
            {
                if (i < 10) fileToSave = @"D:\Work\Exampels\Result\Result0" + i + ".jpg";
                else fileToSave = @"D:\Work\Exampels\Result\Result" + i + ".jpg";
                TextRezult = fileToSave;

                bool isStitched = false;
                int attempt = 0;

                while (!isStitched && attempt < 3)
                {
                    isStitched = tryStitch(bloksForLoad[i]);
                    attempt++;
                }

                if (isStitched)
                {
                    TextRezult += "+";
                    if (LastTryStitchedImg.SaveImage(fileToSave)) TextRezult += "+ \n";
                    else TextRezult += "- \n";
                }
                else
                {
                    TextRezult += "-- \n";
                    foreach (var item in bloksForLoad[i]) TextRezult += item + "\n";
                }
            }

           // RezultRTB.Text = TextRezult;
        }
        public List<string[]> MergingSeparateFrames(List<Records> recordsList)
        {
            recordsList[0].fileForMerg = true;
            for (int i = 0; i < recordsList.Count(); i++)
            {
                if (!recordsList[i].IsStiched) recordsList[i - 1].fileForMerg = true;
                if (i == recordsList.Count() - 1 && recordsList[i].IsStiched)
                {
                    recordsList[i].fileForMerg = true;
                    break;
                }
            }

            List<string[]> mergBloksForSaving = new List<string[]>();
            //
            int[] mergBlok = new int[3];
            int counter = 0;
            bool isFirstFile = true;
            int LatestSuccessfulRecord = -1;
            for (int i = 0; i < recordsList.Count(); i++)
            {
                if (recordsList[i].fileForMerg) LatestSuccessfulRecord = i;

                if (isFirstFile && recordsList[i].fileForMerg)
                {
                    isFirstFile = false;
                    mergBlok[counter++] = i;
                }
                else if (recordsList[i].fileForMerg)
                {
                    mergBlok[counter++] = i;

                    if (counter == 3)
                    {
                        if (mergBloksForSaving.Count == 0) mergBloksForSaving.Add([recordsList[mergBlok[0]].FileFullName1, recordsList[mergBlok[1]].FileFullName2, recordsList[mergBlok[2]].FileFullName2]);
                        else mergBloksForSaving.Add([recordsList[mergBlok[0]].FileFullName2, recordsList[mergBlok[1]].FileFullName2, recordsList[mergBlok[2]].FileFullName2]);

                        counter = 0;
                        mergBlok[counter++] = mergBlok[2];
                    }
                    else if (i == recordsList.Count() - 1)
                    {
                        if (counter == 2) mergBloksForSaving.Add([recordsList[mergBlok[0]].FileFullName2, recordsList[mergBlok[1]].FileFullName2]);
                    }
                }
                else if (i == recordsList.Count() - 1)
                {

                }
            }

            return mergBloksForSaving;
        }
        private Mat LastTryStitchedImg {  get; set; }
        private bool tryStitch(string[] strImgs)
        {
            var Mats = strImgs.Select(x => new Mat(x)).ToArray();
            Stitcher stitcher = Stitcher.Create(Stitcher.Mode.Panorama);
            //if (comboBox.SelectedItem?.ToString() == "Panorama") stitcher = Stitcher.Create(Stitcher.Mode.Panorama);
            //else stitcher = Stitcher.Create(Stitcher.Mode.Scans);
            Mat pano = new Mat();
            Stitcher.Status status = stitcher.Stitch(Mats, pano);
            LastTryStitchedImg = pano;
            if (status == Stitcher.Status.OK) return true;
            //else RezultRTB.Text = status.ToString();
            return false;
        }

        public bool tryStitchAllFileInDir(string strImgs, string[] filter)
        {
            var fileList = new FileEdit().SearchFiles(RezultDir, filter, 1);
            string[] files = fileList.Where(f => f.Name != "Result.jpg").Select(x => x.FullName).ToArray();

            if (files == null) return false;
            if (files.Length == 0) return false;
            bool rezult = tryStitch(files);

            string TextRezult = rezult ? "Stitch +\n" : "Stitch -\n";

            if (rezult)
            {
                string fileToSave = RezultDir + "Result.jpg";
                if (LastTryStitchedImg.SaveImage(fileToSave)) TextRezult += "Saving to" + fileToSave + " + \n";
                else TextRezult += "Saving to" + fileToSave + " - \n";
            }

            return rezult;
        }
    }
}
