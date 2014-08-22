using System;
using System.IO;
using System.Text;
using NUnit.Framework;
using Zenini.Readers;

namespace Zenini.Tests.Reading
{
    public abstract class SettingsReaderFixture
    {
        protected ISettingsReader Reader { get; private set; }
        protected StringBuilder Source { get; private set; }

        [SetUp]
        public void Setup()
        {
            Reader = new DefaultSettingsReader(StringComparer.OrdinalIgnoreCase);
            Source = new StringBuilder();

            AfterSetup();
        }

        protected virtual void AfterSetup()
        {
        }

        protected IIniSettings ReadFromSource()
        {
            using (var sr = new StringReader(Source.ToString()))
                return Reader.Read(sr);
        }
    }
}