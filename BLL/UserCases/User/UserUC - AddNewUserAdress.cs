using Common.BTO;

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
        public void AddNewUserAdress(AdressBTO adressBTO)
        {
            try
            {
                AdressEF adress = new AdressEF();

                adress.Id = adressBTO.Id;
                adress.UserID = userId; //Ref:Au cas on as besoin du BTO: adressBTO.UserID;
                adress.Street = adressBTO.Street;
                adress.Number = adressBTO.Number;
                adress.PostalCode = adressBTO.PostalCode;
                adress.City = adressBTO.City;

                // TODO: Add insert logic here
                iAdressRepository.Create(adress);
                iAdressRepository.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Adress for new User not added to db.");
            }
        }
    }
}
