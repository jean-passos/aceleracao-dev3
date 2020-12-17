using AutoMapper;
using eVenda.Venda.Models;
using eVenda.Venda.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eVenda.Venda.Controllers
{
	[Route("api/venda/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		private readonly IMapper _mapper;

		public ProdutoController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemProdutos()
		{
			GerenciaProduto gerenciaProduto = new GerenciaProduto();
			return _mapper.Map<IEnumerable<ProdutoModel>>(gerenciaProduto.ObtemProdutosQuantidadeMaiorQueZero());
		}
	}
}