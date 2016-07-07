using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Sautom.Client.Comunication.FileService;

namespace Sautom.Client.Comunication
{
    public class ClientFileHelper
    {
        public IFileService FilesService { get; set; }

        #region Cunstructors
        public ClientFileHelper(IFileService fileService)
        {
            FilesService = fileService;
        }
        #endregion

        #region Public
        public bool UploadFile(Guid clientId)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                if (File.Exists(dialog.FileName))
                {
                    byte[] fileData = ReadFile(dialog.FileName);
                    string fileName = dialog.FileName.Split('\\').Last().Split('.').First();
                    string fileExtension = "." + dialog.FileName.Split('\\').Last().Split('.').Last();

                    var data = new ClientFileUploadDtoInput()
                                   {
                                       ClientId = clientId,
                                       FileData = fileData,
                                       FileName = fileName,
                                       FileExtension = fileExtension
                                   };

                    FilesService.UploadFile(data);
                }
            }

            return true;
        }

        public bool DownloadFile(Guid fileId)
        {
            var file = FilesService.ClientFile(fileId);
            return DownloadFileOpen(file.FileName, file.FileExtension, file.FileData);
        }

        public bool PrintDocxFile(byte[] fileData)
        {
            string fileName = Path.GetTempFileName();
            WriteFile(fileName, fileData);

            Application wordApp = new Application { Visible = true };
            wordApp.Documents.Open(fileName);
            wordApp.ActiveDocument.PrintPreview();

            return true;
        }

        #endregion

        #region Private
        private byte[] ReadFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        private void WriteFile(string filePath, byte[] fileData)
        {
            using (FileStream fileStream = File.Exists(filePath) ? File.OpenWrite(filePath) : File.Create(filePath))
            {
                fileStream.Write(fileData, 0, fileData.Length);

                fileStream.Flush();
                fileStream.Close();
            }
        }
        #endregion

        #region Private helpers
        private bool DownloadFileDialog(string fileName, string fileExtension, byte[] fileData)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = fileName + fileExtension;
            dlg.DefaultExt = fileExtension;

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;

                WriteFile(filename, fileData);
            }

            return true;
        }

        private bool DownloadFileOpen(string fileName, string fileExtension, byte[] fileData)
        {
            string filePath = Path.GetTempPath() + fileName + fileExtension;
            File.Create(filePath).Close();

            WriteFile(filePath, fileData);

            Process.Start(filePath);

            return true;
        }
        #endregion
    }
}
