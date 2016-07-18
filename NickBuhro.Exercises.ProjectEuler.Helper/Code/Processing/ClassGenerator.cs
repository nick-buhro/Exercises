using System;
using System.Collections.Generic;

namespace NickBuhro.Exercises.ProjectEuler.Helper.Code.Processing
{
    public sealed class ClassGenerator
    {
        public void Process(ProblemModel problem)
        {
            problem.ClassCode = new ClassGeneratorImpl(problem)
                .TransformText();
        }
    }


    partial class ClassGeneratorImpl
    {
        private readonly ProblemModel _problem;

        internal ClassGeneratorImpl(ProblemModel problem)
        {
            _problem = problem;
        }

        public IEnumerable<string> GetDescrLines()
        {
            if (string.IsNullOrEmpty(_problem?.Description))
                yield break;

            var strs = _problem.Description.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);
            foreach (var s in strs)
            {
                yield return s;
            }
        }

    }
}
