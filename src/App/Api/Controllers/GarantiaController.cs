using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.WebApi.Controllers
{
  [ApiController]
  [Route("garantia")]
  public class GarantiaController : ControllerBase
  {

    [HttpGet]
    [Route("agenda/disponibilidade")]
    public IEnumerable<object> Get()
    {
      return new[] {
        new { mensagem = "ok" }
      };
    }
  }
}
