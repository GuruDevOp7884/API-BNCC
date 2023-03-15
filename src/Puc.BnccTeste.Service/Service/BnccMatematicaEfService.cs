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
                    if (listagem != null) 
                    {                    
                        if (todos)
                            return _matRepo.ListarTodos().ToList();

                        if (primeiroAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.PrimeiroEf != false);

                        if (segundoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SegundoEf != false);

                        if (terceiroAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.TerceiroEf != false);

                        if (quartoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.QuartoEf != false);

                        if (quintoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.QuintoEf != false);

                        if (sextoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SextoEf != false);

                        if (setimoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.SetimoEf != false);

                        if (oitavoAno)
                            listagem = _matRepo.ListarTodos().Where(x => x.OitavoEf != false);

                        if (nonoAno)
                                listagem = _matRepo.ListarTodos().Where(x => x.NonoEf != false);                    

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
