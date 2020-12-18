using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Service;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Estoque.ServiceBusProcess
{
	public class ProdutoVendidoServiceReader : BackgroundService
	{
		private readonly ServiceBusSubscriptionSettings _subscriptionSettings;

		public ProdutoVendidoServiceReader(IOptions<ServiceBusSubscriptionSettings> options)
		{
			_subscriptionSettings = options.Value;
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var subscriptionClient = new SubscriptionClient(_subscriptionSettings.ConnectionString, _subscriptionSettings.TopicProdutoVendido, _subscriptionSettings.SubscriptionProdutoVendido);
			var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceiveHandler)
			{
				MaxConcurrentCalls = 1,
				AutoComplete = false
			};

			subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

			return Task.CompletedTask;
		}

		private Task ProcessMessageAsync(Message message, CancellationToken cancellationToken)
		{
			var produto = JsonConvert.DeserializeObject<Produto>(new UTF8Encoding().GetString(message.Body));
			GerenciaProduto gerenciaProduto = new GerenciaProduto();
			gerenciaProduto.AtualizaProdutoVendido(produto);
			return Task.CompletedTask;
		}

		private Task ExceptionReceiveHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
		{
			throw new Exception();
		}
	}
}
