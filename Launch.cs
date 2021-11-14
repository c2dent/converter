using System;

namespace converter
{
    public class Launch
    {
        public void Main(String[] args)
        {
            if (Utility.CheckParamets(args)){
                IConverter converter = new CreatorJsonCsv().GetConverter(args);
                converter.Convert();
                LoadingPressKey(args);
            }
        }

        private void LoadingPressKey(string[] args) {
            for (int i = 0; i < args.Length; i++)
            {
                if(args[i].Equals("-q")) return;
            }
            Console.WriteLine("Файл успешно конвертирован!");
            Console.ReadKey();
        }
    }
}
