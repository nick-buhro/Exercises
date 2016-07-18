using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NickBuhro.Exercises.ProjectEuler.Helper.Code.Processing
{
    public sealed class FileSaver
    {
        private readonly string _path;

        public FileSaver()
        {
            _path = Path.Combine(
                Path.GetDirectoryName(typeof (Program).Assembly.Location),
                "Output");

            if (Directory.Exists(_path))
            {
                var di = new DirectoryInfo(_path);
                foreach (var file in di.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(_path);
            }
        }

        public void Process(ProblemModel problem)
        {
            var filePath = Path.Combine(_path, problem.FileName);
            File.WriteAllText(filePath, problem.ClassCode, Encoding.UTF8);
        }
    }
}
