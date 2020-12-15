using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVenda.Estoque.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVenda.Estoque.Controllers
{
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
		[HttpPost]
		public ActionResult CriaProduto([FromBody]ProdutoModel produtoModel)
		{
			return Ok();
		}


		[HttpPut]
		public ActionResult AtualizaProduto([FromBody]ProdutoModel produtoModel)
		{
			return Ok();
		}


		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemListaDeProdutos()
		{
			List<ProdutoModel> listaDeProdutos = new List<ProdutoModel>
			{
				new ProdutoModel{ CodigoProduto = "abc123", NomeProduto = "Produto Tal", QuantidadeProduto = 10, ValorProduto = 100m },
				new ProdutoModel{ CodigoProduto = "cba321", NomeProduto = "Outro Produto", QuantidadeProduto = 15, ValorProduto = 27m }
			};

			return listaDeProdutos;
		}
	}
}