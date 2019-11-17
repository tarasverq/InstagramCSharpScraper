using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace InstagramCSharpScraper.Tests
{
    [SetUpFixture]
    public class SetUpClass
    {
        internal static TestSettings Settings { get; private set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            Settings = configuration.Get<TestSettings>();
        }


        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}