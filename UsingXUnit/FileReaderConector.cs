using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingXUnit
{
    public class FileReaderConector : IFileReaderConector
    {
        public string ReadString(string fileName)
        {
            try
            {
                //Para que lea todas las líneas desde un archivo.
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
                string lines = File.ReadAllText(filePath);

                return lines;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File {fileName} not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return "";
        }
    }
}
