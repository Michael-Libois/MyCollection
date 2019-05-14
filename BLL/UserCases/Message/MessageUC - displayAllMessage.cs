using Common.BTO;
using DAL.Entities.Messages;
using DAL.TypeExtentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases.Message
{
    public partial class MessageUC
    {


        public ConversationEF RetrieveConv(string id1, string id2)
        {
            Func<ConversationEF, bool> funcPred = p => (p.UserId1 == id1 && p.UserId2 == id2) || (p.UserId1 == id2 && p.UserId2 == id1);

            return iConversationRepository.Filter(funcPred).FirstOrDefault();



        }

        public List<MessageBTO> DisplayMessagesConv(int convid)
        {
            //List<MessageEF> list = new List<MessageEF>();
            //var conv = RetrieveConv(id1, id2);


            Func<MessageEF, bool> funcPred = p => (p.ConversationId == convid);

            var list = iMessageRepository.Filter(funcPred).Select(x => x.ToBTO()).ToList();
            list.ForEach(x => x.UserName = formatName(x.UserId));
            return list;
            //return iMessageRepository.Filter(funcPred).ToList().ToBTO();

        }

        private string formatName(string id)
        {
            var u = iUserRepository.GetById(id);
            return u.FirstName + " " + u.LastName + $"{u.UserName}";
        }




        //public List<MessageEF> DisplayMessagesConv (string id1, string id2)
        //{
        //    //List<MessageEF> list = new List<MessageEF>();
        //    var conv = RetrieveConv(id1, id2);

        //    Func<MessageEF, bool> funcPred = p => (p.ConversationId == conv.Id);


        //    return iMessageRepository.Filter(funcPred).ToList();

        //}
    }
}
