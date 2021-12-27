using mvc_class_d1.Models;
using mvc_class_d1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.Services;

namespace mvc_class_d1.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            ProductService _service = new ProductService();
            List<ProductModel> datalist = _service.GetAll();
            return View(datalist);
        }

        [HttpPost]
        public ActionResult Index(string product_id)
        {
            ProductService service = new ProductService();
            List<ProductModel> datalist = service.GetSearch(product_id);
            return View(datalist);
        }

       public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCreate data)
        {
            ProductService service = new ProductService();
            service.InsetProduct(data);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(string product_id)
        {
            ProductService service=new ProductService();
            ProductEdit data = service.GetOne(product_id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(ProductEdit Model)
        {
            ProductService service = new ProductService();
            service.UpdateProduct(Model);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string product_id)
        {
            ProductService service = new ProductService();
            service.DeleteProduct(product_id);
            return RedirectToAction("Index");
        }
    }
}