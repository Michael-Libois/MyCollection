﻿using System;
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
    public class MessageController : Controller
    {

        

        private readonly IUnitOfWork unitOfWork;

        public MessageController(IUnitOfWork UnitOfWork)
        {

            unitOfWork = UnitOfWork;
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
        public JsonResult AddMessageByReceiver(Message message, string receiverID)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messageUC = new MessageUC(currentUser, unitOfWork);
            messageUC.AddNewMessage(message, currentUser, receiverID);

            return Json(true);
        }
        [HttpPost]
        public JsonResult AddMessage(Message message)
        {
            var data = message.ConversationId;
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var messageUC = new MessageUC(currentUser, unitOfWork);
            //messageUC.AddNewMessage(message, listUsers);
            messageUC.AddNewMessage(message, message.ConversationId);



            return Json(data);
        }


        public IActionResult DisplayMessageConv(int convId)
        {

            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, unitOfWork);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayMessagesConv(convId);



            return View(model);
        }

        public IActionResult DisplayAllConvConv(/*string receiverId*/)
        {
            var currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //var listUsers = new List<string> { receiverId, currentUser };
            var messageUC = new MessageUC(currentUser, unitOfWork);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayAllConvUser(currentUser);

            var vm = new MessConvViewModel
            {
                conversation = messageUC.DisplayAllConvUser(currentUser),
                message = new Message()
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
            var messageUC = new MessageUC(currentUser, unitOfWork);
            //messageUC.AddNewMessage(message, listUsers);
            var model = messageUC.DisplayMessagesConv(convId);

            //var json = JsonConvert.SerializeObject(model);

            //return Json(json, JsonRequestBehavior.AllowGet);

            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.DateFormatString = "dd/MM/yyy hh:mm:ss";

            return Json(JsonConvert.SerializeObject(model, jsonSettings));


            

        }
    }
}