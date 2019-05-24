//using BLL.UserCases;
//using Common.DataContracts;
//using Common.MTO;
//using DAL.Entities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace BLL.Tests
//{
//    [TestClass]
//    public class CodePostalTest
//    {
//        [TestMethod]
//        public void FindMovieByPostalCode_ShouldFilterOutUserMovies()
//        {
//            //ARRANGE
//            var AppicationUsers = new ApplicationUserEF
//            {
//                Id = "2",
//                FirstName = "Jean",
//                LastName = "Lou"

//            };

//            var ListAdress = new List<AdressEF>
//            {
//                //new AdressEF { Id = 1, UserID="1", PostalCode = "1050"},
//                new AdressEF { Id = 2, UserID="2", PostalCode = "1050"}
//            };

//            var ListMovieUser1 = new List<MovieEF> {
//                new MovieEF { Id = 1, UserID="1" },
//                new MovieEF { Id = 2, UserID="1" },
//            };
//            var ListMovieUser2 = new List<MovieEF> {
//                new MovieEF { Id = 3, UserID="2"}
//            };

//            var twiceCalled = false;
//            var mockMovie = new Mock<IRepositoryGeneric<MovieDetail, MovieEF, int>>();
//            mockMovie.Setup(foo => foo.Filter(It.IsAny<Func<MovieDetail, bool>>()))
//                .Returns(() =>
//                {
//                    var returnvalue = twiceCalled ? ListMovieUser1 : ListMovieUser2;
//                    twiceCalled = true;
//                    return returnvalue;
//                });

//            var mockAdress = new Mock<IRepositoryGeneric<Adress, AdressEF, int>>();
//            mockAdress.Setup(foo => foo.Filter(It.IsAny<Func<Adress, bool>>()))
//                .Returns(ListAdress);

//            var mockApplicationUser = new Mock<IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>>();
//            mockApplicationUser.Setup(foo => foo.GetById(It.IsAny<string>()))
//                    .Returns(AppicationUsers);





//            var UserUC = new User("1", mock.Object, mock2.Object, mock3.Object);

//            //ACT
//            var ListToAssert = UserUC.ShowUsersSamePostalMovies().ToList();

//            //ASSERT
//            Assert.AreEqual(1, ListToAssert.Count);
//        }
//    }
//}
