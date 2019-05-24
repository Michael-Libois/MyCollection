//using BLL.UserCases;
//using Common.MTO;
//using Common.DataContracts;
//using DAL.Entities;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BLL.Tests
//{
//    [TestClass]
//    public class EditMovieTest
//    {


//        [TestMethod]
//        public void EditMovie()
//        {
//            //var movie = new MovieEF()
//            //{ 
//            //    Id = 1,
//            //    UserID="1",
//            //    Title = "yo",
//            //    Director = "me"
//            //};

//            var movieEdited = new MovieDetail()
//            {
//                Id = 1,
//                Title = "yoyo",
//                Director = "meme"
//            };

//            var isEditRepoCalled = false;
//            var efReceivedByRepository = new MovieEF();
//            var mock = new Mock<IRepositoryGeneric<MovieDetail, MovieEF, int>>();
//            mock.Setup(foo => foo.Edit(It.IsAny<MovieDetail>()))
//                .Callback(
//                (MovieEF movieEF) =>
//                {
//                    isEditRepoCalled = true;
//                    efReceivedByRepository = movieEF;
//                }
//                );








//            var isSaveChangesCalled = false;
//            mock.Setup(foo => foo.SaveChanges())
//                .Callback(
//                () =>
//                {
//                    isSaveChangesCalled = true;
//                }
//                );





//            var UserUC = new User("1", mock.Object, null, null);

//            UserUC.EditMovie(movieEdited);

//            Assert.IsTrue(isEditRepoCalled);
//            Assert.IsTrue(isSaveChangesCalled);
//            Assert.AreEqual(movieEdited.Id, efReceivedByRepository.Id);
//            Assert.AreEqual(movieEdited.Title, efReceivedByRepository.Title);
//            Assert.AreEqual(movieEdited.Director, efReceivedByRepository.Director);
//        }
//    }
//}
