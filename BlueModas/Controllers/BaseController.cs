using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BlueModas.Libraries.CarrinhoCompra;
using BlueModas.Libraries.Cookie;
using BlueModas.Models;
using BlueModas.Models.ProdutoAgregador;
using BlueModas.Repositories.Contracts;
using System.Collections.Generic;

namespace BlueModas.Controllers
{
    public class BaseController : Controller
    {
        protected CarrinhoCompra _carrinhoCompra;
        protected IProdutoRepository _produtoRepository;
        protected IMapper _mapper;
        protected GerenciadorCookie _cookie;
        public BaseController(CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper,GerenciadorCookie cookie)
        {
            _carrinhoCompra = carrinhoCompra;
            _mapper = mapper;
            _produtoRepository = produtoRepository;
            _cookie = cookie;
        }
        protected List<ProdutoItem> CarregarProdutoDB()
        {
            List<ProdutoItem> ProdutosCarrinho = _carrinhoCompra.Consultar();
            List<ProdutoItem> ProdutosCompleto = new List<ProdutoItem>();

            foreach (var item in ProdutosCarrinho)
            {
                Produto produto = _produtoRepository.ObterProduto(item.Id);
                ProdutoItem produtoItem = _mapper.Map<ProdutoItem>(produto);
                produtoItem.QuantidadeCarrinhoProduto = item.QuantidadeCarrinhoProduto;

                ProdutosCompleto.Add(produtoItem);
            }

            return ProdutosCompleto;
        }
    }
}