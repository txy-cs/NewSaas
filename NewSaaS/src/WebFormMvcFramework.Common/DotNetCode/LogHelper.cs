using System;
using System.IO;
using WebFormMvcFramework.Common.DotNetConfig;

namespace WebFormMvcFramework.Common.DotNetCode
{
    public class LogHelper : IDisposable
    {
        private string LogFile;
        private static StreamWriter sw;
        private void writeInfos(string messagestr)
        {
            //DateTime DateNow = default(DateTime);
            try
            {
                this.FileOpen();
                string DateStr = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]";
                string sWrite = DateStr + "\n" + messagestr;
                LogHelper.sw.WriteLine(sWrite);
                LogHelper.sw.Flush();
                LogHelper.sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void FileOpen()
        {
            LogHelper.sw = new StreamWriter(this.LogFile, true);
        }

        private void FileClose()
        {
            if (LogHelper.sw != null)
            {
                LogHelper.sw.Flush();
                LogHelper.sw.Close();
                LogHelper.sw.Dispose();
                LogHelper.sw = null;
            }
        }

        public void WriteLog(string msg)
        {
            if (msg != null)
            {
                this.writeInfos(msg.ToString());
            }
        }

        public void Dispose()
        {
        }
    }
}