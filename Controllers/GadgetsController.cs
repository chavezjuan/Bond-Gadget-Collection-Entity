using JamesBondGadgetsEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JamesBondGadgetsEntity.Controllers
{
    public class GadgetsController : Controller
    {
        // Configurando o acesso ao DbContext
        private ApplicationDbContext context;

        public GadgetsController()
        {
            context = new ApplicationDbContext();
        }
        //Quando e encerrada a aplicacao ele retira o contexto
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Gadgets
        public ActionResult Index()
        {
            

            return View("Index");
        }

        public ActionResult Details(int id)
        {
            

            return View("Details");
        }

        //Retorna um formulário de criação
        public ActionResult Create()
        {
            return View("GadgetForm");
        }

        public ActionResult Edit(int id)
        {
           
            return View("GadgetForm");
        }

        public ActionResult Delete(int id)
        {
           

            return View("Index");
        }

        //Cria um item no banco
        public ActionResult ProcessCreate(GadgetModel gadgetModel)
        {
            //Salvando no banco de dados
            

            return View("Details", gadgetModel);
        }

        public ActionResult SearchForm()
        {
            return View("SearchForm");
        }

        public ActionResult SearchForName(string searchPhrase)
        {
        


            return View("Index");
        }
    }
}