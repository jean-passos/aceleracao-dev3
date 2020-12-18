namespace eVenda.Estoque
{
	public class ServiceBusSubscriptionSettings
	{
		public string ConnectionString { get; set; }
		public string TopicProdutoVendido { get; set; }
		public string SubscriptionProdutoVendido { get; set; }
	}
}
