using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Model
{
    public class Produto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo Descrição é obrigatório")]
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataDeFabricacao { get; set; }
        public DateTime DataDeValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjForncecedor { get; set; }
    }
}
