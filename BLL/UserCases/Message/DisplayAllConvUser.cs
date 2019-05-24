using Common.MTO;
using DAL.Entities.Messages;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace BLL.UserCases
{
    public partial class MessageUC
    {

        public List<Conversation> DisplayAllConvUser(string userId)
        {

            Func<Conversation, bool> funcPred = p => (p.UserId1 == userId) || (p.UserId2 == userId);



            List<Conversation> list = unitOfWork.ConversationRepository.Filter(funcPred).ToList();
            list.ForEach(x => x.UserB =  userId==x.UserId1? formatName(x.UserId2) : formatName(x.UserId1));


            //list.ForEach(x => x.UserB = formatName(x.UserId1));

            return list;



            //return iConversationRepository.Filter(funcPred).ToList();
        }


        

    }
}
