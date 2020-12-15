using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVenda.Venda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVenda.Venda.Controllers
{
	[Route("api/venda/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemProdutos()
		{
			return new List<ProdutoModel>
			{
				new ProdutoModel    { CodigoProduto = "", NomeProduto = "", QuantidadeProduto = 0, ValorProduto = 0}
			};
		}

	}
}