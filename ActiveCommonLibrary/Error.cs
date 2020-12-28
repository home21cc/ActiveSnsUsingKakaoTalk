using System;
using System.IO;
using System.Text;

namespace ActiveCommonLibrary
{
    public class Error
    {
        private static bool isWriteErrorMessage = true;
        static readonly StringBuilder mStringBuilder = new StringBuilder();

        public static bool ChkWriteMessage
        {
            get { return isWriteErrorMessage; }
            set { isWriteErrorMessage = value; }
        }

        public static void WriteError(string sMessage, string sType, string sCommandText)
        {
            mStringBuilder.Append("Error Time    : ");
            mStringBuilder.Append(DateTime.Now.ToShortDateString());
            mStringBuilder.Append(DateTime.Now.ToLongTimeString());
            mStringBuilder.AppendLine();
            mStringBuilder.Append("Error Message : ");
            mStringBuilder.Append(sMessage);
            mStringBuilder.AppendLine();

            if (!(string.IsNullOrEmpty(sType) || string.IsNullOrWhiteSpace(sType)))
            {
                mStringBuilder.AppendLine();
                mStringBuilder.Append("Error         : ");
                mStringBuilder.Append(sType);
                mStringBuilder.AppendLine();
            }

            if (!(string.IsNullOrEmpty(sCommandText) || string.IsNullOrWhiteSpace(sCommandText)))
            {
                mStringBuilder.Append("Procedure     : ");
                mStringBuilder.Append(sCommandText);
                mStringBuilder.AppendLine();
            }
            mStringBuilder.Append("----------------------------------------------------");
            Console.WriteLine(mStringBuilder.ToString());
            if (isWriteErrorMessage)
                WriteLog(mStringBuilder.ToString());
            mStringBuilder.Clear();
        }

        public static void WriteError(string sMessage, string sType)
        {
            WriteError(sMessage, sType, null);
        }

        public static void WriteError(string sMessage)
        {
            WriteError(sMessage, null, null);
        }

        public static void WriteLogEx(string sMessage, string sFilePath)
        {
            WriteLog(sMessage, sFilePath);
        }

        private static void WriteLog(string sMessage)
        {
            string applicationPath = SettingDefault.AppSettingPath.ToString();
            string filePath = applicationPath + @"\ErrorLog";

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = string.Format("[ErrorHistory_{0}].txt", DateTime.Now.ToShortDateString());
            string fileNamePath = filePath + "\\" + fileName;

            if (!File.Exists(fileNamePath))
            {
                FileStream fileStream = File.Create(fileNamePath);
                fileStream.Close();
            }

            StreamWriter streamWriter = new StreamWriter(fileNamePath, true);
            streamWriter.WriteLine(sMessage);
            streamWriter.Close();
        }

        private static void WriteLog(string sMessage, string filePath)
        {
            string applicationPath = SettingDefault.AppSettingPath.ToString();
            filePath = applicationPath + "\\" + filePath;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = string.Format("[{0}_Log].txt", DateTime.Now.ToLongDateString());
            string fileNamePath = filePath + "\\" + fileName;

            if (!File.Exists(fileNamePath))
            {
                FileStream fileStream = File.Create(fileNamePath);
                fileStream.Close();
            }

            StreamWriter streamWriter = new StreamWriter(fileNamePath, true);
            streamWriter.WriteLine(sMessage);
            streamWriter.Close();
        }
    }
}
