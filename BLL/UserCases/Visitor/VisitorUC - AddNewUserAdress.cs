using Common.MTO;

using DAL.Entities;
using DAL.ExternalData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.UserCases
{
    public partial class Visitor
    {
        public void AddNewUserAdress(string NewRegisteredUserID, Adress Adress)
        {
            try
            {
                Adress.UserID = NewRegisteredUserID; //Ref:Au cas on a besoin du BTO: Adress.UserID;

                // TODO: Add insert logic here
                unitOfWork.AdressRepository.Create(Adress);
                unitOfWork.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Adress for new User not added to db.");
            }
        }
    }
}
