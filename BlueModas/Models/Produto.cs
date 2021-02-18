using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlueModas.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [Display(Name ="Código")]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name="Descrição")]
       [JsonIgnore]
        public string Descricao { get; set; }

        [JsonIgnore]
        [Display(Name="Preço (R$)")]
        public decimal? Valor { get; set; }

        [JsonIgnore]
        public int? Quantidade { get; set; }

        [JsonIgnore]
        public virtual List<Imagem> ImagemProduto { get; set; }

    }
}
