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
                if (matematica)
                {
                    var listagem = _matRepo.ListarTodos().ToList();
                    foreach (var item in listagem)
                    {
                        if (todos)
                            return _matRepo.ListarTodos().ToList();

                        if (primeiroAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.PrimeiroEf != false).ToList();

                        if (segundoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SegundoEf != false).ToList();

                        if (terceiroAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.TerceiroEf != false).ToList();

                        if (quartoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.QuartoEf != false).ToList();

                        if (quintoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.QuintoEf != false).ToList();

                        if (sextoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SextoEf != false).ToList();

                        if (setimoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SetimoEf != false).ToList();

                        if (oitavoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.OitavoEf != false).ToList();

                        if (nonoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.NonoEf != false).ToList();

                    }

                    return listagem;
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
