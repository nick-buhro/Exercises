using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace NickBuhro.ProjectEuler.Tools.TemplateGenerator
{
    internal sealed class DataProvider: IDisposable
    {
        private const string UrlPrefix = @"https://projecteuler.net/problem=";

        private readonly WebClient _web;

        private readonly Regex _rxName = new Regex(
            "<h2>(.+?)</h2>", 
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxTag = new Regex(
            "<(.+?)>",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxDiv = new Regex(
            "<sup>(\\d+)</sup>/<sub>(\\d+)</sub>",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxPow = new Regex(
            "\\s*<sup>(\\d+)</sup>",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);
        
        public DataProvider()
        {
            _web = new WebClient {Encoding = Encoding.UTF8};
        }

        public void Dispose()
        {
            _web.Dispose();
        }

        public ProblemInfo GetProblem(int id)
        {
            var result = new ProblemInfo
            {
                Id = id,
                Url = UrlPrefix + id.ToString(CultureInfo.InvariantCulture)
            };

            var html = _web.DownloadString(result.Url);

            result.Name = GetProblemName(html);
            result.Description = GetProblemDescr(html);

            return result;
        }

        private string GetProblemName(string html)
        {
            var match = _rxName.Match(html);
            return match.Success
                ? HtmlToText(match.Groups[1].Value)
                : "";
        }

        private string GetProblemDescr(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var div = doc.DocumentNode.SelectNodes("//div")
                .First(n => n.Attributes.Any(a => (a.Name == "class") && (a.Value == "problem_content")));

            var result = new StringBuilder();
            foreach (var child in div.ChildNodes)
            {
                if (child.Name == "#text")
                    continue;

                var text = HtmlToText(child.InnerHtml)
                    //.Replace(". ", "." + Environment.NewLine)
                    ;

                if (result.Length > 0)
                    result.AppendLine();
                result.AppendLine(text);
            }
            return result.ToString().Trim();
        }


        private string HtmlToText(string html)
        {
            var result = html
                .Replace("Г—", "*")
                .Replace(Environment.NewLine, " ")
                .Replace('\n', ' ')
                .Replace('\r', ' ')
                .Replace("<br>", Environment.NewLine)
                .Replace("<br/>", Environment.NewLine);

            

            result = _rxDiv.Replace(result, "$1/$2");
            result = _rxPow.Replace(result, "**$1");
            result = _rxTag.Replace(result, " ");

            return result
                .Replace(Environment.NewLine + " ", Environment.NewLine)
                .Replace("  ", " ")
                .Replace("  ", " ")
                .Trim();
        }
    }
}
