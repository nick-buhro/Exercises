using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NickBuhro.ProjectEuler.Tools.TemplateGenerator
{
    internal sealed class DataProvider: IDisposable
    {
        private const string UrlPrefix = @"https://projecteuler.net/problem=";

        private readonly WebClient _web;

        private readonly Regex _rxName = new Regex(
            "<h2>(.+?)</h2>", 
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxDescr = new Regex(
            "<div class=\"problem_content\" role=\"problem\">(.+?)</div>", 
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxDescrParagraph = new Regex(
            "<p[^>]*>(.+?)</p>",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private readonly Regex _rxTag = new Regex(
            "<(.+?)>",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        public DataProvider()
        {
            _web = new WebClient();
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

            var match = _rxName.Match(html);
            if (match.Success)
            {
                result.Name = match.Groups[1].Value.Trim();
            }

            match = _rxDescr.Match(html);
            if (match.Success)
            {
                var innerHtml = match.Groups[1].Value;
                var matches = _rxDescrParagraph.Matches(innerHtml);

                var sb = new StringBuilder();
                foreach (Match m in matches)
                {
                    if (sb.Length != 0)
                        sb.AppendLine();

                    var line = m.Groups[1].Value;
                    line = _rxTag.Replace(line, " ")
                        .Replace("  ", " ")
                        .Replace(". ", "." + Environment.NewLine)
                        .Trim();

                    sb.AppendLine(line);
                }

                result.Description = sb.ToString();
            }

            return result;
        }
    }
}
