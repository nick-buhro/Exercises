using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Euler.Program.Processing.TestCases.HtmlParser;
using HtmlAgilityPack;
using Xunit;

namespace Euler.Program.Processing
{
    internal sealed class HtmlParser
    {
        private readonly HtmlDocument _doc = new HtmlDocument();

        public void Process(ProblemModel problem)
        {
            _doc.LoadHtml(problem.Html);
            problem.Name = GetProblemName();
            problem.Description = GetProblemDescr();
        }

        private string GetProblemName()
        {
            return _doc.DocumentNode.SelectSingleNode("//h2").InnerText;
        }

        private string GetProblemDescr()
        {
            var div = _doc.DocumentNode.SelectNodes("//div")
                .First(n => n.Attributes.Any(a => (a.Name == "class") && (a.Value == "problem_content")));

            var result = new StringBuilder();
            foreach (var child in div.ChildNodes)
            {
                if (child.Name == "#text")
                    continue;

                var text = HtmlToText(child.InnerHtml);

                text = Regex.Replace(text,
                    @"([^\.])\. ([A-Z])",
                    "$1.\r\n$2");

                if (result.Length > 0)
                    result.AppendLine();
                result.AppendLine(text);
            }
            return result.ToString().Trim();
        }

        private string HtmlToText(string html)
        {
            var result = html
                .Replace(Environment.NewLine, " ")
                .Replace('\n', ' ')
                .Replace('\r', ' ')
                .Replace("<br>", Environment.NewLine)
                .Replace("<br/>", Environment.NewLine);

            result = Regex.Replace(result,
                @"<sup>(\d+)</sup>/<sub>(\d+)</sub>",
                "$1/$2");

            result = Regex.Replace(result,
                @"\s*<sup>([0-9a-zA-Z]+)</sup>",
                "**$1");

            result = Regex.Replace(result,
                @"<(.+?)>",
                "");
            
            return result
                .Replace(Environment.NewLine + " ", Environment.NewLine)
                .Replace("  ", " ")
                .Replace("  ", " ")
                .Trim();
        }
    }


    public sealed class HtmlParserTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void Test(int testCaseId)
        {
            var testCase = new TestCase(testCaseId);

            var problem = new ProblemModel(testCaseId) { Html = testCase.Html };
            new HtmlParser().Process(problem);

            Assert.Equal(testCase.Name, problem.Name);
            Assert.Equal(testCase.Description, problem.Description);
        }
    }
}
