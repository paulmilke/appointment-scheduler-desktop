using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulingApp
{
    class FileLogging
    {

        public static void FileLogText(string user)
        {
            StreamWriter fileWriter;
            string filename = "logging.txt";
            FileStream output = new FileStream(filename, FileMode.Append, FileAccess.Write);
            fileWriter = new StreamWriter(output);

            DateTime current = DateTime.UtcNow;

            fileWriter.WriteLineAsync($"User:'{user}' logged into the app at {current.ToString()} UTC");
            fileWriter.Close(); 
        }

    }
}
