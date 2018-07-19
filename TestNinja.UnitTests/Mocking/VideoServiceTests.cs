using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests {
    [TestFixture]
    public class VideoServiceTests {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;

        [SetUp]
        public void Setup() {
            //We have an external dependency for filereader
            //We create a mock object 
            //we use the mock onject for the video service
            _fileReader = new Mock<IFileReader>();
            _videoService = new VideoService(_fileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_returnError() {

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
