using System.Collections.Generic;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests {

    [TestFixture]
    public class VideoServiceTests {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _videoRepository;
        

        [SetUp]
        public void Setup() {
            //We have an external dependency for filereader
            //We create a mock object 
            //we use the mock onject for the video service
            _fileReader = new Mock<IFileReader>();
            _videoRepository =  new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object,_videoRepository.Object);

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_returnError() {

            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }


        
        //[Test]
        //public void GetUnprocessedVideosAsCsv_AllvideosAreProcessed_ReturnsEmptyString() {



        //    _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

        //    var result = _videoService.ReadVideoTitle();

        //    Assert.That(result, Does.Contain("error").IgnoreCase);
        //}

        [Test]
        public void GetUnprocessedVideosAsCsv_AllvideosAreProcessed_ReturnsEmptyString() {

          _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_SomeVideosAreUnprocessed_ReturnsUnprocesedVideosAsString() {

            _videoRepository.Setup(vr => vr.GetUnprocessedVideos()).Returns(new List<Video>
            {
                new Video {Id =1},
                new Video {Id = 2},
                new Video {Id = 3},

            });

            var result = _videoService.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
