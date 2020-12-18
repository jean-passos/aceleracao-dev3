using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eVenda.Venda.ServiceBusProcess
{
	public class ProdutoAlteradoServiceReader : BackgroundService
	{
		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			Console.WriteLine("asdf");

			return Task.CompletedTask;
		}
	}
}
