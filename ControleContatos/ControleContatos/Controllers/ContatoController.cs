using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
 
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio  _contatoRepostorio;
        public ContatoController(IContatoRepositorio contatoRepostorio)
        {
            _contatoRepostorio = contatoRepostorio; 
        }


        // Métodos Get
        public IActionResult Index()
        {   
           List<ContatoModel> contatos =  _contatoRepostorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult CriarContato()
        {
            return View();
        }

        public IActionResult EditarContato()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao()
        {
            return View();
        }

        // Métodos Post

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepostorio.Adicionar(contato);
            return RedirectToAction("Index");
        }
    }
}
