using CepGestao.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CepGestao.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

    
    }
}