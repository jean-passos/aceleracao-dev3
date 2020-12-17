using AutoMapper;
using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Model;

namespace eVenda.Estoque.Map
{
	public class EstoqueMapProfile : Profile
	{
		public EstoqueMapProfile()
		{
			CreateMap<ProdutoModel, Produto>().ReverseMap();
			
		}
	}
}
