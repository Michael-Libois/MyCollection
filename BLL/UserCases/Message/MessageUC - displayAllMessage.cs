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

            return unitOfWork.ConversationRepository.Filter(funcPred).FirstOrDefault();



        }


        public List<Message> DisplayMessagesConv(int convid)
        {
            Func<Message, bool> funcPred = p => (p.ConversationId == convid);

            var list = unitOfWork.MessageRepository.Filter(funcPred).ToList();

            foreach (var message in list)
            {
                if (message.UserId != userId)
                {
                    message.IsChecked = true;
                    EditMessage(message);

                }

                
            }
            unitOfWork.SaveChanges();
            list.ForEach(x => x.UserName = formatName(x.UserId));

            return list;

        }

        private string formatName(string id)
        {
            var u = unitOfWork.UserRepository.GetById(id);
            return u.FirstName + " " + u.LastName + $"{u.UserName}";
        }




        public void EditMessage(Message message)
        {
            
            unitOfWork.MessageRepository.Edit(message);
            unitOfWork.SaveChanges();
        }
    }
}
