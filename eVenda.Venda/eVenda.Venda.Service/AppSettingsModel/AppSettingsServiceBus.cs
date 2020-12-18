using Microsoft.Extensions.Configuration;
using System.IO;

namespace eVenda.Venda.Service.AppSettingsModel
{
	public class AppSettingsServiceBus
	{
		public string ConnectionString { get; set; }
		public string TopicProdutoCriado { get; set; }
		public string TopicProdutoAtualizado { get; set; }

		private AppSettingsServiceBus() { }

		public static AppSettingsServiceBus CreateInstance()
		{
			var configurationBuilder = new ConfigurationBuilder();
			var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
			configurationBuilder.AddJsonFile(path);
			var root = configurationBuilder.Build();
			AppSettingsServiceBus settingsServiceBus = new AppSettingsServiceBus();
			root.Bind("ServiceBusSettings", settingsServiceBus);
			return settingsServiceBus;
		}
	}
}
