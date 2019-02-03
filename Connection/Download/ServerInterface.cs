using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Connection.Download
{
    class ServerInterface
    {
        public static void DownloadSong(string FileName, int Size)
        {
            using (var output = File.Create(Environment.CurrentDirectory +  "\\Files\\" + FileName + ".mp3"))
                {
                // read the stream in chunks of 4KB
                int DownloadedBytes = 0;
                int percentage = 0;
                int LastPercentage = 0;
                var buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = Resources.ServerResources.stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, bytesRead);
                    DownloadedBytes += bytesRead;
                    percentage = (DownloadedBytes * 100) / Size;
                    if(percentage != LastPercentage)
                    {
                        Events.ClientEvents.DownloadPercentageChanged.OnAppear(new Events.Args.EventArgs.ClientEventArgs());
                    }
                    LastPercentage = percentage;
                    if (DownloadedBytes == Size)
                        break;
                }
                Console.WriteLine("Done.");
                string[] list = new string[1];
                list[0] = FileName;
                Events.ClientEvents.FileDownloaded.OnAppear(new Events.Args.EventArgs.ClientEventArgs() { List = list});
            }
        }
    }
}
