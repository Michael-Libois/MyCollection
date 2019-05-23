using Common.MTO;
using DAL.Entities.Messages;
using DAL.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class MessageUC
    {


        public Conversation RetrieveConv(string id1, string id2)
        {
            Func<Conversation, bool> funcPred = p => (p.UserId1 == id1 && p.UserId2 == id2) || (p.UserId1 == id2 && p.UserId2 == id1);

            return unitOfWork.iConversationRepository.Filter(funcPred).FirstOrDefault();



        }


        public List<Message> DisplayMessagesConv(int convid)
        {
            Func<Message, bool> funcPred = p => (p.ConversationId == convid);

            var list = unitOfWork.iMessageRepository.Filter(funcPred).ToList();

            list.ForEach(x => x.UserName = formatName(x.UserId));

            return list;

        }

        private string formatName(string id)
        {
            var u = unitOfWork.iUserRepository.GetById(id);
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
