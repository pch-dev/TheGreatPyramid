using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using TheGreatPyramid.Models;
using TheGreatPyramid.Services.Implementation;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid.Test.Unit
{
    [TestClass]
    public class PyramidValueCalculatorTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PyramidValueCalculator_PyramidCreator_Null()
        {
            // arrange

            var pyramidPathFinderMock = new Mock<IPyramidPathFinder>();

            new PyramidValueCalculator(null, pyramidPathFinderMock.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PyramidValueCalculator_PyramidPathFinder_Null()
        {
            // arrange

            var pyramidCreatorMock = new Mock<IPyramidCreator>();

            new PyramidValueCalculator(pyramidCreatorMock.Object, null);
        }

        [TestMethod]
        public void PyramidValueCalculator_CalculateValue()
        {
            // arrange

            var expectedCalculatedValue = 20;

            var pyramidCreatorMock = new Mock<IPyramidCreator>();
            var pyramidPathFinderMock = new Mock<IPyramidPathFinder>();

            pyramidPathFinderMock.Setup(x => x.PyramidPath).Returns(new List<PyramidItem>
            {
                new PyramidItem
                {
                    Number = 10,
                    Index = 0
                },
                new PyramidItem
                {
                    Number = 9,
                    Index = 1
                },
                new PyramidItem
                {
                    Number = 1,
                    Index = 2
                }
            });

            var service = new PyramidValueCalculator(pyramidCreatorMock.Object, pyramidPathFinderMock.Object);

            // act

            service.CalculateValue();

            // assert

            Assert.IsTrue(service.CalculatedValue == expectedCalculatedValue);
        }
    }
}
