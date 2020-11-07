﻿using System;
 using System.IO;

namespace Tracer.Print
{
    public class FilePrinter : IPrinter
    {
        private string FilePath;

        public FilePrinter(string filePath)
        {
            FilePath = filePath;
        }

        public void PrintResult(string data)
        {
            try
            {
                using (FileStream fstream = new FileStream(FilePath, FileMode.OpenOrCreate))
                {
                    byte[] array = System.Text.Encoding.Default.GetBytes(data);
                    fstream.Write(array, 0, array.Length);
                }
            }
            catch (DirectoryNotFoundException e)
            {
             Console.WriteLine(e.Message);   
            }
        }
    }
}