using System;
using System.Net;
using System.Text;
using Euler.Program.Templating;
using Xunit;

namespace Euler.Program.Processing
{
    public sealed class Downloader: IDisposable
    {
        private readonly WebClient _web;

        static Downloader()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls11 |
                SecurityProtocolType.Tls12 |
                SecurityProtocolType.Ssl3;
        }

        public Downloader()
        {

            // ReSharper disable once UseObjectOrCollectionInitializer
            _web = new WebClient();
            _web.Encoding = Encoding.UTF8;
            _web.UseDefaultCredentials = true;
            
        }

        public void Dispose()
        {
            _web.Dispose();
        }

        public void Process(ProblemModel problem)
        {
            problem.Html = _web.DownloadString(problem.Url);
        }


        [Fact]
        public void Test()
        {

            var problem = new ProblemModel(1);
            Process(problem);

            Assert.NotNull(problem.Html);
            Assert.True(problem.Html.Contains("</html>"));
        }
    }
}
