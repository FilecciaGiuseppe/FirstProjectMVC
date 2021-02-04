using JeuDontOnEstLeHeros.Core.Data;
using JeuDontOnEstLeHeros.Core.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JeuDontOnEstLeHeros.BackOffice.Web.UI.Controllers
{
    public class PropositionController : Controller
    {
        #region Champs privés
        private DefaultContext _context = null;
        #endregion

        #region Constructeurs
        public PropositionController(DefaultContext context)
        {
            this._context = context;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            this.setQuestionList();
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(Reponse reponse)
        {
            if (this.ModelState.IsValid)
            {
                this._context.Reponses.Add(reponse);
                this._context.SaveChanges();
            }
            this.setQuestionList();
            return this.View(reponse);
        }

        private void setQuestionList()
        {
            this.ViewBag.QuestionList = this._context.Questions.ToList();
        }

    }
}
