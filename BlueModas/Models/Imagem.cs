using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueModas.Models
{
    public class Imagem
    {
        [Key]
        public int Id { get; set; }
        public string Caminho { get; set; }

        public int? ProdutoId { get; set; }
        [ForeignKey("ProdutoId")]
        public virtual Produto ProdutoImagem { get; set; }
    }
}
