using System;
using System.Collections.Generic;

namespace FileManagementAPP
{
    public class SaveFile
    {
        public string FolderPath { get; set; }
        public string FilePath { get; set; }
        public string FileContent { get; set; }
        public string FileTitle { get; set; }

        public SaveFile(string folderPath, string filePath, string fileTitle, string fileContent)
        {
            string directoryPath = Directory.GetCurrentDirectory();

            this.FolderPath = Path.Combine(directoryPath, folderPath);
            this.FilePath = Path.Combine(this.FolderPath, filePath);
            this.FileTitle = fileTitle;
            this.FileContent = fileContent;
        }

        public void CreateFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                    Console.WriteLine("That Folder exists already.");

                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CreateFile(string folderPath, string fileContent, string fileTitle)
        {
            string filePath = Path.Combine(folderPath, fileTitle + ".txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Title: " + fileTitle);
                    writer.WriteLine("Message: " + fileContent);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
