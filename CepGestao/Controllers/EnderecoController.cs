using CepGestao.Data;
using CepGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CepGestao.Controllers
{
    public class EnderecoController : Controller
    {
        private readonly AppDbContext _context;

        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var enderecos = _context.Enderecos
                .Where(x => x.UsuarioId == usuarioId.Value)
                .ToList();

            return View(enderecos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Endereco endereco)
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            endereco.UsuarioId = usuarioId.Value;

            _context.Enderecos.Add(endereco);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

       
    }
}