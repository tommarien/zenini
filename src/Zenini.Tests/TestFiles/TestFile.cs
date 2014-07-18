using System.IO;

namespace Zenini.Tests.TestFiles
{
    public static class TestFile
    {
        public static readonly string Root;

        static TestFile()
        {
            Root = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "TestFiles"));
        }

        public static string Named(string name)
        {
            return Path.Combine(Root, name);
        }
    }
}