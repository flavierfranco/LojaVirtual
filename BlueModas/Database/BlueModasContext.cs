using Microsoft.EntityFrameworkCore;
using BlueModas.Models;

namespace BlueModas.Database
{
    public class BlueModasContext:DbContext
    {
        public BlueModasContext(DbContextOptions <BlueModasContext> Options):base(Options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Imagem> ImagensProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
    }
}
