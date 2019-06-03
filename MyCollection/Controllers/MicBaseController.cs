using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.UserCases;
using Common.MTO;
using Common.DataContracts;
using DAL.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MyCollection.ViewModels;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;

namespace MyCollection.Controllers
{
    public class MicBaseController : Controller
    {
        private readonly IUnitOfWork unitOfWork;  //TODO mettre en prive et ne pas appeler dans les controleurs
        public Visitor visitorUC
            => new Visitor(unitOfWork);

        public User userUC
            => new User(userID, unitOfWork);

        public MessageUC messageUC
            => new MessageUC(userID, unitOfWork);

        public MicBaseController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public string userID
            => User.FindFirst(ClaimTypes.NameIdentifier).Value;


        public string GetBuildedUrl(string displayUrl)
            => (new UriBuilder(displayUrl)
            {
                Query = null,
                Fragment = null
            }).ToString();
    }
}