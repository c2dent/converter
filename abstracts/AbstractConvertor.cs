using System;
using System.IO;
using System.Text;

namespace converter
{
    public abstract class AbstractConvertor: IConverter {
        protected string FileName {get; set;} = "";
        protected string OutFilePath {get; set;} = "";
        protected string InputFilePath {get; set;}
        protected string Delimiter {get; set;} = ",";
        protected Encoding Encoding {get; set;} = Encoding.UTF8;
        public AbstractConvertor(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-i":
                        i++;
                        InputFilePath = args[i];
                        FileName = Path.GetFileNameWithoutExtension(args[i]);
                        break;
                    case "-o":
                        i++;
                        OutFilePath = args[i];
                        if (!OutFilePath.Substring(OutFilePath.Length - 1).Equals("/")) OutFilePath += "/";
                        break;
                    case "-s":
                        i++;
                        Delimiter = args[i];
                        break;
                    case "-e":
                        i++;
                        Encoding = Encoding.GetEncoding(args[i]);
                        break;
                }
            }
        }

        public abstract void Convert();
    }
}