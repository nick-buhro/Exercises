using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Euler.Program.Processing.TestCases.HtmlParser
{
    public sealed class TestCase
    {
        private static readonly Regex NameRegex = new Regex(
            "<!--{{(.+?)}}-->",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        private static readonly Regex DescrRegex = new Regex(
            "<!--<<(.+?)>>-->",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.Singleline);

        public readonly string Html;
        public readonly string Name;
        public readonly string Description;

        public TestCase(int id)
        {
            var t = typeof (TestCase);
            var resourceName = t.FullName + id.ToString("000") + ".html";
            using (var stream = t.Assembly.GetManifestResourceStream(resourceName))
            using (var sr = new StreamReader(stream))
            {
                Html = sr.ReadToEnd();
            }

            Name = NameRegex.Match(Html).Groups[1].Value.Trim();

            var descr = DescrRegex.Match(Html).Groups[1].Value.Trim();
            var strs = descr.Split(new[] {Environment.NewLine}, StringSplitOptions.None).Select(s => s.Trim());
            Description = string.Join(Environment.NewLine, strs);
        }
    }
}
