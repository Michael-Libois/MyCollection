using Common.MTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL.UserCases
{
    public partial class User
    {

        public void EditProfil(Adress adress, ApplicationUserEF user)
        {

            ApplicationUserEF user2 = unitOfWork.UserRepository.GetById(userId) ;
            user2.Email = user.Email;
            user2.AcceptShared = user.AcceptShared;
            unitOfWork.UserRepository.Edit(user2);

            unitOfWork.AdressRepository.Edit(adress);
            //unitOfWork.SaveChanges();
            
            unitOfWork.SaveChanges();
        }


    }
}
