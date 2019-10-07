using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace LOG
{
    /// <summary>
    /// version 2009.12.29
    /// </summary>
     public class LogFiles
    {
        private string logFileName = "LOG";
        private string logFileExt = "log";
        private string logFile = null;
        private RichTextBox rtb = null;
        private TextWriter logTextWriter = null;
        private ushort ctr = 0;

        //internal void CreateLog(string fileName, ListBox box)
        internal void CreateLog(string fileName, RichTextBox box)
        {
            if (box != null)
            {
                this.rtb = box;

            }

            //if (fileName.Contains("."))
            //{
            //    this.logFileName = fileName.Substring(0, fileName.IndexOf("."));
            //    this.logFileExt = fileName.Substring(fileName.IndexOf(".") + 1, fileName.Length - (fileName.IndexOf(".") + 1));
            //}
            //else
            {
                this.logFileName = fileName;
            }

            logFile = Application.StartupPath.ToString() + @"\LOG";

            // if logfile directory does not exists, create it
            bool blnDirectoryExists = Directory.Exists(logFile);
            if (!blnDirectoryExists)
            {
                try
                { Directory.CreateDirectory(logFile); }
                catch (Exception e)
                { MessageBox.Show("CREATELOG: " + e.ToString()); }
            }

            logFile += @"\" + logFileName + "_";
            logFile += DateTime.Now.ToString("yyyyMMMdd_HH_mm_ss");
            logFile += "." + logFileExt;

            bool blnFileExists = File.Exists(logFile);
            if (!blnFileExists)
            {
                try
                { 
                    TextWriter tw = new StreamWriter(logFile);
                    logTextWriter = TextWriter.Synchronized(tw);
                }
                catch (Exception e)
                { MessageBox.Show("CREATELOG: " + e.ToString()); }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal void CloseLog()
        {
            try
            {
                if (logTextWriter != null)
                { logTextWriter.Close(); }
            }
            catch (Exception e)
            { MessageBox.Show("WRITELOG:" + e.ToString()); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        internal void WriteLog(string msg, Color color)
        {
            if (msg == null) { msg = "NULL MESSAGE"; }

            try
            {
                if (rtb != null)
                {
                    //int maxLines = (lb.Size.Height / lb.ItemHeight);

                    //if (lb.Items.Count >= maxLines)
                    //{
                    //    lb.Items.RemoveAt(0);
                    //    lb.Items.Add(msg);
                    //}
                    //else
                    //{ lb.Items.Add(msg); }
                    rtb.SelectionColor = color;
                    rtb.AppendText(msg);
                    rtb.AppendText(Environment.NewLine);

                    
                }

                Console.WriteLine(msg);

                if (ctr > 65000)
                {
                    logTextWriter.WriteLine("CREATELOG triggered by line count");
                    logTextWriter.Flush();
                    logTextWriter.Close();

                    CreateLog(this.logFileName + "." + this.logFileExt, rtb);
                    ctr = 0;
                }

                logTextWriter.WriteLine(DateTime.Now.ToString("yyyyMMdd\tHH:mm:ss.fff\t") + " " + msg);
                logTextWriter.Flush();
                ctr++;
            }
            catch (Exception e)
            {
                logTextWriter.WriteLine("WRITELOG:" + e.ToString());
            }
        }

        /// <summary>
        /// delete all log files older than daysSaved
        /// </summary>
        internal void CleanLog(int daysSaved)
        {
            string logpath = Application.StartupPath.ToString() + @"\LOG";

            if (System.IO.Directory.Exists(logpath))
            {
                string[] files = System.IO.Directory.GetFiles(logpath);

                foreach (string s in files)
                {
                    FileInfo fi = new FileInfo(s);

                    if (DateTime.Compare(fi.LastWriteTime, DateTime.Today.Subtract(TimeSpan.FromDays(daysSaved))) < 0)
                    {
                        try
                        {
                            fi.Delete();
                        }
                        catch (System.IO.IOException e)
                        {
                           // WriteLog("CLEAN: " + e.ToString());
                            MessageBox.Show("CLEAN: " + e.ToString());
                        }
                    }
                }
            }
        }
    }
}
