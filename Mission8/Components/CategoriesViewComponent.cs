using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission8.Models;

namespace Mission8.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public CategoriesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedType = RouteData?.Values["bookCategory"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
