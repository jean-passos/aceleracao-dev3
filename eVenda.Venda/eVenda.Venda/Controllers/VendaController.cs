using AutoMapper;
using eVenda.Venda.Models;
using eVenda.Venda.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NSDomainModel = eVenda.Venda.DomainModel.Model;

namespace eVenda.Venda.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;


		public VendaController(IConfiguration configuration, IMapper mapper)
		{
			_configuration = configuration;
			_mapper = mapper;
		}


		[HttpPost]
		public ActionResult RealizaVenda([FromBody]VendaModel vendaModel)
		{
			GerenciaVenda gerenciaVenda = new GerenciaVenda(_configuration);
			NSDomainModel.Venda venda = _mapper.Map<NSDomainModel.Venda>(vendaModel);
			gerenciaVenda.RealizaVenda(venda);
			return Ok();
		}
    }
}