using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DécouverteValidateur.Controllers
{
    public class JediController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.Jedi jedi)
        {
            if(ModelState.IsValid)
            {
                //Je pourrai aller enregistrer en base de données
            }
            return this.View(jedi);
        }


    }
}
