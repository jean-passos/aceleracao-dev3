using eVenda.Venda.Repository.Implementation;
using eVenda.Venda.Service.Helpers;
using Microsoft.Extensions.Configuration;
using NSDomainModel = eVenda.Venda.DomainModel.Model;

namespace eVenda.Venda.Service
{
	public class GerenciaVenda
	{
		private readonly VendaRepository _vendaRepository = new VendaRepository();
		private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

		public void RealizaVenda(NSDomainModel.Venda venda)
		{
			var produto = _produtoRepository.ObtemProdutoPeloCodigo(venda.Produto.Codigo);
			produto.Quantidade -= venda.QuantidadeVendida;

			venda.Produto = produto;
			_vendaRepository.Add(venda);
			new ProcessaServiceBus<NSDomainModel.Produto>().EnviaMensagem(venda.Produto, "TopicProdutoVendido");
		}
	}
}
