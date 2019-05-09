using BLL.UserCases;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Tests
{
    [TestClass]
    public class UserUC_FilterMyMovies
    {
        [TestMethod]
        public void FilterMyMovies_ShouldFindGenre_WhenValidArgsIsProvided()
        {
            //ARRANGE
            var ListAReturner = new List<MovieEF> {
                new MovieEF { Id = 1, UserID="1", Genre = "Horror" },
                new MovieEF { Id = 2, UserID="1", Genre = "Action" }
            };

            var mock = new Mock<IRepositoryGeneric<MovieEF>>();
            mock.Setup(foo => foo.Filter(It.IsAny<Func<MovieEF, bool>>()))
                .Returns(ListAReturner);

            var UserUC = new User("1", mock.Object, null);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("Genre", "Horror").ToList();

            //ASSERT
            Assert.AreEqual(1, ListToAssert.Count);
        }

        [TestMethod]
        public void FilterMyMovies_ShouldReturnNothinh_WhenTitleNotContainSearchTerm()
        {
            //ARRANGE
            var ListAReturner = new List<MovieEF> {
                new MovieEF { Id = 1, UserID="1", Title = "Fake Title1", Genre = "Horror" },
                new MovieEF { Id = 2, UserID="1", Title = "Fake Title2", Genre = "Action" }
            };

            var mock = new Mock<IRepositoryGeneric<MovieEF>>();
            mock.Setup(foo => foo.Filter(It.IsAny<Func<MovieEF, bool>>()))
                .Returns(ListAReturner);

            var UserUC = new User("1", mock.Object, null);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("Genre", "Advanture").ToList();

            //ASSERT
            Assert.AreEqual(0, ListToAssert.Count);
        }

        [TestMethod]
        public void FilterMyMovies_ShouldReturnAll_WhenInValidFilterTypeIsProvided()
        {
            //ARRANGE
            var ListAReturner = new List<MovieEF> {
                new MovieEF { Id = 1, UserID="1", Genre = "Horror" },
                new MovieEF { Id = 2, UserID="1", Genre = "Action" }
            };

            var mock = new Mock<IRepositoryGeneric<MovieEF>>();
            mock.Setup(foo => foo.Filter(It.IsAny<Func<MovieEF, bool>>()))
                .Returns(ListAReturner);

            var UserUC = new User("1", mock.Object, null);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("...", "Horror").ToList();

            //ASSERT
            Assert.AreEqual(ListAReturner.Count, ListToAssert.Count);
        }
    }
}
