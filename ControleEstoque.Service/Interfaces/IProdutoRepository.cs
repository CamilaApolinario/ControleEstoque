using ControleEstoque.Domain.Model;
using System.Collections.Generic;

namespace ControleEstoque.Service.Interfaces
{
    public interface IProdutoRepository
    {
        Produto AddProduto(Produto produto);
        List<Produto> BuscaProdutos(bool ativo, int skip, int take);
        Produto BuscaProdutoPorId(int id);
        Produto AtualizaProduto(Produto produto);
        bool ExcluirProduto(int id, Produto produto);
    }
}