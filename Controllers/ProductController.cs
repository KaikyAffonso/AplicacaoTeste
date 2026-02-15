using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AplicacaoTeste.Services;
using AplicacaoTeste.Models;

namespace AplicacaoTeste.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // =========================
        // BLOQUEIO GLOBAL DE LOGIN
        // =========================
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(user))
            {
                context.Result = RedirectToAction("Login", "Auth");
            }

            base.OnActionExecuting(context);
        }

        // =========================
        // LISTAR PRODUTOS
        // =========================
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        // =========================
        // GET - CRIAR
        // =========================
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // POST - CRIAR
        // =========================
        [HttpPost]
        
        public IActionResult Create(Product product)
        {
            var username = HttpContext.Session.GetString("User");

            _productService.Create(
                product.Name,
                product.Price,
                product.Quantity,
                username
            );

            return RedirectToAction("Index");
        }


        // =========================
        // GET - EDITAR
        // =========================
        public IActionResult Edit(int id)
        {
            var product = _productService.GetAll()
                                         .Find(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // =========================
        // POST - EDITAR
        // =========================
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var username = HttpContext.Session.GetString("User");

            _productService.Update(
                product.Id,
                product.Name,
                product.Price,
                product.Quantity,
                username
            );

            return RedirectToAction("Index");
        }


        // =========================
        // DESATIVAR
        // =========================
        public IActionResult Deactivate(int id)
        {
            _productService.Deactivate(id);
            return RedirectToAction("Index");
        }
    }
}
