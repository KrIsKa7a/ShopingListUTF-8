using System.Linq;
using System.Web.Mvc;
using ShoppingList.Models;
using System.Data.Entity;

namespace ShoppingList.Controllers
{
    [ValidateInput(false)]
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new ShoppingListDbContext())
            {
                var products = db.Products.ToList()
                    .OrderBy(p => p.Priority)
                    .ThenBy(p => p.Name)
                    .ToList();

                return View(products);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ShoppingListDbContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(product);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                return View(product);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Product productModel)
        {
            using (var db = new ShoppingListDbContext())
            {
                var product = db.Products
                    .FirstOrDefault(p => p.Id == id);

                if (product == null)
                {
                    return RedirectToAction("Index");
                }

                if (ModelState.IsValid)
                {
                    product.Name = productModel.Name;
                    product.Priority = productModel.Priority;
                    productModel.Quantity = productModel.Quantity;
                    product.Status = productModel.Status;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }

                return View("Edit", productModel);
            }
        }
    }
}