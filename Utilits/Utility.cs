using System;
using System.IO;
using System.Text;

namespace converter
{
    public class Utility
    {
        public static bool CheckParamets(string[] args) {
            bool is_path = false;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-i":
                        is_path = true;
                        if(!ExistsValueParamter(args, i)) return false;
                        if(!File.Exists(args[i+1])) {
                                Console.WriteLine("Не найден файл по указанной пути " + args[i+1]);
                                return false;
                            }
                        i++;
                        break;
                    case "-q":
                        break;
                    case "-o":
                        if(!ExistsValueParamter(args, i)) return false;
                        if (!Directory.Exists(args[i+1])){
                            Console.WriteLine("Не найден такой путь для сохранения файла " + args[i+1]);
                            return false;
                        }
                        i++;
                        break;
                    case "-s":
                        if(!ExistsValueParamter(args, i)) return false;
                        i++;
                        break;
                    case "-e":
                        if(!ExistsValueParamter(args, i)) return false;
                        if(!CheckCorrectEncoding(args[i+1])){
                            Console.WriteLine("Не найден кодировка в виде " + args[i+1]);
                            return false;
                        }
                        i++;
                        break;
                    default:
                        Console.WriteLine("Не найден коданда в вида " + args[i]);
                        return false;
                }
            }
            if(!is_path)
            {
                Console.WriteLine("Пожалуйста введите путь к файлу с помощю ключом -i");
                return false;
            }
            return true;         
        }

        public static bool CheckCorrectEncoding(string enc)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                Encoding encoding = Encoding.GetEncoding(enc);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private static bool ExistsValueParamter(string[] args, int index)
        {
            if(index+1 == args.Length)
            {
                Console.WriteLine("Не нашли значения параметра " + args[index]);
                return false;
            }
            return true;
        }
    }
}