using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVenda.Venda.Models
{
	public class ProdutoModel
	{
		public string CodigoProduto { get; set; }
		public string NomeProduto { get; set; }
		public decimal ValorProduto { get; set; }
		public int QuantidadeProduto { get; set; }
	}
}
