using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Venda.ServiceBusProcess
{
	public abstract class ServiceReaderBase : BackgroundService
	{
		protected string ConnectionString { get; set; }
		protected string Topic { get; set; }
		protected string Subscription { get; set; }

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			var subscriptionClient = new SubscriptionClient(ConnectionString, Topic, Subscription);
			var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceiveHandler)
			{
				MaxConcurrentCalls = 1,
				AutoComplete = false
			};

			subscriptionClient.RegisterMessageHandler(ProcessMessageAsync, messageHandlerOptions);

			return Task.CompletedTask;
		}

		protected abstract Task ProcessMessageAsync(Message message, CancellationToken cancellationToken);

		private Task ExceptionReceiveHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
		{
			throw new Exception();
		}

	}
}
