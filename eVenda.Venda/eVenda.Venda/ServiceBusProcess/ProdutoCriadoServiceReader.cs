using eVenda.Venda.DomainModel.Model;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Venda.ServiceBusProcess
{
	public class ProdutoCriadoServiceReader : BackgroundService
	{
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			string connectionString = "Endpoint=sb://bus-aceldev3-jeanpassos.servicebus.windows.net/;SharedAccessKeyName=SendListen;SharedAccessKey=vSbrNpLYY0HT/wsrSoV8eIL9Ir2t8EKLYb9wM9pGnCw=";
			string topic = "produtocriado";
			string subscription = "ProdutoCriadoService";

			var subscriptionClient = new SubscriptionClient(connectionString, topic, subscription);
			var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceiveHandler)
			{
				MaxConcurrentCalls = 1,
				AutoComplete = false
			};

			subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);
		}

		private Task ProcessMessageAsync(Message message, CancellationToken arg2)
		{

			var produto = JsonConvert.DeserializeObject<Produto>(new UTF8Encoding().GetString(message.Body));

			Console.WriteLine(produto.Codigo);


			return Task.CompletedTask;

		}

		private Task ExceptionReceiveHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
		{
			throw new Exception();
		}
	}
}
