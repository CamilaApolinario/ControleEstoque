using AutoMapper;
using ControleEstoque.Domain.Dtos;
using ControleEstoque.Domain.Model;
using ControleEstoque.Service.Interfaces;
using FluentResults;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Produto AdicionaProduto(CreateProdutoDto produtoDto)
        {
            var validacaoData = ValidaDataFabricacao(produtoDto.DataDeFabricacao, produtoDto.DataDeValidade);
            if (validacaoData.IsSuccess)
            {
                Produto produto = _mapper.Map<Produto>(produtoDto);
                return _repository.AddProduto(produto);
            }
            return null;

        }

        public List<Produto> RecuperaProdutos(bool ativo, int skip, int take)
        {
            var produtos = _repository.BuscaProdutos(ativo, skip, take);
            if (produtos != null) return produtos;
            return null;
        }

        public Produto RecuperaProdutoPorId(int id)
        {
            var produto = _repository.BuscaProdutoPorId(id);
            if (produto != null)  return produto;
            return null;
        }
        public Produto AtualizaProduto(int id, UpdateProdutoDto produtoDto)
        {
            var validacaoData = ValidaDataFabricacao(produtoDto.DataDeFabricacao, produtoDto.DataDeValidade);
            if (validacaoData.IsSuccess)
            {
                var produtoAntigo = _repository.BuscaProdutoPorId(id);

                if (produtoAntigo != null)
                {
                    var produto = _mapper.Map(produtoDto, produtoAntigo);
                    var produtoAtualizado = _repository.AtualizaProduto(produto);
                    return _mapper.Map<Produto>(produtoAtualizado);
                }
                return null;
            }
            return null;
        }

        public bool DeletaProduto(int id)
        {
            var produto = _repository.BuscaProdutoPorId(id);
            if(produto != null) return _repository.ExcluirProduto(id, produto);
            return false;
        }

        private Result ValidaDataFabricacao(DateTime dataFabricacao, DateTime dataValidade)
        {
            if (dataFabricacao >= dataValidade)
            {
                return Result.Fail(errorMessage: "Data de fabricação não pode ser maior que a data de validade");
            }
            return Result.Ok();
        }
    }
}
