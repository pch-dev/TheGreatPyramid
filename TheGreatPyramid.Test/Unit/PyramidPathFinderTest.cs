using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TheGreatPyramid.Models;
using TheGreatPyramid.Services.Implementation;

namespace TheGreatPyramid.Test.Unit
{
    [TestClass]
    public class PyramidPathFinderTest
    {
        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
        }

        [TestMethod]
        public void PyramidPathFinder_FindPyramidPath()
        {
            // arrange

            var service = new PyramidPathFinder();

            #region Pyramid initialize
            service.Pyramid = new Pyramid
            {
                Levels = new List<PyramidLevel>
                {
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 1,
                                Index = 0
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 8,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 9,
                                Index = 1
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 1,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 5,
                                Index = 1
                            },
                            new PyramidItem
                            {
                                Number = 9,
                                Index = 2
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 4,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 5,
                                Index = 1
                            },
                            new PyramidItem
                            {
                                Number = 2,
                                Index = 2
                            },
                            new PyramidItem
                            {
                                Number = 3,
                                Index = 3
                            }
                        }
                    }
                }
            };
            #endregion

            // act

            service.FindPyramidPath();

            // assert

            Assert.IsTrue(service.PyramidPath.Count == service.Pyramid.Levels.Count);
            Assert.IsTrue(service.PyramidPath.First().Number == service.Pyramid.Levels.First().Items.First().Number);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PyramidPathFinder_FindPyramidPath_Incompletable()
        {
            // arrange

            var service = new PyramidPathFinder();

            #region Pyramid initialize
            service.Pyramid = new Pyramid
            {
                Levels = new List<PyramidLevel>
                {
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 1,
                                Index = 0
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 8,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 9,
                                Index = 1
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 2,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 4,
                                Index = 1
                            },
                            new PyramidItem
                            {
                                Number = 9,
                                Index = 2
                            }
                        }
                    },
                    new PyramidLevel
                    {
                        Items = new List<PyramidItem>
                        {
                            new PyramidItem
                            {
                                Number = 4,
                                Index = 0
                            },
                            new PyramidItem
                            {
                                Number = 5,
                                Index = 1
                            },
                            new PyramidItem
                            {
                                Number = 2,
                                Index = 2
                            },
                            new PyramidItem
                            {
                                Number = 3,
                                Index = 3
                            }
                        }
                    }
                }
            };
            #endregion

            // act

            service.FindPyramidPath();
        }
    }
}
