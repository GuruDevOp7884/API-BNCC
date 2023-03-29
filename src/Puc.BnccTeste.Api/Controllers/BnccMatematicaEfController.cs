using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puc.BnccTeste.Service.Interface;
using Newtonsoft.Json;
using Puc.BnccTeste.Service.DTOs;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Dynamic;

namespace Puc.BnccTeste.Api.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class BnccMatematicaEfController : Controller
    {
        private readonly IBnccMatematicaEfService _matematica;
        private readonly IBnccLinguaPortuguesaEfService _portugues;
        public BnccMatematicaEfController(IBnccMatematicaEfService matematica,
                                          IBnccLinguaPortuguesaEfService portugues





        )
        {
            _matematica = matematica;
            _portugues = portugues;
        }


        [HttpGet("/api/ListarAnosDaMateria")]
        public JsonResult ListarAnosDaMateria(string materia,bool todos , bool primeiroAno, bool segundoAno , bool terceiroAno , bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            try
            {        
                if(materia == "matematica")
                {
                    var lista = new List<BnccMatematicaEfDTO>();
                    var result = _matematica.ListarAnosMatematica(materia, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);

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

                else if(materia == "portugues")
                {
                    var lista = new List<BnccLinguaPortuguesaEfDTO>();
                    var result = _portugues.ListarAnosPortugues(materia, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);

                    foreach (var item in result)
                    {
                        lista.Add(new BnccLinguaPortuguesaEfDTO
                        {
                            Column1 = item.Column1,
                            Componente = item.Componente,
                            AnoFaixa = item.AnoFaixa,
                            CampoAtuacao = item.CampoAtuacao,
                            PraticasLinguagem = item.PraticasLinguagem,
                            ObjetosConhecimento = item.ObjetosConhecimento,
                            Habilidades = item.Habilidades,
                            CodHab = item.CodHab,
                            DescricaoCod = item.DescricaoCod
                        });
                    }

                    return Json(lista);
                }

                return Json("Nenhum registro encontrado!");
            }
            catch (Exception ex)
            {
                return Json("Ocorreu algo inesperado!");
            }
        }

        [HttpGet("/api/Excel")]
        public ActionResult Excel(string materia, bool todos, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            using (var workbook = new XLWorkbook())
            {

                dynamic result = "";
                if(materia == "matematica")
                    result = _matematica.ListarAnosMatematica(materia, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);
                if (materia == "portugues")
                    result = _portugues.ListarAnosPortugues(materia, todos, primeiroAno, segundoAno, terceiroAno, quartoAno, quintoAno, sextoAno, setimoAno, oitavoAno, nonoAno);

               

                var planilha = workbook.AddWorksheet("Bncc");
                var linha = 3;
                var BnccImage = @"C:\Users\Guru\Desktop\BannerBNcc.png";                

                planilha.AddPicture(BnccImage).MoveTo(planilha.Cell(1, 1)).ScaleWidth(1.045, true);

                planilha.Cell(2, 1).Value = (materia == "matematica") ? "Matemática" : "Português";
                planilha.Cell(2, 1).Worksheet.Range("A2", "G2").Merge();

                planilha.Cell(linha, 1).Value = "Componente";
                planilha.Cell(linha, 2).Value = "AnoFaixa";
                planilha.Cell(linha, 3).Value = (materia == "matematica") ? "UnidadesTematicas" : "Campo Atuação";
                planilha.Cell(linha, 4).Value = "ObjetosConhecimento";
                planilha.Cell(linha, 5).Value = "Habilidades";
                planilha.Cell(linha, 6).Value = "CodHab";
                planilha.Cell(linha, 7).Value = "DescricaoCod";

                //Style     
                #region Font
                planilha.Cell(2, 1).Style
                    .Font.SetFontSize(16)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 1).Style
                     .Font.SetFontSize(13)
                     .Font.SetFontName("Calibri")
                     .Font.SetBold(true)
                     .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 2).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 3).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 4).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 5).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 6).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                planilha.Cell(linha, 7).Style
                    .Font.SetFontSize(13)
                    .Font.SetFontName("Calibri")
                    .Font.SetBold(true)
                    .Font.SetFontColor(XLColor.White);
                #endregion

                #region Alinhamento
                planilha.Cell(2, 1).Style
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                planilha.Cell(linha, 1).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 2).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 3).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 4).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 5).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 6).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                planilha.Cell(linha, 7).Style
                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                #endregion

                #region Alt/Larg
                planilha.Cell(1, 1).Worksheet.Row(1).Height = 118;
                planilha.Cell(2, 1).Worksheet.Row(2).Height = 35;
                planilha.Cell(linha, 1).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 2).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 3).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 4).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 5).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 6).Worksheet.Row(3).Height = 35;
                planilha.Cell(linha, 7).Worksheet.Row(3).Height = 35;

                planilha.Cell(linha, 1).Worksheet.Column(1).Width = 20;
                planilha.Cell(linha, 2).Worksheet.Column(2).Width = 20;
                planilha.Cell(linha, 3).Worksheet.Column(3).Width = 35;
                planilha.Cell(linha, 4).Worksheet.Column(4).Width = 45;
                planilha.Cell(linha, 5).Worksheet.Column(5).Width = 55;
                planilha.Cell(linha, 6).Worksheet.Column(6).Width = 20;
                planilha.Cell(linha, 7).Worksheet.Column(7).Width = 70;
                #endregion

                #region Border
                planilha.Cell(2, 1).Style
                      .Border.SetRightBorder(XLBorderStyleValues.Medium)
                      .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                      .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                      .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 1).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 2).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 3).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 4).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 5).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 6).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                planilha.Cell(linha, 7).Style
                    .Border.SetRightBorder(XLBorderStyleValues.Medium)
                    .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                    .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                    .Border.SetTopBorder(XLBorderStyleValues.Medium);
                #endregion

                #region Bg-Color
                planilha.Cell(2, 1).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 1).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 2).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 3).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 4).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 5).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 6).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                planilha.Cell(linha, 7).Style.Fill.SetBackgroundColor(XLColor.DodgerBlue);
                #endregion



                foreach (var lista in result)
                {
                    linha++;
                    planilha.Cell(linha, 1).Value = lista.Componente;
                    planilha.Cell(linha, 2).Value = lista.AnoFaixa;
                    planilha.Cell(linha, 3).Value = (materia == "matematica") ? lista.UnidadesTematicas : lista.CampoAtuacao; ;
                    planilha.Cell(linha, 4).Value = lista.ObjetosConhecimento;
                    planilha.Cell(linha, 5).Value = lista.Habilidades;
                    planilha.Cell(linha, 6).Value = lista.CodHab;
                    planilha.Cell(linha, 7).Value = lista.DescricaoCod;

                    //Style
                    #region FontSize/Style
                    planilha.Cell(linha, 1).Style
                        .Font.SetFontSize(13)
                        .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 2).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 3).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 4).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 5).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 6).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");
                    planilha.Cell(linha, 7).Style
                       .Font.SetFontSize(13)
                       .Font.SetFontName("Calibri");

                    #endregion

                    #region Alinhamento
                    planilha.Cell(linha, 1).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 2).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 3).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 4).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 5).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 6).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    planilha.Cell(linha, 7).Style
                        .Alignment.SetVertical(XLAlignmentVerticalValues.Center)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                    #endregion

                    #region QuebraDeLinha
                    planilha.Cell(linha, 1).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 2).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 3).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 4).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 5).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 6).Style.Alignment.WrapText = true;
                    planilha.Cell(linha, 7).Style.Alignment.WrapText = true;
                    #endregion

                    #region Altura
                    planilha.Cell(linha, 1).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 2).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 3).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 4).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 5).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 6).Worksheet.Row(linha).Height = 200;
                    planilha.Cell(linha, 7).Worksheet.Row(linha).Height = 200;
                    #endregion

                    #region Bg-Color
                    planilha.Cell(linha, 4).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    planilha.Cell(linha, 5).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    planilha.Cell(linha, 6).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    planilha.Cell(linha, 7).Style.Fill.SetBackgroundColor(XLColor.LightGray);
                    #endregion

                    #region Border
                    planilha.Cell(linha, 1).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 2).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 3).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 4).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 5).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 6).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    planilha.Cell(linha, 7).Style
                        .Border.SetRightBorder(XLBorderStyleValues.Medium)
                        .Border.SetBottomBorder(XLBorderStyleValues.Medium)
                        .Border.SetLeftBorder(XLBorderStyleValues.Medium)
                        .Border.SetTopBorder(XLBorderStyleValues.Medium);
                    #endregion
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                   
                    var content = stream.ToArray();                 
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"Bncc_{materia}.xlsx");

                }
            }
        }


    }
}
