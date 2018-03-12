using System;
using System.IO;

namespace WordUnscrambler.Workers
{
    class FileReader
    {
        public string[] Read(string filePath)
        {
            string[] fileContent;
            try
            {
                fileContent = File.ReadAllLines(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return fileContent;


        }
    }
}
