using ControleProdutosQ3.Models;

namespace ControleProdutosQ3.Repository
{
    public interface IProdutoRepository
    {
       Task<List<ProdutoModel>>BuscarTodos();
       Task<ProdutoModel> Adicionar(ProdutoModel produto);

        Task<ProdutoModel> Remover();
       
    }
}
