using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CleanBinObj
{
    class Program
    {
        static void Main(string[] args)
        {

            // Use current directory if no argument has been specified
            string rootDir = Directory.GetCurrentDirectory();
            if (args.Length > 0) rootDir = args[0];

            int errors = removeBinObj(rootDir);

            Console.WriteLine();
            if (errors == 0)
            {
                Console.WriteLine("All directories were removed successfully");
            }
            else
            {
                Console.WriteLine("{0} directories couldn't be removed", errors);
            }
        }

        private static int removeBinObj(string rootDir)
        {
            // Read all the folder names in the specified directory tree
            string[] dirNames = Directory.GetDirectories(rootDir, "*.*", SearchOption.TopDirectoryOnly);
            string[] prjNames = Directory.GetFiles(rootDir, "*.*proj", SearchOption.TopDirectoryOnly);
            int errors = 0;

            if (prjNames.Length == 0)
            {
                foreach (string dir in dirNames)
                {
                    errors += removeBinObj(dir);
                }
            }
            else 
            {
                // Delete all the BIN and OBJ subdirectories
                foreach (string dir in dirNames)
                {
                    string dirName = Path.GetFileName(dir).ToLower();
                    if (dirName == "bin" || dirName == "obj" || dirName == "_upgradereport_files")
                    {
                        try
                        {
                            Console.Write("Deleting {0} ...", dir);
                            Directory.Delete(dir, true);
                            Console.WriteLine("DONE");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine();
                            Console.WriteLine(" ERROR: {0}", ex.Message);
                            errors += 1;
                        }
                    }
                }
            }

            return errors;
        }



    }
}
