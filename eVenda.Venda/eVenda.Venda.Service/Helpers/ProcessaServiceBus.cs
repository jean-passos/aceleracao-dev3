using eVenda.Venda.Service.AppSettingsModel;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.Text;

namespace eVenda.Venda.Service.Helpers
{
	public class ProcessaServiceBus<T>
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
