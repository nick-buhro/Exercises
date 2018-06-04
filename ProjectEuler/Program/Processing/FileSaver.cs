using System.IO;
using System.Text;

namespace Euler.Program.Processing
{
    internal sealed class FileSaver
    {
        private readonly string _path;

        public FileSaver()
        {
            _path = Path.GetDirectoryName(typeof(Program).Assembly.Location);
        }

        public void Process(ProblemModel problem)
        {
            var filePath = Path.Combine(_path, problem.FileName);
            File.WriteAllText(filePath, problem.ClassCode, Encoding.UTF8);
        }
    }
}
