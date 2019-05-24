using Common.MTO;

using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class User : Visitor
    {
        public void AddNewUserAdress(Adress Adress)
        {
            try
            {
                var adress = new Adress();

                adress.Id = Adress.Id;
                adress.UserID = userId; //Ref:Au cas on a besoin du BTO: Adress.UserID;
                adress.Street = Adress.Street;
                adress.Number = Adress.Number;
                adress.PostalCode = Adress.PostalCode;
                adress.City = Adress.City;

                // TODO: Add insert logic here
                unitOfWork.AdressRepository.Create(adress);
                unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Adress for new User not added to db.");
            }
        }
    }
}
