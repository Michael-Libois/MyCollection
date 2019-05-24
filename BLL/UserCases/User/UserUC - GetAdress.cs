using Common.MTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BLL.UserCases
{
    public partial class User
    {

        public Adress GetAdress()
        {
            Func<Adress, bool> funcFindUserAdress = p => p.UserID == userId;
            var adress = unitOfWork.AdressRepository.Filter(funcFindUserAdress);
            var a = adress.FirstOrDefault();
            return a;




        }
    }
}
