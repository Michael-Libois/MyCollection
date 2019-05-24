using Common.MTO;
using DAL.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.UserCases
{
    public partial class MessageUC
    {
        public Conversation CheckIfConvExist(string id1, string id2)
        {
            Func<Conversation, bool> funcPred = p => (p.UserId1 == id1 && p.UserId2 == id2) || (p.UserId1 == id2 && p.UserId2 == id1);

            return unitOfWork.ConversationRepository.Filter(funcPred).FirstOrDefault();



        }

        public List<string> GetMessageUsers(int ConversationID)
        {
            Func<Conversation, bool> funcPred = p => p.Id == ConversationID;

            var conv = unitOfWork.ConversationRepository.Filter(funcPred).FirstOrDefault();

            return new List<string> { conv.UserId1, conv.UserId2 };
        }

        public void AddUsersToConversations(/*int ConversationID,*/ List<string> Destinataires)
        {
            //ConversationEF conversation = iConversationRepository.Filter(x => x.Id == ConversationID).FirstOrDefault();
            Conversation conversation = new Conversation();
            unitOfWork.ConversationRepository.Create(conversation);
            unitOfWork.SaveChanges();
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

            unitOfWork.SaveChanges();

        }

        public void AddNewMessage(Message Message, int ConversationID)
        {

            
            
                var users = GetMessageUsers(ConversationID);
                AddNewMessage(Message, users[0], users[1]);
            

            
        }

        public void AddNewMessage(Message Message, string User1Id, string User2Id)
        {
            //verifier si conversation exist...
            Conversation conversation = CheckIfConvExist(User1Id, User2Id);
            if (conversation == null)// .Id == 0)
            {
                conversation = new Conversation()
                {
                    UserId1 = unitOfWork.UserRepository.GetById(User1Id).Id,
                    UserId2 = unitOfWork.UserRepository.GetById(User2Id).Id
                };
                unitOfWork.ConversationRepository.Create(conversation);
                unitOfWork.SaveChanges();
            }


            var message = new Message
            {
                //not SURE CHEEEECCCKKKKK
                UserId = userId,
                ConversationId = conversation.Id,
                Content = Message.Content,
                Datetime = DateTime.Now,
                IsChecked = false

            };
            unitOfWork.MessageRepository.Create(message);
            unitOfWork.SaveChanges();

            //conversation.Messages.Add(message);

            unitOfWork.SaveChanges();
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
