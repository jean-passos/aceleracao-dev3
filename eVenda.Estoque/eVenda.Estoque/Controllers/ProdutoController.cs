using AutoMapper;
using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Model;
using eVenda.Estoque.Service;
using eVenda.Estoque.Service.ServiceException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace eVenda.Estoque.Controllers
{
	[Route("api/estoque/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{

		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		private readonly GerenciaProduto _gerenciaProduto;

		public ProdutoController(IConfiguration configuration, IMapper mapper)
		{
			_configuration = configuration;
			_mapper = mapper;
			_gerenciaProduto = new GerenciaProduto();
		}

		[HttpPost]
		public IActionResult CriaProduto([FromBody]ProdutoModel produtoModel)
		{
			try
			{
				Produto produto = _mapper.Map<Produto>(produtoModel);
				_gerenciaProduto.IncluiProduto(produto);
				return Accepted();
			}
			catch (QuantidadeAbaixoZeroException)
			{
				var requestError = new RequestErrorModel(nameof(produtoModel.Quantidade), "Quantidade não pode ser menor do que zero");
				return BadRequest(requestError);
			}
			catch (ValorAbaixoZeroException)
			{
				var requestError = new RequestErrorModel(nameof(produtoModel.Quantidade), "Valor não pode ser menor do que zero");
				return BadRequest(requestError);
			}
			catch (ProdutoExistenteException)
			{
				string propriedades = $"{nameof(produtoModel.Codigo)}/{nameof(produtoModel.Nome)}";
				var requestError = new RequestErrorModel(propriedades, "Produto já existente");
				return BadRequest(requestError);
			}
			catch (Exception)
			{
				throw;
			}
		}

		[HttpPut]
		public IActionResult AtualizaProduto([FromBody]ProdutoModel produtoModel)
		{
			try
			{
				Produto produto = _mapper.Map<Produto>(produtoModel);
				_gerenciaProduto.AlteraProduto(produto);
				return Accepted();
			}
			catch (QuantidadeAbaixoZeroException)
			{
				var requestError = new RequestErrorModel(nameof(produtoModel.Quantidade), "Quantidade não pode ser menor do que zero");
				return BadRequest(requestError);
			}
			catch (ValorAbaixoZeroException)
			{
				var requestError = new RequestErrorModel(nameof(produtoModel.Quantidade), "Valor não pode ser menor do que zero");
				return BadRequest(requestError);
			}
			catch (ProdutoExistenteException)
			{
				string propriedades = $"{nameof(produtoModel.Codigo)}/{nameof(produtoModel.Nome)}";
				var requestError = new RequestErrorModel(propriedades, "Produto já existente");
				return BadRequest(requestError);
			}
			catch (Exception)
			{

				throw;
			}
		}

		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemListaDeProdutos()
		{
			var entities = _gerenciaProduto.ObtemTodosProdutos();
			var listaRetorno = _mapper.Map<IEnumerable<ProdutoModel>>(entities);
			return listaRetorno;
		}
	}
}