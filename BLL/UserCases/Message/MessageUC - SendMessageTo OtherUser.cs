using Common.BTO;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases.Message
{
    public partial class MessageUC
    {
        public ConversationEF CheckIfConvExist(string id1, string id2)
        {
            Func<ConversationEF, bool> funcPred = p => (p.UserId1 == id1 && p.UserId2 == id2) || (p.UserId1 == id2 && p.UserId2 == id1);

            return iConversationRepository.Filter(funcPred).FirstOrDefault();



        }

        public List<string> GetMessageUsers(int ConversationID)
        {
            Func<ConversationEF, bool> funcPred = p => p.Id == ConversationID;

            var conv =  iConversationRepository.Filter(funcPred).FirstOrDefault();

            return new List<string> { conv.UserId1, conv.UserId2 };
        }

        public void AddUsersToConversations(/*int ConversationID,*/ List<string> Destinataires)
        {
            //ConversationEF conversation = iConversationRepository.Filter(x => x.Id == ConversationID).FirstOrDefault();
            ConversationEF conversation = new ConversationEF();
            iConversationRepository.Create(conversation);
            iConversationRepository.SaveChanges();
            //foreach (var item in Destinataires)
            //{
            //    var cuser = new ConvUserEF
            //    {

            //        ConversationId = conversation.Id,
            //        ConversationEF = conversation,
            //        UserId = item,
            //        ApplicationUserEF = iUserRepository.Filter(x => x.Id == item).FirstOrDefault()

            //    };


            //}

            iConversationRepository.SaveChanges();

        }

        public void AddNewMessage(MessageBTO messageBTO, int ConversationID)
        {

            
            
                var users = GetMessageUsers(ConversationID);
                AddNewMessage(messageBTO, users[0], users[1]);
            

            
        }

        public void AddNewMessage(MessageBTO messageBTO, string User1Id, string User2Id)
        {
            //verifier si conversation exist...
            ConversationEF conversation = CheckIfConvExist(User1Id, User2Id);
            if (conversation == null)// .Id == 0)
            {
                conversation = new ConversationEF()
                {
                    User1 = iUserRepository.GetById(User1Id),
                    User2 = iUserRepository.GetById(User2Id)
                };
                iConversationRepository.Create(conversation);
                iConversationRepository.SaveChanges();
            }


            var message = new MessageEF
            {

                UserId = userId,
                Conversation = conversation,
                Content = messageBTO.Content,
                Datetime = DateTime.Now,
                IsChecked = false

            };
            iMessageRepository.Create(message);
            iMessageRepository.SaveChanges();

            //conversation.Messages.Add(message);

            iConversationRepository.SaveChanges();
        }

        //public int Id { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }
        //public ApplicationUserEF User { get; set; }

        //[ForeignKey("Conversation")]
        //public int ConversationId { get; set; }
        //public ConversationEF Conversation { get; set; }

        //public string Content { get; set; }
        //public DateTime Datetime { get; set; }
        //public bool IsChecked { get; set; }



    }
}
