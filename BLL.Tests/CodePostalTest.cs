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
using System.Text;

namespace BLL.Tests
{
    [TestClass]
    public class CodePostalTest
    {
        [TestMethod]
        public void FindMovieByPostalCode_ShouldFilterOutUserMovies()
        {
            #region ARRANGE REPOSITORI
            var AppicationUsers = new ApplicationUserEF
            {
                Id = "2",
                FirstName = "Jean",
                LastName = "Lou"

            };

            var ListAdress = new List<Adress>
            {
                new Adress { Id = 2, UserID="2", PostalCode = "1050"},
                new Adress { Id = 1, UserID="3", PostalCode = "1060"}
            };

            var ListMovieUser1 = new List<MovieSummary> {
                new MovieSummary { Id = 1, UserID="2" },
                new MovieSummary { Id = 2, UserID="2" },
            };
            var ListMovieUser2 = new List<MovieSummary> {
                new MovieSummary { Id = 3, UserID="3"}
            };

            var twiceCalled = false;
            var mockMovie = new Mock<IRepositoryGeneric<MovieSummary, MovieEF, int>>();
            mockMovie.Setup(foo => foo.Filter(It.IsAny<Func<MovieSummary, bool>>()))
                .Returns(() =>
                {
                    var returnvalue = twiceCalled ? ListMovieUser1 : new List<MovieSummary>();//istMovieUser2;
                    twiceCalled = true;
                    return returnvalue;
                });

            var mockAdress = new Mock<IRepositoryGeneric<Adress, AdressEF, int>>();
            mockAdress.Setup(foo => foo.Filter(It.IsAny<Func<Adress, bool>>()))
                .Returns(ListAdress);

            var mockApplicationUser = new Mock<IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>>();
            mockApplicationUser.Setup(foo => foo.GetById(It.IsAny<string>()))
                    .Returns(AppicationUsers);
            #endregion

            var mockUOW = new Mock<IUnitOfWork>();
            //var isSaveChangesCalled = false;
            //mockUOW.Setup(foo => foo.SaveChanges())
            //    .Callback(
            //    () =>
            //    {
            //        isSaveChangesCalled = true;
            //    }
            //    );
            mockUOW.SetupGet(x => x.MovieSummaryRepository).Returns(mockMovie.Object);
            mockUOW.SetupGet(x => x.AdressRepository).Returns(mockAdress.Object);
            mockUOW.SetupGet(x => x.UserRepository).Returns(mockApplicationUser.Object);



            var UserUC = new User("2", mockUOW.Object);

            //ACT
            var ListToAssert = UserUC.ShowUsersSamePostalMovies().ToList();

            //ASSERT
            Assert.AreEqual(2, ListToAssert.Count);
        }
    }
}
