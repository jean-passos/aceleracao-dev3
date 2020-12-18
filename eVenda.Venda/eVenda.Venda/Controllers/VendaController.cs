using AutoMapper;
using eVenda.Venda.Models;
using eVenda.Venda.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using NSDomainModel = eVenda.Venda.DomainModel.Model;

namespace eVenda.Venda.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
		private readonly IMapper _mapper;

		public VendaController(IConfiguration configuration, IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpPost]
		public ActionResult RealizaVenda([FromBody]VendaModel vendaModel)
		{
			try
			{
				GerenciaVenda gerenciaVenda = new GerenciaVenda();
				NSDomainModel.Venda venda = _mapper.Map<NSDomainModel.Venda>(vendaModel);
				gerenciaVenda.RealizaVenda(venda);
				return Ok();
			}
			catch (Exception exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, exception.Message);
			}
		}
    }
}