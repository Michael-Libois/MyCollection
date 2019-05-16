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
using MyCollection.ViewModels;
using Newtonsoft.Json;

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
        public IActionResult AddMessageByReceiver(MessageBTO message, string receiverID)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            messageUC.AddNewMessage(message, currentUser, receiverID);

            return View("AddMessage");
        }
        [HttpPost]
        public JsonResult AddMessage(MessageBTO message)
        {
            var data = message.ConversationId;
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            //messageUC.AddNewMessage(message, listUsers);
            messageUC.AddNewMessage(message, message.ConversationId);



            return Json(data);
        }


        public IActionResult DisplayMessageConv(int convId)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayMessagesConv(convId);



            return View(model);
        }

        public IActionResult DisplayAllConvConv(/*string receiverId*/)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayAllConvUser(currentUser);

            var vm = new MessConvViewModel
            {
                conversation = messageUC.DisplayAllConvUser(currentUser),
                message = new MessageBTO()
            };

            return View(vm);
        }

        public IActionResult testmodal(/*string receiverId*/)
        {

            



            return View("inboxtest");
        }

        [HttpGet]
        public JsonResult GetConversation(int convId)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, iUserRepository, iConversationRepository, iMessageRepository);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayMessagesConv(convId);

            //var json = JsonConvert.SerializeObject(model);

            //return Json(json, JsonRequestBehavior.AllowGet);

            return Json(JsonConvert.SerializeObject(model));


            

        }
    }
}