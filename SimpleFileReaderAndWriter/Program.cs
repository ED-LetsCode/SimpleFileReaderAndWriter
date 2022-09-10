using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileReaderAndWriter
{
    internal class Program
    {
        static List<string> carBrands = new List<string>();
        static string path = Directory.GetCurrentDirectory().Replace("\\bin\\Debug", "");
        static string newFilePath;
        static void Main(string[] args)
        {
            ReadFile();
            SortAndCreateNewFile();

            Console.WriteLine($"New file created PATH: {newFilePath} \n");
            carBrands.ForEach(carBrand => Console.WriteLine(carBrand));
            Console.ReadKey();
        }

        /// <summary>
        /// Reads file and adds it to the list
        /// </summary>
        static void ReadFile()
        {
            try
            {
                using (var fileReader = new StreamReader(path + "\\carBrands.txt"))
                {
                    string line;
                    while ((line = fileReader.ReadLine()) != null)
                    {
                        carBrands.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Sorts list and creates a new .txt file
        /// </summary>
        static void SortAndCreateNewFile()
        {
            try
            {
                using (var fileWriter = new StreamWriter(newFilePath = path + "\\sortedCarBrands.txt"))
                {
                    carBrands.Sort();
                    carBrands.ForEach(carBrand => fileWriter.WriteLine(carBrand));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
