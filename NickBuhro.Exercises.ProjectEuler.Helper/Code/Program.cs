using System;
using NickBuhro.Exercises.ProjectEuler.Helper.Code.Processing;

namespace NickBuhro.Exercises.ProjectEuler.Helper.Code
{
    internal static class Program
    {
        private static void Main()
        {
            var downloader = new Downloader();
            var htmlParser = new HtmlParser();
            var generator = new ClassGenerator();
            var saver = new FileSaver();

            try
            {
                for (var i = 1; i <= 566; i++)
                {
                    Console.WriteLine(i);

                    var problem = new ProblemModel(i);
                    downloader.Process(problem);
                    htmlParser.Process(problem);
                    generator.Process(problem);
                    saver.Process(problem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadKey();
            }
            finally
            {
                downloader.Dispose();
            }
        }
    }
}
