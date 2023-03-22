using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.BnccTeste.Service.Interface;
using Newtonsoft.Json;
using Puc.BnccTeste.Service.DTOs;
using ClosedXML.Excel;

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
                var lista = new List<BnccMatematicaEfDTO>();
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

        [HttpGet("/api/Excel")]
         public ActionResult Excel(bool matematica, bool todos, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            using (var workbook = new XLWorkbook())
            {
                var result = _service.ListarAnosDaMateria(matematica, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);
                var planilha = workbook.Worksheets.Add("Bncc");
                var linha = 1;
                planilha.Cell(linha, 1).Value = "Componente";
                planilha.Cell(linha, 2).Value = "AnoFaixa";
                planilha.Cell(linha, 3).Value = "UnidadesTematicas";
                planilha.Cell(linha, 4).Value = "ObjetosConhecimento";
                planilha.Cell(linha, 5).Value = "Habilidades";
                planilha.Cell(linha, 6).Value = "CodHab";
                planilha.Cell(linha, 7).Value = "DescricaoCod";

                foreach (var lista in result)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = lista.Componente;
                    planilha.Cell(linha, 2).Value = lista.AnoFaixa;
                    planilha.Cell(linha, 3).Value = lista.UnidadesTematicas;
                    planilha.Cell(linha, 4).Value = lista.ObjetosConhecimento;
                    planilha.Cell(linha, 5).Value = lista.Habilidades;
                    planilha.Cell(linha, 6).Value = lista.CodHab;
                    planilha.Cell(linha, 7).Value = lista.DescricaoCod;


                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();                 
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "RelatórioProdutos.xlsx");
                }
            }
        }


    }
}
