using AutoMapper;
using ControleEstoque.Domain.Dtos;
using ControleEstoque.Domain.Model;
using ControleEstoque.Domain.Profiles;
using ControleEstoque.Service.Interfaces;
using ControleEstoque.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace ControleEstoque.Test
{
    public class ProdutoServiceTest
    {
        private readonly IMapper mapper;

        public ProdutoServiceTest()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProdutoProfile());
            });
            mapper = config.CreateMapper();
        }

        [Theory]
        [InlineData("2022-03-04", "2023-03-16")]
        public void AdicionaProduto_SeDataValidada(DateTime dataDeFabricacao, DateTime dataDeValidade)
        {
            var produtoDto = new CreateProdutoDto();
            var produto = new Produto();
            produtoDto.DataDeFabricacao = dataDeFabricacao;
            produtoDto.DataDeValidade = dataDeValidade;
            var repositoryMock = new Mock<IProdutoRepository>();

            var produtoService = new ProdutoService(repositoryMock.Object, mapper);

            repositoryMock.Setup(produtoRepository => produtoRepository.AddProduto(It.IsAny<Produto>())).Returns(produto);

            var result = produtoService.AdicionaProduto(produtoDto);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void RetornaProdutoPorId()
        {
            var produto = new Produto();
            var repositoryMock = new Mock<IProdutoRepository>();
            var produtoService = new ProdutoService(repositoryMock.Object, mapper);

            repositoryMock.Setup(produtoRepository => produtoRepository.BuscaProdutoPorId(It.IsAny<int>())).Returns(produto);
            
            var result = produtoService.RecuperaProdutoPorId(produto.Id);

            Assert.NotNull(result); 
        }

        [Fact]
        public void RetornaProdutoPorFiltro()
        {
            bool ativo = true;
            int skip = 0;
            int take = 10;
            var repositoryMock = new Mock<IProdutoRepository>();

            var listProdutos = new List<Produto>();
            var produtoService = new ProdutoService(repositoryMock.Object, mapper);
            
            repositoryMock.Setup(produtoRepository => produtoRepository.BuscaProdutos(It.IsAny<bool>(), It.IsAny<int>(), It.IsAny<int>())).Returns(listProdutos);

            var result = produtoService.RecuperaProdutos(ativo, skip, take);
            
            Assert.NotNull(result);
        }

        [Fact]
        public void DeletaProduto_ProdutoNaoExiste()
        {
            var produtoDto = new Produto();
            var repositoryMock = new Mock<IProdutoRepository>();

            repositoryMock.Setup(produtoRepository => produtoRepository.BuscaProdutoPorId(It.IsAny<int>())).Returns(produtoDto);
            repositoryMock.Setup(produtoRepository => produtoRepository.ExcluirProduto(It.IsAny<int>(), It.IsAny<Produto>())).Returns(false);

            var produtoService = new ProdutoService(repositoryMock.Object, mapper);

            var result = produtoService.DeletaProduto(produtoDto.Id);

            Assert.False(result);
        }
        [Fact]
        public void DeletaProduto_ProdutoExiste()
        {
            var produtoDto = new Produto();
            var repositoryMock = new Mock<IProdutoRepository>();

            repositoryMock.Setup(produtoRepository => produtoRepository.BuscaProdutoPorId(It.IsAny<int>())).Returns(produtoDto);
            repositoryMock.Setup(produtoRepository => produtoRepository.ExcluirProduto(It.IsAny<int>(), It.IsAny<Produto>())).Returns(true);

            var produtoService = new ProdutoService(repositoryMock.Object, mapper);
           
            var result = produtoService.DeletaProduto(produtoDto.Id);

            Assert.True(result);
        }
    }
}
