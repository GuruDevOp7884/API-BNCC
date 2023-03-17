using Puc.BnccTeste.Domain.Entidade;
using Puc.BnccTeste.Infra.Data.Interface;
using Puc.BnccTeste.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Service.Service
{
    public class BnccMatematicaEfService : IBnccMatematicaEfService
    {
        private readonly IBnccMatematicaEfRepositorio _matRepo;
        public BnccMatematicaEfService(IBnccMatematicaEfRepositorio matRepo)
        {
            _matRepo = matRepo;
        }

        public IList<BnccMatematicaEf> ListarAnosDaMateria(bool matematica, bool todos, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            try
            {
                var listagem = _matRepo.ListarTodos();

                if (matematica)
                {
                    if(listagem != null)
                    { 
                        if(todos)                        
                            return listagem.ToList();
                        
                        if(primeiroAno || segundoAno ||  terceiroAno || quartoAno || quintoAno || sextoAno || setimoAno || oitavoAno || nonoAno)
                        { 
                            return listagem.Where(
                                x => x.PrimeiroEf == primeiroAno && x.PrimeiroEf != false || 
                                x.SegundoEf == segundoAno && x.SegundoEf != false ||
                                x.TerceiroEf == terceiroAno && x.TerceiroEf != false ||
                                x.QuartoEf == quartoAno && x.QuartoEf != false || 
                                x.QuintoEf == quintoAno && x.QuintoEf != false || 
                                x.SextoEf == sextoAno && x.SextoEf != false ||
                                x.SetimoEf == setimoAno && x.SetimoEf != false || 
                                x.OitavoEf == oitavoAno && x.OitavoEf != false ||
                                x.NonoEf == nonoAno && x.NonoEf != false  
                                )
                                .ToList();
                        }
                    
                        return listagem.ToList();
                    }
                }              
            }
            catch (Exception ex)
            {

                return null;
            }

            return null;

        }

        public IList<BnccMatematicaEf> ListarTodos()
        {
            List<BnccMatematicaEf> lista = new List<BnccMatematicaEf>();
            try
            {
                lista = _matRepo.ListarTodos().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;
        }

        public BnccMatematicaEf ObterPeloCodHab(string cod)
        {
            try
            {
                return _matRepo.ObterPeloCodHab(cod);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public BnccMatematicaEf ObterPeloId(int id)
        {
            try
            {
                return _matRepo.ObterPeloId(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
