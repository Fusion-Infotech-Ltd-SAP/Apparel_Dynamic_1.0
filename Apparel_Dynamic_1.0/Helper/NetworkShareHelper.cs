using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Apparel_Dynamic_1._0.Helper
{
    public static class NetworkShareHelper
    {
        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(ref NETRESOURCE netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);

        [StructLayout(LayoutKind.Sequential)]
        private struct NETRESOURCE
        {
            public int dwScope;
            public int dwType;
            public int dwDisplayType;
            public int dwUsage;
            public string lpLocalName;
            public string lpRemoteName;
            public string lpComment;
            public string lpProvider;
        }

        public static void ConnectToShare(string networkPath, string username, string password)
        {
            NETRESOURCE nr = new NETRESOURCE
            {
                dwType = 1,
                lpRemoteName = networkPath
            };

            int result = WNetAddConnection2(ref nr, password, username, 0);

            if (result != 0 && result != 1219)
                throw new Exception("Failed to connect to network share. Error code: " + result);
        }

        public static string CopyFile(string sourceFile, string rootPath, string username, string password, string formTitle, string documentCode, int rowNo)
        {
            ConnectToShare(rootPath, username, password);

            string safeFormTitle = MakeSafeFileName(formTitle);
            string safeDocumentCode = MakeSafeFileName(documentCode);

            string documentFolder = Path.Combine(rootPath, safeFormTitle, safeDocumentCode);

            if (!Directory.Exists(documentFolder))
                Directory.CreateDirectory(documentFolder);

            string originalName = MakeSafeFileName(Path.GetFileNameWithoutExtension(sourceFile));
            string extension = Path.GetExtension(sourceFile);
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmssfff");

            string newFileName = string.Format("{0}_{1}_R{2:D3}_{3}{4}",safeDocumentCode,timestamp,rowNo,originalName,extension);
            string destinationFile = Path.Combine(documentFolder, newFileName);
            File.Copy(sourceFile, destinationFile, false);

            return destinationFile;
        }

        public static void OpenFile(string filePath, string rootPath, string username, string password)
        {
            ConnectToShare(rootPath, username, password);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Attachment file not found.", filePath);

            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

        private static string MakeSafeFileName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "FILE";

            foreach (char c in Path.GetInvalidFileNameChars())
                value = value.Replace(c, '_');

            return value.Trim();
        }

        public static void DeleteFile(string filePath, string rootPath, string username, string password)
        {
            ConnectToShare(rootPath, username, password);

            if (string.IsNullOrWhiteSpace(filePath))
                return;

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}