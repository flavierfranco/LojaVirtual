using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BlueModas.Libraries.CarrinhoCompra;
using BlueModas.Libraries.Cookie;
using BlueModas.Libraries.Login;
using BlueModas.Models;
using BlueModas.Models.ProdutoAgregador;
using BlueModas.Repositories.Contracts;
using System.Collections.Generic;

namespace BlueModas.Controllers
{
    public class CarrinhoCompraController : BaseController
    {
        private IEnderecoEntregaRepository _enderecoEntregaRepository;
        private LoginCliente _loginCliente;
        public CarrinhoCompraController(IEnderecoEntregaRepository enderecoEntregaRepository, LoginCliente loginCliente, GerenciadorCookie cookie,CarrinhoCompra carrinhoCompra, IProdutoRepository produtoRepository, IMapper mapper) : base(carrinhoCompra, produtoRepository, mapper, cookie)
        {
            _enderecoEntregaRepository = enderecoEntregaRepository;
            _loginCliente = loginCliente;
        }

        public IActionResult Index()
        {
            List<ProdutoItem> ProdutosCompleto = CarregarProdutoDB();

            return View(ProdutosCompleto);
        }

        [HttpGet]
        public IActionResult AdicionarItem(int id)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (produto == null)
            {
                return BadRequest();
            }
            var item=new ProdutoItem() { Id = id, QuantidadeCarrinhoProduto = 1 };
            _carrinhoCompra.Cadastrar(item);
            return Ok();
        }

        [HttpGet]
        public IActionResult EnderecoEntrega()
        {
            ViewBag.Produtos = CarregarProdutoDB();
            ViewBag.Cliente = _loginCliente.BuscaClienteSessao();
            return View();

        }

        public IActionResult CadastroEnderecoEntrega( EnderecoEntrega enderecoEntrega)
        {
            ViewBag.Produtos = CarregarProdutoDB();
            ViewBag.Endereco = enderecoEntrega;

            return View("Finalizar");
        }


        public IActionResult RemoverItem(int id)
        {
            _carrinhoCompra.Remover(new ProdutoItem() { Id = id });
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AlterarQuantidade(int id,int quantidade)
        {
            Produto produto = _produtoRepository.ObterProduto(id);
            if (quantidade < 1)
                return BadRequest();

            var item=new ProdutoItem() { Id = id, QuantidadeCarrinhoProduto = quantidade };
            _carrinhoCompra.Atualizar(item);
            return Ok();
        }
    }
}