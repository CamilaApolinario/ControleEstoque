using ControleEstoque.Domain.Model;
using ControleEstoque.Infra.Data;
using ControleEstoque.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque.Service.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ControleEstoqueContext _context;

        public ProdutoRepository(ControleEstoqueContext context)
        {
            _context = context;
        }
        public Produto AddProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return produto;
        }
        public List<Produto> BuscaProdutos(bool ativo, int skip, int take)
        {
            return _context.Produtos
                .Where(x => x.Situacao == ativo).Skip(skip).Take(take).ToList();
        }

        public Produto BuscaProdutoPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        }

        public Produto AtualizaProduto(Produto produto)
        {
            _context.Update(produto);
            _context.SaveChanges();
            return produto;
        }

        public bool ExcluirProduto(int id, Produto produto)
        {
            produto.Situacao = false;
            _context.Update(produto);
            _context.SaveChanges();
            return true;
        }
    }
}
