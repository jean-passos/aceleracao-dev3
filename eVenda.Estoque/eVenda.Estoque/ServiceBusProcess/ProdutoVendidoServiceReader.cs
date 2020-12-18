using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Service;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Estoque.ServiceBusProcess
{
	public class ProdutoVendidoServiceReader : BackgroundService
	{
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			string connectionString = "Endpoint=sb://bus-aceldev3-jeanpassos.servicebus.windows.net/;SharedAccessKeyName=SendListen;SharedAccessKey=vSbrNpLYY0HT/wsrSoV8eIL9Ir2t8EKLYb9wM9pGnCw=";
			string topic = "produtovendido";
			string subscription = "ProdutoVendidoService";

			var subscriptionClient = new SubscriptionClient(connectionString, topic, subscription);
			var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceiveHandler)
			{
				MaxConcurrentCalls = 1,
				AutoComplete = false
			};

			subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

			return Task.CompletedTask;
		}

		private Task ProcessMessageAsync(Message message, CancellationToken arg2)
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
