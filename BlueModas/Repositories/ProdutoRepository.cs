using BlueModas.Database;
using BlueModas.Libraries.Pagination;
using BlueModas.Models;
using BlueModas.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace BlueModas.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private BlueModasContext _banco;
        private IConfiguration _conf;
        public ProdutoRepository(BlueModasContext banco,IConfiguration configuration)
        {
            _conf = configuration;
            _banco = banco;
        }

        public int ContarRegistros()
        {
            return _banco.Produtos.Count();
        }

        public PaginationEngine<Produto> GeneratePagination(int? pagina)
        {
            return new PaginationEngine<Produto>(pagina, _conf.GetValue<int>("RegistroPorPagina"), ContarRegistros(), ObterTodosProdutos(pagina));
        }

        public Produto ObterProduto(int Id)
        {
            return _banco.Produtos.Include(a=>a.ImagemProduto).Where(a=>a.Id==Id).First();
        }

        public List<Produto> ObterTodosProdutos(int? pagina)
        {
            int IntPagina = pagina ?? 1;
            IQueryable<Produto> database = _banco.Produtos.Include(a => a.ImagemProduto).AsQueryable();

            return database.ToList();
        }

    }
}
