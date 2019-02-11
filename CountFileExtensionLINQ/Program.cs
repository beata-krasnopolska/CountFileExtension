using System;
using System.IO;
using System.Linq;

namespace CountFileExtensionLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program counts file extension and group it using LINQ");
            string[] fileArray = { "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf", "aaaa.PDF", "xyz.frt", "abc.xml", "ccc.txt", "zzz.txt"};

            var groupedFiles = fileArray.Select(file => Path.GetExtension(file).TrimStart('.').ToLower())
                .GroupBy(z => z, (fExt, extCtr) => new
                        {
                            Extension = fExt,
                            Count = extCtr.Count()
                        });
            foreach (var i in groupedFiles)
            {
                Console.WriteLine("{0} File(s) with {1} Extension ", i.Count, i.Extension);
            }
            Console.ReadKey();
        }
    }
}
