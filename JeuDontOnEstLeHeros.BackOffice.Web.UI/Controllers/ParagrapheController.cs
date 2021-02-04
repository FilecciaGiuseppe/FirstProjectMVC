using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace JeuDontOnEstLeHeros.BackOffice.Web.UI.Controllers
{
    public class ParagrapheController : Controller
    {
        #region Champs privés
        private DefaultContext _context = null;
        #endregion

        #region Constructeurs
        public ParagrapheController(DefaultContext context)
        {
            this._context = context;
        }
        #endregion

        #region Méthodes publiques
        public IActionResult Index()
        {
            return this.View();
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Paragraphe paragraphe)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Paragraphes.Add(paragraphe);
                this._context.SaveChanges();
            }

            return this.View();
        }

        public IActionResult Edit(int id)
        {
            Paragraphe paragraphe = null;

            paragraphe = this._context.Paragraphes.First(item => item.Id == id);

            return this.View(paragraphe);
        }

        [HttpPost]
        public IActionResult Edit(Paragraphe paragraphe)
        {
            //this._context.Paragraphes.Update(paragraphe);


            this._context.Attach<Paragraphe>(paragraphe);
            this._context.Entry(paragraphe).Property(item => item.Titre).IsModified = true;

            this._context.SaveChanges();

            return this.View();
        }
        #endregion
    }
}
