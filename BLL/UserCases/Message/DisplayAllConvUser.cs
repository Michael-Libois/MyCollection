using Common.BTO;
using DAL.Entities.Messages;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace BLL.UserCases.Message
{
    public partial class MessageUC
    {

        public List<ConversationBTO> DisplayAllConvUser(string userId)
        {

            Func<ConversationEF, bool> funcPred = p => (p.UserId1 == userId) || (p.UserId2 == userId);

            

            var list = iConversationRepository.Filter(funcPred).Select(x => x.ToBTO()).ToList();
            list.ForEach(x => x.UserB =  userId==x.UserId1? formatName(x.UserId2) : formatName(x.UserId1));


            //list.ForEach(x => x.UserB = formatName(x.UserId1));

            return list;



            //return iConversationRepository.Filter(funcPred).ToList();
        }


        

    }
}
