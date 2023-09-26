using ControleProdutosQ3.Data;
using ControleProdutosQ3.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ControleProdutosQ3.Repository
{
    public class ProdutoRepository :
        IProdutoRepository
    {
        private readonly BancoContext _bancoContext;

        public ProdutoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;

        }

       public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
           
           await _bancoContext.Produto.AddAsync(produto);
           await _bancoContext.SaveChangesAsync();

            return  produto;
           
        }

        public async Task< List<ProdutoModel>> BuscarTodos()
        {
           return await _bancoContext.Produto.ToListAsync();
        }
    }
}
