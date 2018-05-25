using System;
using Euler.Program.Processing;

namespace Euler.Program
{
    internal static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Project Euler workspace");
            Console.WriteLine();
            Console.WriteLine("This project contains my own solutions for Project Euler problems (https://projecteuler.net).");
            Console.WriteLine("And this console app includes template class generator.");
            Console.WriteLine();
            Console.WriteLine("Please enter problem number for generating class template for it:");

            var sNumber = Console.ReadLine();
            int number;
            if (!int.TryParse(sNumber, out number))
            {
                Console.WriteLine("Can't parse the number.");
                return;
            }

            try
            {
                GenerateProblemClass(number);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
            }
            Console.ReadKey();
        }

        private static void GenerateProblemClass(int number)
        {
            using (var downloader = new Downloader())
            {
                var htmlParser = new HtmlParser();
                var generator = new ClassGenerator();
                var saver = new FileSaver();
                
                var problem = new ProblemModel(number);
                downloader.Process(problem);
                htmlParser.Process(problem);
                generator.Process(problem);
                //saver.Process(problem);
                Console.WriteLine(problem.ClassCode);
            }
        }
    }
}
