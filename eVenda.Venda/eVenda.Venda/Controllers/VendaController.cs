using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eVenda.Venda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace eVenda.Venda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

		private readonly IConfiguration _configuration;

		public VendaController(IConfiguration configuration)
		{
			_configuration = configuration;
		}


		[HttpPost]
		public ActionResult RealizaVenda([FromBody]VendaModel vendaModel)
		{

			var serviceBusConfig = _configuration.GetSection("ServiceBus");

			var connectionString = serviceBusConfig.GetValue<string>("ConnectionString");
			var topic = serviceBusConfig.GetValue<string>("TopicProdutoVendido");

			var topicClient = new TopicClient(connectionString, topic);
			var body = new UTF8Encoding().GetBytes(JsonConvert.SerializeObject(vendaModel));
			var message = new Message(body);
			topicClient.SendAsync(message);

			return Ok();
		}
    }
}