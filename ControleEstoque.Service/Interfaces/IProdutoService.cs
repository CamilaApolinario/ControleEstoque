using ControleEstoque.Domain.Dtos;
using ControleEstoque.Domain.Model;
using System.Collections.Generic;

namespace ControleEstoque.Service.Interfaces
{
    public interface IProdutoService
    {
        Produto AdicionaProduto(CreateProdutoDto produtoDto);
        Produto AtualizaProduto(int id, UpdateProdutoDto produtoDto);
        bool DeletaProduto(int id);
        Produto RecuperaProdutoPorId(int id);
        List<Produto> RecuperaProdutos(bool ativo, int skip, int take);
    }
}