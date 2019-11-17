using System.Collections.Generic;
using System.Threading.Tasks;
using InstagramCSharpScraper.Models;
using NUnit.Framework;

namespace InstagramCSharpScraper.Tests
{
    public class Tests
    {
        private readonly string _username;
        private readonly string _password;

        public Tests()
        {
            _username = SetUpClass.Settings.instagram_username;
            _password = SetUpClass.Settings.instagram_password;
        }


        [SetUp]
        public void Setup()
        {
        }

        private async Task<Instagram> LogIn()
        {
            Instagram instagram = new Instagram(_username, _password, new DefaultHttpClient());
            await instagram.Login();

            return instagram;
        }

        [Test]
        public async Task LogInTest()
        {
            Instagram instagram = await LogIn();
            Assert.IsTrue(instagram.IsLoggedIn);
        }

        [Test]
        public async Task GetPageTest()
        {
            Instagram instagram = await LogIn();
            User user = await instagram.GetAccount("foodbeast");
            Assert.AreEqual(22718303, user.Id);
        }

        [Test]
        public async Task GetMediaTest()
        {
            Instagram instagram = await LogIn();
            User user = await instagram.GetAccount("foodbeast");
            ICollection<Media> media = await instagram.GetMediasByUserId(user.Id, 100);
            Assert.AreEqual(100, media.Count);
        }
    }
}