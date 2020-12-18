using eVenda.Estoque.Service.AppSettingsModel;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace eVenda.Estoque.Service.Helper
{
	public class ServiceBusHelper<T>
	{
		public void EnviaMensagem(T entity, string topico)
		{
			AppSettingsServiceBus busSettings = AppSettingsServiceBus.CreateInstance();
			var topicClient = new TopicClient(busSettings.ConnectionString, topico);

			UTF8Encoding encoding = new UTF8Encoding(false);
			var messageBody = encoding.GetBytes(JsonConvert.SerializeObject(entity));
			var sendMessage = new Message(messageBody);
			topicClient.SendAsync(sendMessage);
		}

	}
}
