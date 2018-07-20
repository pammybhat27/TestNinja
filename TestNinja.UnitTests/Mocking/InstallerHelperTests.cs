
using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownLoader;

        private InstallerHelper _installerHelper;
        //Create a mock of theIfile

        [SetUp]
        public void Setup()
        {
            _fileDownLoader = new Mock<IFileDownloader>();
            _installerHelper = new InstallerHelper(_fileDownLoader.Object);
        }

        [Test]
        public void DownloadInstaller_DownloadFails_ReturnsFalse()
        {
            _fileDownLoader.Setup(fd => fd.DownLoadFile(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);

        }

        [Test]
        public void DownloadInstaller_DownloadCompletes_ReturnsTrue()
        {
            var result = _installerHelper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }
    }
}