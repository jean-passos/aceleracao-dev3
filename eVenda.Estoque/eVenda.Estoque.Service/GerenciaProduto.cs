using eVenda.Estoque.DomainModel.Model;
using eVenda.Estoque.Repository.Implementation;
using eVenda.Estoque.Service.ServiceException;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eVenda.Estoque.Service
{
	public class GerenciaProduto
	{

		private readonly IConfiguration _configuration;

		public GerenciaProduto()
		{

		}

		public GerenciaProduto(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void IncluiProduto(Produto produto)
		{

			if (produto.Quantidade < 0)
				throw new QuantidadeAbaixoZeroException();

			if (produto.Valor < 0)
				throw new ValorAbaixoZeroException();


			//*************************************************************************
			ProdutoRepository produtoRepository = new ProdutoRepository();

			var produtos = produtoRepository.ObtemProdutosPorCodigoNome(produto.Codigo, produto.Nome);
			if(produtos != null && produtos.Count() > 0)
				throw new ProdutoExistenteException();

			produtoRepository.Add(produto);

			//*************************************************************************
			produto.Id = 0;
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
			if (produto.Quantidade < 0)
				throw new QuantidadeAbaixoZeroException();

			if (produto.Valor < 0)
				throw new ValorAbaixoZeroException();

			ProdutoRepository produtoRepository = new ProdutoRepository();

			var produtos = produtoRepository.ObtemProdutosPorCodigoNome(produto.Codigo, produto.Nome);
			if (produtos != null && produtos.Count() > 0)
				throw new ProdutoExistenteException();

			produtoRepository.Update(produto);

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
			return new ProdutoRepository().ObtemTodosProdutos();
		}

		public void AtualizaProdutoVendido(Produto produtoVendido)
		{
			ProdutoRepository produtoRepository = new ProdutoRepository();
			var produto = produtoRepository.ObtemProdutoPorCodigo(produtoVendido.Codigo);
			produto.Quantidade = produtoVendido.Quantidade;
			produtoRepository.Update(produto);
		}
	}
}
