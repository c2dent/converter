using System;
using System.IO;
using System.Text;
using System.Data;
using Newtonsoft.Json;

namespace converter
{
    public class JsonToCsv: AbstractConvertor
    {
        public JsonToCsv(string[] args): base(args){}
        public override void Convert() {
            string json = FileReader(InputFilePath);
            DataTable jsonTable = JsonToDatable(json);
            WriteCsv(jsonTable);
        }

        private string FileReader(string path){
            StringBuilder stringBuilder = new StringBuilder();

            using (StreamReader sr = File.OpenText(InputFilePath))
            {
                string tempString;
                while((tempString = sr.ReadLine()) != null)
                {
                    stringBuilder.Append(tempString);
                }
            }
            return stringBuilder.ToString();
        }

        private DataTable JsonToDatable(string json) {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = JsonConvert.DeserializeObject<DataTable>(json);     
            }
            catch (System.Exception)
            {
                Console.WriteLine("Не удалость прочитать файл");
                Environment.Exit(0);
            }
            
            return dataTable;
        }

        private void WriteCsv(DataTable jsonTable){
            using (var streamWriter = new StreamWriter(OutFilePath + FileName + ".csv", false, Encoding)){
                using (var csv = new CsvWriter(streamWriter, Delimiter)) {
                    foreach (DataColumn column in jsonTable.Columns)
                    {
                        csv.Write(column.ColumnName);
                    }
                    csv.NexLine();
                    foreach (DataRow row in jsonTable.Rows)
                    {
                        foreach (DataColumn column in jsonTable.Columns)
                        {
                            csv.Write(row[column].ToString());
                        }
                        csv.NexLine();
                    }
                }
            }
        }
    }
}