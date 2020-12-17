using System;
using System.Collections.Generic;
using System.Text;
using eVenda.Estoque.DomainModel.Model;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace eVenda.Estoque.Service
{
	public class GerenciaProduto
	{

		private readonly IConfiguration _configuration;

		public GerenciaProduto(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void IncluiProduto(Produto produto)
		{
			var serviceBusConfiguration = _configuration.GetSection("ServiceBus");


			
			var connectionString = serviceBusConfiguration.GetValue<string>("ConnectionString");
			var topicName = serviceBusConfiguration.GetValue<string>("TopicProdutoCriado");

			var topicClient = new TopicClient(connectionString, topicName);

			UTF8Encoding encoding = new UTF8Encoding(false);
			var messageBody = encoding.GetBytes(JsonConvert.SerializeObject(produto));
			var sendMessage = new Message(messageBody);
			topicClient.SendAsync(sendMessage);
		}

		public void AlteraProduto(Produto produto)
		{
			var serviceBusConfiguration = _configuration.GetSection("ServiceBus");
			var connectionString = serviceBusConfiguration.GetValue<string>("ConnectionString");
			var topicName = serviceBusConfiguration.GetValue<string>("TopicProdutoAtualizado");

			var topicClient = new TopicClient(connectionString, topicName);

			UTF8Encoding encoding = new UTF8Encoding(false);
			var messageBody = encoding.GetBytes(JsonConvert.SerializeObject(produto));
			var sendMessage = new Message(messageBody);
			topicClient.SendAsync(sendMessage);
		}

		public IEnumerable<Produto> ObtemTodosProdutos()
		{
			List<Produto> listaDeProdutos = new List<Produto>
			{
				new Produto{ Id = 1, Codigo = "abc123", Nome = "Produto Tal", Quantidade = 10, Valor = 100m },
				new Produto{ Id = 2, Codigo= "cba321", Nome = "Outro Produto", Quantidade = 15, Valor = 27m }
			};

			return listaDeProdutos;

		}


	}
}
