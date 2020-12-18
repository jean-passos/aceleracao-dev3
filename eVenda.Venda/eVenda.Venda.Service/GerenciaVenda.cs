using eVenda.Venda.Repository.Implementation;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using NSDomainModel = eVenda.Venda.DomainModel.Model;

namespace eVenda.Venda.Service
{
	public class GerenciaVenda
	{
		private readonly IConfiguration _configuration;
		private readonly VendaRepository _vendaRepository = new VendaRepository();
		private readonly ProdutoRepository _produtoRepository = new ProdutoRepository();

		public GerenciaVenda(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		public void RealizaVenda(NSDomainModel.Venda venda)
		{

			var produto = _produtoRepository.ObtemProdutoPeloCodigo(venda.Produto.Codigo);
			produto.Quantidade -= venda.QuantidadeVendida;

			venda.Produto = produto;

			_vendaRepository.Add(venda);


			var serviceBusConfig = _configuration.GetSection("ServiceBus");

			var connectionString = serviceBusConfig.GetValue<string>("ConnectionString");
			var topic = serviceBusConfig.GetValue<string>("TopicProdutoVendido");

			var topicClient = new TopicClient(connectionString, topic);
			var body = new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(venda.Produto));
			var message = new Message(body);
			topicClient.SendAsync(message);
		}
	}
}
