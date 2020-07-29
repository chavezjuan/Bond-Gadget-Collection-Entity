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
            List<GadgetModel> gadgets = context.Gadgets.ToList();

            return View("Index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == id);


            return View("Details", gadget);
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
            GadgetModel gadget = context.Gadgets.SingleOrDefault(g => g.Id == id);

            context.Entry(gadget).State = System.Data.Entity.EntityState.Deleted;

            context.SaveChanges();


            return Redirect("/Gadgets");
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
            //Exemplo de LINQ statement
            var gadgets = from g in context.Gadgets
                          where g.Name.Contains(searchPhrase)
                          select g;
        


            return View("Index", gadgets);
        }
    }
}