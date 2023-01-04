using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace AdaCredit
{
    public class FileManager
    {
        private string Path_file { get; set; }
        CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);


        public FileManager(string name) {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = Path.Join(projectDirectory, name);
            this.Path_file = path;

        }

        public List<T> CsvReader<T>()
        {
            using var reader = new StreamReader(this.Path_file);
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

            return csvReader.GetRecords<T>().ToList();

        }


        public void CsvWriter<T>(List<T> obj)
        {

            using var writer = new StreamWriter(this.Path_file);
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(obj);
                

        }



    }
} 
