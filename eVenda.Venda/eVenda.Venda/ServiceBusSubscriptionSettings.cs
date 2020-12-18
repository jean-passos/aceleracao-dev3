using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eVenda.Venda
{
	public class ServiceBusSubscriptionSettings
	{
		public string ConnectionString { get; set; }
		public string TopicProdutoCriado { get; set; }
		public string SubscriptionProdutoCriado { get; set; }
		public string TopicProdutoAlterado { get; set; }
		public string SubscriptionProdutoAlterado { get; set; }
	}
}
