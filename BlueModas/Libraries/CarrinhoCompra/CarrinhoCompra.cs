using BlueModas.Libraries.Cookie;
using BlueModas.Models;
using BlueModas.Models.ProdutoAgregador;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueModas.Libraries.CarrinhoCompra
{
    public class CarrinhoCompra
    {
        private string Key = "Carrinho.Compras";
        private GerenciadorCookie _cookie;
        public CarrinhoCompra(GerenciadorCookie cookie)
        {
            _cookie = cookie;
        }

        public void Cadastrar(ProdutoItem item)
        {
            var Lista = new List<ProdutoItem>();
            if (_cookie.Existe(Key))
            {
                Lista = Consultar();
                var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

                if (ItemLocalizado == null)
                {
                    Lista.Add(item);
                }
                else
                {
                    ItemLocalizado.QuantidadeCarrinhoProduto += 1;
                }
            }
            else
            {
                Lista = new List<ProdutoItem>();
                Lista.Add(item);
            }
            Salvar(Lista);
        }
        public void Remover(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                Lista.Remove(ItemLocalizado);
                Salvar(Lista);
            }
        }
        public void Salvar(List<ProdutoItem> Lista)
        {
            string Valor=JsonConvert.SerializeObject(Lista);
            _cookie.Cadastrar(Key, Valor);
        }
        public void Atualizar(ProdutoItem item)
        {
            var Lista = Consultar();
            var ItemLocalizado = Lista.SingleOrDefault(a => a.Id == item.Id);

            if (ItemLocalizado != null)
            {
                ItemLocalizado.QuantidadeCarrinhoProduto =item.QuantidadeCarrinhoProduto;
                Salvar(Lista);
            }
        }
        public List<ProdutoItem> Consultar()
        {
            if (_cookie.Existe(Key))
            {
                //O COOKIE ARMAZENARA UMA LISTA SERIALIZADA
                string valor = _cookie.Consultar(Key);
                return JsonConvert.DeserializeObject<List<ProdutoItem>>(valor);
            }
            else
            {
                return new List<ProdutoItem>();
            }
        }
    }
}
