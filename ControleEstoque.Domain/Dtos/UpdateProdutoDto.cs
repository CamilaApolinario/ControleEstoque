using System;

namespace ControleEstoque.Domain.Dtos
{
    public class UpdateProdutoDto
    {
        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataDeFabricacao { get; set; }
        public DateTime DataDeValidade { get; set; }
        public string CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
    }
}
