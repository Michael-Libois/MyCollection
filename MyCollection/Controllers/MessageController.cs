using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases.Message;
using Common.BTO;
using Common.DataContracts;
using DAL.Entities;
using DAL.Entities.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MyCollection.Controllers
{
    public class MessageController : Controller
    {

        
        private readonly IRepositoryGeneric<ConversationEF, int> iConversationRepository = null;
        private readonly IRepositoryGeneric<MessageEF, int> iMessageRepository = null;
        private readonly IRepositoryGeneric<ApplicationUserEF, string> iUserRepository = null;

        public MessageController(IRepositoryGeneric<ApplicationUserEF, string> UserRepository,
            IRepositoryGeneric<ConversationEF, int> ConversationRepository, IRepositoryGeneric<MessageEF, int> MessageRepository)
        {
            
            iConversationRepository = ConversationRepository;
            iMessageRepository = MessageRepository;
            iUserRepository = UserRepository;

        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddMessage(string receiverId)
        {
            ViewBag.receiverId = receiverId;

            return View();
        }

        [HttpPost]//receiverId
        public IActionResult AddMessage(MessageBTO message, string receiverId)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            //messageUC.AddNewMessage(message, listUsers);
            messageUC.AddNewMessage(message, currentUser,receiverId);



            return View();
        }

        




    }
}