using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.BnccTeste.Service.Interface;
using Newtonsoft.Json;

namespace Puc.BnccTeste.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BnccMatematicaEfController : Controller
    {
        private readonly IBnccMatematicaEfService _service;
        public BnccMatematicaEfController(IBnccMatematicaEfService service)
        {
            _service = service;
        }


        [HttpPost("/api/ListarAnosDaMateria")]
        public JsonResult ListarAnosDaMateria(bool matematica = false, bool primeiroAno = false, bool segundoAno = false, bool terceiroAno = false, bool quartoAno = false, bool quintoAno = false, bool sextoAno = false, bool setimoAno = false, bool oitavoAno = false, bool nonoAno = false)
        {
            try
            {
                var result = _service.ListarAnosDaMateria(matematica, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);
                return Json(result.ToList());
            }
            catch (Exception ex)
            {
                return Json(() => { return BadRequest("Erro ao listar"); });
            }
        }


    }
}
