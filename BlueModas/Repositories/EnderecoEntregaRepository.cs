using BlueModas.Models;
using BlueModas.Repositories.Contracts;

namespace BlueModas.Repositories
{
    public class EnderecoEntregaRepository:IEnderecoEntregaRepository
    {
        public EnderecoEntregaRepository()
        {
        }

        public EnderecoEntrega EnderecoVazio()
        {
            EnderecoEntrega endereco = new EnderecoEntrega();
            return endereco;
        }
       
    }
}
