using ControleProdutosQ3.Models;
using ControleProdutosQ3.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace ControleProdutosQ3.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<ProdutoModel> produto = await _produtoRepository.BuscarTodos();
           
            ViewBag.Produtos = "Outros Produtos";

            return await Task.FromResult(View(produto));
        }

        public async Task<IActionResult> Criar() 
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(ProdutoModel produto)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(produto);

            bool isValid = Validator.TryValidateObject(produto, context,results, true);
            if (!isValid)
            {
                foreach (ValidationResult validationResult in results)
                {
                    return await Task.FromResult(View(produto));
                }
            }

            produto.DataDeRegistro = DateTime.Now;
            produto.Ativo = true;
            await _produtoRepository.Adicionar(produto);
            return await Task.FromResult(RedirectToAction("Index"));
        }
    }
}
