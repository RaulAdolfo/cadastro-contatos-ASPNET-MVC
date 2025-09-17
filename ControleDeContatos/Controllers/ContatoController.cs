using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contato = _contatoRepositorio.BuscarTodos();

            return View(contato);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                _contatoRepositorio.Adicionar(contato);
                TempData["MensagemErro"] = $"Não foi possível cadastrar o contato, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                _contatoRepositorio.Atualizar(contato);
                TempData["MensagemErro"] = $"Não foi possível atualizar o contato, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Excluir(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Excluir(id);
                if (ModelState.IsValid)
                {
                    TempData["MensagemSucesso"] = "Contato excluído com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir o contato.";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível excluir o contato, detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
