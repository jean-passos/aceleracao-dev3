using eVenda.Venda.DomainModel.Model;
using eVenda.Venda.Service;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Venda.ServiceBusProcess
{
	public class ProdutoCriadoServiceReader : ServiceReaderBase
	{
		public ProdutoCriadoServiceReader(IOptions<ServiceBusSubscriptionSettings> options)
		{
			ConnectionString = options.Value.ConnectionString;
			Topic = options.Value.TopicProdutoCriado;
			Subscription = options.Value.SubscriptionProdutoCriado;
		}

		protected override Task ProcessMessageAsync(Message message, CancellationToken cancellationToken)
		{
			var produto = JsonConvert.DeserializeObject<Produto>(new UTF8Encoding().GetString(message.Body));
			GerenciaProduto gerenciaProduto = new GerenciaProduto();
			gerenciaProduto.IncluiProduto(produto);
			return Task.CompletedTask;
		}
	}
}
