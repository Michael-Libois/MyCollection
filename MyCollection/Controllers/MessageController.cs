using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using DAL.Entities.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCollection.ViewModels;
using Newtonsoft.Json;
using DAL.UnitOfWork;
using BLL.UserCases;

namespace MyCollection.Controllers
{
    public class MessageController : MicBaseController
    {

        public MessageController(IUnitOfWork UnitOfWork) :base(UnitOfWork)
        { }

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
        public JsonResult AddMessageByReceiver(Message message, string receiverID)
        {

            messageUC.AddNewMessage(message, userID, receiverID);

            return Json(true);
        }
        [HttpPost]
        public JsonResult AddMessage(Message message)
        {
            
                var data = message.ConversationId;

                messageUC.AddNewMessage(message, message.ConversationId);



                return Json(data);
            
            
        }

        public JsonResult HasNewMessage()
            => Json(messageUC.CheckForNewMessage(userID));

        public IActionResult DisplayMessageConv(int convId)
        {

           
            //var listUsers = new List<string> { receiverId, currentUser };

            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayMessagesConv(convId);



            return View(model);
        }

        public IActionResult DisplayAllConvConv(/*string receiverId*/)
        {
           
            //var listUsers = new List<string> { receiverId, currentUser };
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayAllConvUser(userID);

            var vm = new MessConvViewModel
            {
                conversation = messageUC.DisplayAllConvUser(userID),
                message = new Message()
            };

            return View(vm);
        }

        public IActionResult testmodal(/*string receiverId*/)
        {

            



            return View("inboxtest");
        }

        [HttpGet]
        public async Task<JsonResult> GetConversation(int convId)
        {

           
            //var listUsers = new List<string> { receiverId, currentUser };
            //messageUC.AddNewMessage(message, listUsers);
            var model =  await messageUC.DisplayMessagesConvAsync(convId);

            //on marque les messages comme "lu"
            foreach (var message in model)
            {
                message.IsChecked = true;
            }
            //On sauvegarde les messages comme lu
            

            //var json = JsonConvert.SerializeObject(model);

            //return Json(json, JsonRequestBehavior.AllowGet);

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd/MM/yyy hh:mm:ss";

            return Json(JsonConvert.SerializeObject(model, jsonSettings));


            

        }
    }
}