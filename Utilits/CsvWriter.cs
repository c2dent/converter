using System;
using System.IO;

namespace converter
{
    public class CsvWriter: IDisposable
    {
        StreamWriter streamWriter;
        string delimiter;
        public CsvWriter(StreamWriter sw, string delimiter) {
            this.streamWriter = sw;
            this.delimiter = delimiter;
        }

        public void Write(string text)
        {
            streamWriter.Write(text);
            streamWriter.Write(delimiter);
        }

        public void NexLine(){
            streamWriter.WriteLine();
        }

        public void Dispose(){
            streamWriter.Dispose();
        }
    }
}