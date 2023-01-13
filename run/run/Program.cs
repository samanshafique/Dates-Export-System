using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace run
{
    class Program
    {
         Dictionary<string, string> errors = new Dictionary<string, string>();
         List<string> result = new List<string>();
        public void SearchForFiles(string path)
        {
            try
            {
                foreach (string fileName in Directory.GetFiles(path))//Gets all files in the current path
                {
                    result.Add(fileName);
                }

                foreach (string directory in Directory.GetDirectories(path))//Gets all folders in the current path
                {
                    SearchForFiles(directory);//The methods calls itself with a new parameter, here!
                }
                Console.WriteLine("Successfully fetched files in {0}", path);
            }
            catch (System.Exception ex)
            {
                errors.Add(path, ex.Message);//Stores Error Messages in a dictionary with path in key
            }
        }
        static void Main(string[] args)
        {
            var mc = new Program();
            Console.WriteLine("Showing files in (\"C:\\\\Users\\\\dc\\\\OneDrive\\\\Documents\")");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------");
            mc.SearchForFiles("C:\\Users\\dc\\OneDrive\\Documents");
            Console.ReadLine();
        }
    }
}
