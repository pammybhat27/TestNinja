﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests {
    [TestFixture]
   public class VideoServiceTests {
        [Test]
        public void ReadVideoTitle_EmptyFile_returnError()
        {
            var service = new VideoService();
            service.FileReader = new FakeFileReader();
            
            var result =   service.ReadVideoTitle();

            Assert.That(result,Does.Contain("error").IgnoreCase);
        }
    }
}
