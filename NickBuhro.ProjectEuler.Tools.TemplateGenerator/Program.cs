using System;
using System.IO;

namespace NickBuhro.ProjectEuler.Tools.TemplateGenerator
{
    internal static class Program
    {
        private const int ProblemCount = 1; //566;
        
        private static void Main()
        {
            var provider = new DataProvider();
            try
            {
                var dirPath = Path.Combine(
                    Path.GetDirectoryName(typeof(Program).Assembly.Location),
                    "Output");
                
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
                Directory.CreateDirectory(dirPath);
                
                var generator = new ClassGenerator(dirPath);

                for (var i = 1; i <= ProblemCount; i++)
                {
                    Console.WriteLine("Problem {0,3} in progress...", i);

                    var problem = provider.GetProblem(i);
                    generator.Generate(problem);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
            finally
            {
                provider.Dispose();
            }
        }
    }
}
