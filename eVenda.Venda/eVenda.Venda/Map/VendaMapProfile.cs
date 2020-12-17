using AutoMapper;
using NSDomainModel = eVenda.Venda.DomainModel.Model;
using NSModel = eVenda.Venda.Models;

namespace eVenda.Venda.Map
{
	public class VendaMapProfile : Profile
	{
		public VendaMapProfile()
		{
			CreateMap<NSModel.ProdutoModel, NSDomainModel.Produto>().ReverseMap();
			CreateMap<NSModel.VendaModel, NSDomainModel.Venda>().ReverseMap();
		}
	}
}
