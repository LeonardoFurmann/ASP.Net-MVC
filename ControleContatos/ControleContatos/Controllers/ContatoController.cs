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

        public IActionResult EditarContato(int id)
        {
            ContatoModel contato = _contatoRepostorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepostorio.BuscarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarContato(int id)
        {
            _contatoRepostorio.Apagar(id);
            return RedirectToAction("index");
        }

        // Métodos Post

        [HttpPost]
        public IActionResult CriarContato(ContatoModel contato)
        {
            _contatoRepostorio.Adicionar(contato);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditarContato(ContatoModel contato)
        {
            _contatoRepostorio.Atualizar(contato);
            return RedirectToAction("Index");
        }

       
    }
}
