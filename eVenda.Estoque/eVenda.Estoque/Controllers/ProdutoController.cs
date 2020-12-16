using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVenda.Estoque.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace eVenda.Estoque.Controllers
{
	[Route("api/estoque/[controller]")]
	[ApiController]
	public class ProdutoController : ControllerBase
	{

		private readonly IConfiguration _configuration;

		public ProdutoController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpPost]
		public ActionResult CriaProduto([FromBody]ProdutoModel produtoModel)
		{

			var serviceBusConfiguration = _configuration.GetSection("ServiceBus");
			var connectionString = serviceBusConfiguration.GetValue<string>("ConnectionString");
			var topicName = serviceBusConfiguration.GetValue<string>("TopicProdutoCriado");

			var topicClient = new TopicClient(connectionString, topicName);

			UTF8Encoding encoding = new UTF8Encoding(false);
			var messageBody = encoding.GetBytes(JsonConvert.SerializeObject(produtoModel));
			var sendMessage = new Message(messageBody);
			topicClient.SendAsync(sendMessage);

			return Ok();
		}

		[HttpPut]
		public ActionResult AtualizaProduto([FromBody]ProdutoModel produtoModel)
		{
			var serviceBusConfiguration = _configuration.GetSection("ServiceBus");
			var connectionString = serviceBusConfiguration.GetValue<string>("ConnectionString");
			var topicName = serviceBusConfiguration.GetValue<string>("TopicProdutoAtualizado");

			var topicClient = new TopicClient(connectionString, topicName);

			UTF8Encoding encoding = new UTF8Encoding(false);
			var messageBody = encoding.GetBytes(JsonConvert.SerializeObject(produtoModel));
			var sendMessage = new Message(messageBody);
			topicClient.SendAsync(sendMessage);

			return Ok();
		}

		[HttpGet]
		public IEnumerable<ProdutoModel> ObtemListaDeProdutos()
		{
			List<ProdutoModel> listaDeProdutos = new List<ProdutoModel>
			{
				new ProdutoModel{ CodigoProduto = "abc123", NomeProduto = "Produto Tal", QuantidadeProduto = 10, ValorProduto = 100m },
				new ProdutoModel{ CodigoProduto = "cba321", NomeProduto = "Outro Produto", QuantidadeProduto = 15, ValorProduto = 27m }
			};

			return listaDeProdutos;
		}
	}
}