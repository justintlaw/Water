using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Water.Models;

namespace Water.Components
{
    public class NavigationMenu : ViewComponent
    {
        private ICharityRepository repository;

        public NavigationMenu (ICharityRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["category"];

            return View(repository.Projects
                .Select(item => item.Type)
                .Distinct()
                .OrderBy(item => item));
        }
    }
}
