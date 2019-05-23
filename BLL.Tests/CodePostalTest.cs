////using BLL.UserCases;
////using Common.DataContracts;
////using DAL.Entities;
////using Microsoft.VisualStudio.TestTools.UnitTesting;
////using Moq;
////using System;
////using System.Collections.Generic;
////using System.Linq;
////using System.Text;

////namespace BLL.Tests
////{
////    [TestClass]
////    public class CodePostalTest
////    {
////        [TestMethod]
////        public void FindMovieByPostalCode_ShouldFilterOutUserMovies()
////        {
////            //ARRANGE
////            var AppicationUsers = new ApplicationUserEF
////            {
////                Id = "2",
////                FirstName = "Jean",
////                LastName = "Lou"

////            };

////            var ListAdress = new List<AdressEF>
////            {
////                //new AdressEF { Id = 1, UserID="1", PostalCode = "1050"},
////                new AdressEF { Id = 2, UserID="2", PostalCode = "1050"}
////            };

////            var ListMovieUser1 = new List<MovieEF> {
////                new MovieEF { Id = 1, UserID="1" },
////                new MovieEF { Id = 2, UserID="1" },
////            };
////            var ListMovieUser2 = new List<MovieEF> {
////                new MovieEF { Id = 3, UserID="2"}
////            };

////            var twiceCalled = false;
////            var mock = new Mock<IRepositoryGeneric<MovieEF, int>>();
////            mock.Setup(foo => foo.Filter(It.IsAny<Func<MovieEF, bool>>()))
////                .Returns(()=> {
////                    var returnvalue =  twiceCalled ? ListMovieUser1:ListMovieUser2;
////                    twiceCalled = true;
////                    return returnvalue;
////                });

////            var mock2 = new Mock<IRepositoryGeneric<AdressEF, int>>();
////            mock2.Setup(foo => foo.Filter(It.IsAny<Func<AdressEF, bool>>()))
////                .Returns(ListAdress);

////        var mock3 = new Mock<IRepositoryGeneric<ApplicationUserEF, string>>();
////        mock3.Setup(foo => foo.GetById(It.IsAny<string>()))
////                .Returns(AppicationUsers);

////        var UserUC = new User("1", mock.Object, mock2.Object, mock3.Object);

////            //ACT
////            var ListToAssert = UserUC.ShowUsersSamePostalMovies().ToList();

////            //ASSERT
////            Assert.AreEqual(1, ListToAssert.Count);
////        }
////    }
////}
