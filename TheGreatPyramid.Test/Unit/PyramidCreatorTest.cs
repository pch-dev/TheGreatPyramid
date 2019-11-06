using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using TheGreatPyramid.Repositories;
using TheGreatPyramid.Services.Implementation;

namespace TheGreatPyramid.Test.Unit
{
    [TestClass]
    public class PyramidCreatorTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PyramidCreator_FileRepository_Null()
        {
            // arrange

            new PyramidCreator(null);
        }

        [TestMethod]
        public void PyramidCreator_CreatePyramid()
        {
            // arrange

            var fileRepositoryMock = new Mock<IFileRepository>();

            var lines = new[]
            {
                "1",
                "8 9",
                "1 5 9",
                "4 5 2 3"
            };

            fileRepositoryMock.Setup(x => x.Read()).Returns(lines);

            var service = new PyramidCreator(fileRepositoryMock.Object);

            // act

            var pyramid = service.CreatePyramid();

            // assert

            Assert.IsTrue(pyramid.Levels.Count == lines.Length);
            Assert.IsTrue(pyramid.Levels.Last().Items.Count == lines.ToList().Last().Split(' ').Length);
        }
    }
}
