using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eVenda.Venda.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eVenda.Venda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {

		[HttpPost]
		public ActionResult RealizaVenda([FromBody]VendaModel vendaModel)
		{
			return Ok();
		}


    }
}