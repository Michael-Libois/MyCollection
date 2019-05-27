using BLL.UserCases;
using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;

namespace BLL.Tests
{
    [TestClass]
    public class EditMovie_
    {


        [TestMethod]
        public void EditMovie()
        {
            //var movie = new MovieEF()
            //{ 
            //    Id = 1,
            //    UserID="1",
            //    Title = "yo",
            //    Director = "me"
            //};

            var movieEdited = new MovieDetail()
            {
                Id = 1,
                Title = "yoyo",
                Director = "meme"
            };

            var isEditRepoCalled = false;
            var efReceivedByRepository = new MovieDetail();
            var MovieDetail= new Mock<IRepositoryGeneric<MovieDetail, MovieEF, int>>();
            MovieDetail.Setup(foo => foo.Edit(It.IsAny<MovieDetail>()))
                .Callback(
                (MovieDetail movie) =>
                {
                    isEditRepoCalled = true;
                    efReceivedByRepository = movieEdited;
                }
                );

            var isSaveChangesCalled = false;
            var mockUOW = new Mock<IUnitOfWork>();
            mockUOW.Setup(foo => foo.SaveChanges())
                .Callback(
                () =>
                {
                    isSaveChangesCalled = true;
                }
                );
            mockUOW.SetupGet(x => x.MovieDetailRepository).Returns(MovieDetail.Object);
            //mockUOW.SetupGet(x => x.UserRepository).Returns(mockApplicationUser.Object);




            var UserUC = new User("1", mockUOW.Object);

            UserUC.EditMovie(movieEdited);

            Assert.IsTrue(isEditRepoCalled);
            Assert.IsTrue(isSaveChangesCalled);
            Assert.AreEqual(movieEdited.Id, efReceivedByRepository.Id);
            Assert.AreEqual(movieEdited.Title, efReceivedByRepository.Title);
            Assert.AreEqual(movieEdited.Director, efReceivedByRepository.Director);
        }
    }
}
