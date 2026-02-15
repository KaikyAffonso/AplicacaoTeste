using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AplicacaoTeste.Services;
using AplicacaoTeste.Models;

namespace AplicacaoTeste.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController(UserService userService)
        {
            _userService = userService;
        }

        // Bloqueia se não estiver logado
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var user = HttpContext.Session.GetString("User");
            var role = HttpContext.Session.GetString("Role");

            if (string.IsNullOrEmpty(user))
            {
                context.Result = RedirectToAction("Login", "Auth");
                return;
            }

            if (role != "Admin")
            {
                context.Result = RedirectToAction("Index", "Product");
                return;
            }

            base.OnActionExecuting(context);
        }


        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult Approve(int id)
        {
            _userService.Approve(id);
            return RedirectToAction("Index");
        }
    }
}
