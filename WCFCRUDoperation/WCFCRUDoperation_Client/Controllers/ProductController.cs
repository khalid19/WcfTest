using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCFCRUDoperation_Client.Models;
using WCFCRUDoperation_Client.Models.ViewModel;

namespace WCFCRUDoperation_Client.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
       // GET: /Product/
        public ActionResult Index(ProductViewModel model)
        {
            ProductServiceClient pc = new ProductServiceClient();
            model.Products = pc.FindAll();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {

            ProductServiceClient pc = new ProductServiceClient();
            pc.Create(model.Product);
            return RedirectToAction("Index",model);
        }

        public ActionResult Delete(string id)
        {
           ProductServiceClient pc = new ProductServiceClient();
            pc.Delete(pc.Find(id));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            ProductServiceClient pc = new ProductServiceClient();
            ProductViewModel pvm = new ProductViewModel();
            pvm.Product = pc.Find(id);
            return View("Edit", pvm);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel pvm)
        {
            ProductServiceClient pc = new ProductServiceClient();
            pc.Edit(pvm.Product);
            return RedirectToAction("Index");
        }
	}
	}
