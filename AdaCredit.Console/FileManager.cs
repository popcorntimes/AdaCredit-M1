using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using Bogus.DataSets;

namespace AdaCredit
{
    public class FileManager
    {
        private string Path_file { get; set; }
        CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture);
        public List<string> File_name_path { get; set; } = new List<string>();
        public List<string> File_name { get; set; } = new List<string>();


        public FileManager(string name) {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string path = Path.Join(projectDirectory, name);
            this.Path_file = path;

        }

        public FileManager(int type)
        {
            string folderPath = @"\Transactions";

            if (type == 1)
            {
                folderPath = @"\Transactions\Completed";

            } else if (type == 2)
            {
                folderPath = @"\Transactions\Failed";

            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            string path = Path.Join(desktopPath, folderPath);
            this.Path_file = path;
            var csvFiles = Directory.GetFiles(this.Path_file);
            //var csvFiles = Directory.EnumerateFiles(this.Path_file, "*.csv", SearchOption.AllDirectories);
            foreach (string currentFile in csvFiles)
            {
                
                File_name_path.Add(currentFile);
                File_name.Add(Path.GetFileName(currentFile));

            }

        }
        public List<string> GetFilePaths()
        {
            return this.File_name_path;
        }

        public List<string> GetFileNames()
        {
            return this.File_name;
        }



        public List<T> TransactionReader<T>(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) {HasHeaderRecord = false };
            using var reader = new StreamReader(path);
            using var csvReader = new CsvReader(reader, config);

            return csvReader.GetRecords<T>().ToList();
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
