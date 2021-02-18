using BlueModas.Libraries.Pagination;
using BlueModas.Models;
using System.Collections.Generic;

namespace BlueModas.Repositories.Contracts
{
    public interface IProdutoRepository
    {
        Produto ObterProduto(int Id);
        List<Produto> ObterTodosProdutos(int? pagina);
        PaginationEngine<Produto> GeneratePagination(int? pagina);
        int ContarRegistros();
    }
}
