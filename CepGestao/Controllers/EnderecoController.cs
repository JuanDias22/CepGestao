using CepGestao.Data;
using CepGestao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var endereco = _context.Enderecos.FirstOrDefault(x => x.Id == id);

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost]
        public IActionResult Edit(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var endereco = _context.Enderecos
                .FirstOrDefault(x => x.Id == id);

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var endereco = _context.Enderecos
                .FirstOrDefault(x => x.Id == id);

            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ExportarCsv()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var enderecos = _context.Enderecos
                .Where(x => x.UsuarioId == usuarioId.Value)
                .ToList();

            var csv = new StringBuilder();

            csv.AppendLine("CEP,Logradouro,Complemento,Bairro,Cidade,UF,Número");

            foreach (var endereco in enderecos)
            {
                csv.AppendLine(
                    $"{endereco.Cep}," +
                    $"{endereco.Logradouro}," +
                    $"{endereco.Complemento}," +
                    $"{endereco.Bairro}," +
                    $"{endereco.Cidade}," +
                    $"{endereco.Uf}," +
                    $"{endereco.Numero}"
                );
            }

            return File(
                Encoding.UTF8.GetBytes(csv.ToString()),
                "text/csv",
                "enderecos.csv"
            );
        }   

    }
}