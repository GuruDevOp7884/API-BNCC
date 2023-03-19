using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.BnccTeste.Service.Interface;
using Newtonsoft.Json;
using Puc.BnccTeste.Service.DTOs;

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


        [HttpGet("/api/ListarAnosDaMateria")]
        public JsonResult ListarAnosDaMateria(bool matematica ,bool todos , bool primeiroAno, bool segundoAno , bool terceiroAno , bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            try
            {
                List<BnccMatematicaEfDTO> lista = new List<BnccMatematicaEfDTO>();
                var result = _service.ListarAnosDaMateria(matematica, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);

                foreach (var item in result)
                {
                    lista.Add(new BnccMatematicaEfDTO
                    {
                        Column1 = item.Column1,
                        Componente = item.Componente,
                        AnoFaixa = item.AnoFaixa,
                        UnidadesTematicas = item.UnidadesTematicas,
                        ObjetosConhecimento = item.ObjetosConhecimento,
                        Habilidades = item.Habilidades,
                        CodHab = item.CodHab,
                        DescricaoCod = item.DescricaoCod
                    });
                }

                return Json(lista);
            }
            catch (Exception ex)
            {
                return Json("Ocorreu algo inesperado");
            }
        }


    }
}
