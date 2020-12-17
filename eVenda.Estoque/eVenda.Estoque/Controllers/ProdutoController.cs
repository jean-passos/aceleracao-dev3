using AutoMapper;
using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Model;
using eVenda.Estoque.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace eVenda.Estoque.Controllers
{
	[Route("api/estoque/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{

		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;


		public ProdutoController(IConfiguration configuration, IMapper mapper)
		{
			_configuration = configuration;
			_mapper = mapper;
		}

		[HttpPost]
		public ActionResult CriaProduto([FromBody]ProdutoModel produtoModel)
		{
			GerenciaProduto gerenciaProduto = new GerenciaProduto(_configuration);
			Produto produto = _mapper.Map<Produto>(produtoModel);
			gerenciaProduto.IncluiProduto(produto);

			return Ok();
		}

		[HttpPut]
		public ActionResult AtualizaProduto([FromBody]ProdutoModel produtoModel)
		{
			GerenciaProduto gerenciaProduto = new GerenciaProduto(_configuration);
			Produto produto = _mapper.Map<Produto>(produtoModel);
			gerenciaProduto.AlteraProduto(produto);

			return Ok();
		}

		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemListaDeProdutos()
		{
			GerenciaProduto gerenciaProduto = new GerenciaProduto(_configuration);
			var entities = gerenciaProduto.ObtemTodosProdutos();
			var listaRetorno = _mapper.Map<IEnumerable<ProdutoModel>>(entities);
			return listaRetorno;
		}
	}
}