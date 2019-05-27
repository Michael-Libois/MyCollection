using BLL.UserCases;
using Common.DataContracts;
using Common.MTO;
using DAL.Entities;
using DAL.UnitOfWork;
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
            var ListAReturner = new List<MovieSummary> {
                new MovieSummary { Id = 1, UserID="1", Genre = "Horror" },
                new MovieSummary { Id = 2, UserID="1", Genre = "Action" }
            };

            var mockMovieSummary = new Mock<IRepositoryGeneric<MovieSummary, MovieEF, int>>();
            mockMovieSummary.Setup(foo => foo.Filter(It.IsAny<Func<MovieSummary, bool>>()))
                .Returns(ListAReturner);

            var isSaveChangesCalled = false;
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(foo => foo.SaveChanges())
                .Callback(
                () =>
                {
                    isSaveChangesCalled = true;
                }
                );
            mockUOW.SetupGet(x => x.MovieSummaryRepository).Returns(mockMovieSummary.Object);

            var UserUC = new User("1", mockUOW.Object);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("Genre", "Horror").ToList();

            //ASSERT
            Assert.IsFalse(isSaveChangesCalled);
            Assert.AreEqual(1, ListToAssert.Count);
        }

        [TestMethod]
        public void FilterMyMovies_ShouldReturnNothinh_WhenTitleNotContainSearchTerm()
        {
            //ARRANGE
            var ListAReturner = new List<MovieSummary> {
                new MovieSummary { Id = 1, UserID="1", Title = "Fake Title1", Genre = "Horror" },
                new MovieSummary { Id = 2, UserID="1", Title = "Fake Title2", Genre = "Action" }
            };

            var mock = new Mock<IRepositoryGeneric<MovieSummary, MovieEF, int>>();
            mock.Setup(foo => foo.Filter(It.IsAny<Func<MovieSummary, bool>>()))
                .Returns(ListAReturner);

            var mockMovieSummary = new Mock<IRepositoryGeneric<MovieSummary, MovieEF, int>>();
            mockMovieSummary.Setup(foo => foo.Filter(It.IsAny<Func<MovieSummary, bool>>()))
                .Returns(ListAReturner);

            
            var mockUOW = new Mock<IUnitOfWork>();

            mockUOW.SetupGet(x => x.MovieSummaryRepository).Returns(mockMovieSummary.Object);

            var UserUC = new User("1", mockUOW.Object);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("Genre", "Advanture").ToList();

            //ASSERT
            Assert.AreEqual(0, ListToAssert.Count);
        }

        [TestMethod]
        public void FilterMyMovies_ShouldReturnAll_WhenInValidFilterTypeIsProvided()
        {
            //ARRANGE
            var ListAReturner = new List<MovieSummary> {
                new MovieSummary { Id = 1, UserID="1", Genre = "Horror" },
                new MovieSummary { Id = 2, UserID="1", Genre = "Action" }
            };

            var mockMovieSummary = new Mock<IRepositoryGeneric<MovieSummary, MovieEF, int>>();
            mockMovieSummary.Setup(foo => foo.Filter(It.IsAny<Func<MovieSummary, bool>>()))
                .Returns(ListAReturner);

            var isSaveChangesCalled = false;
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(foo => foo.SaveChanges())
                .Callback(
                () =>
                {
                    isSaveChangesCalled = true;
                }
                );
            mockUOW.SetupGet(x => x.MovieSummaryRepository).Returns(mockMovieSummary.Object);

            var UserUC = new User("1", mockUOW.Object);

            //ACT
            var ListToAssert = UserUC.FilterMyMovies("...", "Horror").ToList();

            //ASSERT
            Assert.IsFalse(isSaveChangesCalled);
            Assert.AreEqual(ListAReturner.Count, ListToAssert.Count);
        }
    }
}
