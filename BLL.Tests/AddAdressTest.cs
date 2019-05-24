using BLL.UserCases;
using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using DAL.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;

namespace BLL.Tests
{
    [TestClass]
    public class AddAdressTest
    {
        [TestMethod]
        public void AddAdressToUser()
        {

            var AppicationUsers = new ApplicationUserEF
            {
                Id = "2",
                FirstName = "Jean",
                LastName = "Lou"

            };

            var mockApplicationUser = new Mock<IRepositoryGeneric<ApplicationUserEF, ApplicationUserEF, string>>();
            mockApplicationUser.Setup(foo => foo.GetById(It.IsAny<string>()))
                    .Returns(AppicationUsers);


            var adress = new Adress()
            {
                UserID = "mauvaisIdOrIdDeAutreUser",
                Street = "ffffffffff",
                Number = "45"
            };


            var AddressUsersReceived = new Adress();
            var AdressRepositoryCalled = false;
            var mockAdress = new Mock<IRepositoryGeneric<Adress, AdressEF, int>>();
            mockAdress.Setup(foo => foo.Create(It.IsAny<Adress>()))
                .Callback(
                (Adress AdressRecu) =>
                {
                    AdressRepositoryCalled = true;
                    AddressUsersReceived = AdressRecu;
                });

            var mockUOW = new Mock<IUnitOfWork>();
            var isSaveChangesCalled = false;
            mockUOW.Setup(foo => foo.SaveChanges())
                .Callback(
                () =>
                {
                    isSaveChangesCalled = true;
                }
                );
            mockUOW.SetupGet(x => x.AdressRepository).Returns(mockAdress.Object);
            mockUOW.SetupGet(x => x.UserRepository).Returns(mockApplicationUser.Object);

            var UserUC = new User("2", mockUOW.Object);

            //ACT
            UserUC.AddNewUserAdress(adress);

            Assert.IsTrue(AdressRepositoryCalled);
            Assert.IsTrue(isSaveChangesCalled);
            Assert.AreEqual(AppicationUsers.Id, AddressUsersReceived.UserID);
            Assert.AreEqual(adress.Street, AddressUsersReceived.Street);
            Assert.AreEqual(adress.Number, AddressUsersReceived.Number);




        }



    }
}
