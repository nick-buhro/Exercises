using System;
using System.Net;
using System.Text;
using Xunit;

namespace Euler.Program.Processing
{
    internal sealed class Downloader: IDisposable
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
    }


    public sealed class DownloaderTests
    {
        [Fact]
        public void Test()
        {
            using (var d = new Downloader())
            {
                var problem = new ProblemModel(1);
                d.Process(problem);

                Assert.NotNull(problem.Html);
                Assert.True(problem.Html.Contains("</html>"));
            }
        }
    }
}
