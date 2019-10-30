using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ImageManagement.Tests
{
    [TestClass]
    public class TestWithAdditionalAttributes
    {
        private ImageMetadataReader _reader;

        [TestInitialize]
        public void Initialize()
        {
            _reader = new ImageMetadataReader(TestFiles.GetImage());
        }

        [TestCategory("Property Handling")]
        [TestMethod]
        public void ReportsCameraMaker()
        {
            Assert.AreEqual(_reader.CameraManufacturer, "Fabrikam");
        }

        [ExpectedException(typeof(ArgumentException), AllowDerivedTypes = true)]
        [TestMethod]
        public void ThrowsWhenNameMalformed()
        {
            new ImageMetadataReader("");
        }
    }
}