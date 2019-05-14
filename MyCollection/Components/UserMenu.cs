using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCollection.Components
{
    public class UserMenu : ViewComponent
    {


        public IViewComponentResult Invoke()
        {
            var menuItems = new List<UserMenuItem> { new UserMenuItem()
                {
                    DisplayValue = "INBOX",
                    ActionValue = "DisplayAllConvConv"

                } };
                //new UserMenuItem()
                //{
                //    DisplayValue = "Role management",
                //    ActionValue = "RoleManagement"
                //}};

            return View(menuItems);
        }
    }

    public class UserMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }



}

