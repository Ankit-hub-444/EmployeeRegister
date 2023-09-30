using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace EmployeeRegister.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent:ViewComponent
    {
        public SearchBarViewComponent()
        {
        }

        public IViewComponentResult Invoke(SPager SearchPager)
        {
            return View("Default", SearchPager);
        }
    }
}
