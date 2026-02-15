using Microsoft.AspNetCore.Mvc;
using AplicacaoTeste.Services;

namespace AplicacaoTeste.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        // =========================
        // GET - LOGIN
        // =========================
        [HttpGet]
        public IActionResult Login()
        {
            if (TempData["Info"] != null)
            {
                ViewBag.Error = TempData["Info"];
            }

            return View();
        }

        // =========================
        // POST - LOGIN
        // =========================
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            try
            {
                var user = _userService.Authenticate(username, password);

                if (user == null)
                {
                    ViewBag.Error = "Login inválido.";
                    return View();
                }

                HttpContext.Session.SetString("User", user.Username);
                HttpContext.Session.SetString("Role", user.Role);


                return RedirectToAction("Index", "Product");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // =========================
        // LOGOUT
        // =========================
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // =========================
        // GET - REGISTER
        // =========================
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // =========================
        // POST - REGISTER
        // =========================
        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            _userService.Register(username, password);

            TempData["Info"] = "Usuário registrado. Tente fazer login.";

            return RedirectToAction("Login");
        }
    }
}

