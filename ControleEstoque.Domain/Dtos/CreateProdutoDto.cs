using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Dtos
{
    public class CreateProdutoDto
    {
        [Required(ErrorMessage ="O campo Descrição do Produto é obrigatório")]
        public string Descricao { get; set; }
        public bool Situacao { get; set; } = true;
        public DateTime DataDeFabricacao { get; set; }
        public DateTime DataDeValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjForncecedor { get; set; }
    }
}
