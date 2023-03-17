using AutoMapper;
using ControleEstoque.Domain.Dtos;
using ControleEstoque.Domain.Model;

namespace ControleEstoque.Domain.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDto, Produto>();
        }
    }
}
