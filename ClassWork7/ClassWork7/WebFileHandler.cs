using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ClassWork7
{
    /// <summary>
    /// class web file handle
    /// </summary>
    class WebFileHandler
    {
        string Url { get; set; }
        List<string> FileList { get; set; }
        public TimeSpan TimeParallel { get; private set; }
        public TimeSpan TimeInOrder { get; private set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="url"></param>
        public WebFileHandler(string url)
        {
            this.Url = url;
        }

        /// <summary>
        /// method for write file name in list
        /// </summary>
        public void GetFileList()
        {
            this.FileList = new List<string>();
            var request = (FtpWebRequest)WebRequest.Create(this.Url);

            request.Method = WebRequestMethods.Ftp.ListDirectory;
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string line = reader.ReadLine();

            while (line != null)
            {
                this.FileList.Add(line);
                line = reader.ReadLine();
            }
        }

        /// <summary>
        /// method for download file
        /// </summary>
        /// <param name="file"></param>
        public void Download(object file)
        {
            var request = (FtpWebRequest)WebRequest.Create(this.Url + "/" + file);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            var response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            var fs = new FileStream((string)file, FileMode.Create);

            byte[] buffer = new byte[64];
            int size;

            while ((size = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fs.Write(buffer, 0, size);
            }
            fs.Close();
            response.Close();

            Console.WriteLine("Download " + file + " finish");
        }

        /// <summary>
        /// method for display file name
        /// </summary>
        public void Display()
        {
            foreach (var fileName in this.FileList)
            {
                Console.WriteLine(fileName);
            }
        }

        /// <summary>
        /// method for parallel download files
        /// </summary>
        public void ParallelDownloadFiles()
        {
            Console.WriteLine("Start parallel download");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int N = this.FileList.Count;
            var tasks = new Task[N];

            for (int i = 0; i < N; i++)
            {
                tasks[i] = new Task(this.Download, this.FileList[i]);
            }

            foreach (var task in tasks)
            {
                task.Start();
            }
            Task.WaitAll(tasks);
            stopwatch.Stop();
            this.TimeParallel = stopwatch.Elapsed;
            Console.WriteLine("finish parallel download");
        }

        /// <summary>
        /// method for downlod file in order
        /// </summary>
        public void InOrderDownloadFiles()
        {
            Console.WriteLine("Start in order download");
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var fileName in this.FileList)
            {
                this.Download(fileName);
            }

            stopwatch.Stop();
            this.TimeInOrder = stopwatch.Elapsed;
            Console.WriteLine("finish in order download");
        }

        /// <summary>
        /// method for compare time
        /// </summary>
        public void CompareTime() => Console.WriteLine(
            "Download time In order " + this.TimeInOrder.Milliseconds + "\n" +
            "Download time parallel " + this.TimeParallel.Milliseconds);

        /// <summary>
        /// method for delete file
        /// </summary>
        public void Delete()
        {
            foreach (var fileName in this.FileList)
            {
                var fileInfo = new FileInfo(fileName);

                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    Console.WriteLine($"File {fileName} deleted");
                }
            }
        }
    }
}
