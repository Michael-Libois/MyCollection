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

            var mock3 = new Mock<IRepositoryGeneric<ApplicationUserEF, string>>();
            mock3.Setup(foo => foo.GetById(It.IsAny<string>()))
                    .Returns(AppicationUsers);


            var adress = new Adress()
            {
                UserID = "mauvaisIdOrIdDeAutreUser",
                Street = "ffffffffff",
                Number = "45"
            };


            var AddressUsersReceived = new AdressEF();
            var AdressRepositoryCalled = false;
            var mock2 = new Mock<IRepositoryGeneric<AdressEF, int>>();
            mock2.Setup(foo => foo.Create(It.IsAny<AdressEF>()))
                .Callback(
                (AdressEF AdressRecu) => {
                    AdressRepositoryCalled = true;
                    AddressUsersReceived = AdressRecu;
                });

            var isSaveChangesCalled = false;
            mock2.Setup(foo => foo.SaveChanges())
                .Callback(
                () =>
                {
                    isSaveChangesCalled = true;
                }
                );

            var UserUC = new User("2", null, mock2.Object, mock3.Object);

            



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
