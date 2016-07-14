using Xunit;

namespace NickBuhro.Exercises.ProjectEuler.Helper.Code
{
    public sealed class ProblemModel
    {
        public int Id { get; }

        public string Html { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string ClassCode { get; set; }


        public string Url => @"https://projecteuler.net/problem=" + Id;
                               
        public string ClassName => "Problem" + Id.ToString("000");

        public string FileName => ClassName + ".cs";


        public ProblemModel(int id)
        {
            Id = id;
        }
    }

    public sealed class ProblemModelTests
    {
        [Fact]
        public void Test1()
        {
            var m = new ProblemModel(1);
            
            Assert.Equal(1, m.Id);
            Assert.Equal("Problem001", m.ClassName);
            Assert.Equal("Problem001.cs", m.FileName);
            Assert.Equal("https://projecteuler.net/problem=1", m.Url);
        }
        
        [Fact]
        public void Test999()
        {
            var m = new ProblemModel(999);

            Assert.Equal(999, m.Id);
            Assert.Equal("Problem999", m.ClassName);
            Assert.Equal("Problem999.cs", m.FileName);
            Assert.Equal("https://projecteuler.net/problem=999", m.Url);
        }
    }
}
