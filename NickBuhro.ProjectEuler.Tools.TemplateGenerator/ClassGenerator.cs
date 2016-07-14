using System;
using System.IO;
using System.Linq;

namespace NickBuhro.ProjectEuler.Tools.TemplateGenerator
{
    internal sealed class ClassGenerator
    {
        private readonly string _folder;

        public ClassGenerator(string outputFolder)
        {
            _folder = outputFolder;
        }

        public void Generate(ProblemInfo problem)
        {
            var className = "Problem" + problem.Id.ToString("000");
            var filePath = Path.Combine(_folder, className + ".cs");

            var fileText = ClassTemplate
                .Replace("{ProblemName}", problem.Name)
                .Replace("{ClassName}", className)
                .Replace("{Url}", problem.Url)
                .Replace("{Descr}", GenerateDescriptionComment(problem.Description));

            File.WriteAllText(filePath, fileText);
        }

        private static string GenerateDescriptionComment(string descr)
        {
            if (string.IsNullOrEmpty(descr))
                return ";

            var strs = descr.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None).Select(s => "    /// " + s + Environment.NewLine);
            return string.Join(", strs);
        }

        private const string ClassTemplate = @"using System;
using System.Globalization;
using Xunit;

namespace NickBuhro.Exercises.ProjectEuler
{
    /// <summary>
    /// {ProblemName}
    /// 
{Descr}    ///
    /// <seealso href="{Url}"/>
    /// </summary>
    public sealed class {ClassName}
    {            
        public void Test()
        {
                
        }

        public static long GetAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
";
    }
}
