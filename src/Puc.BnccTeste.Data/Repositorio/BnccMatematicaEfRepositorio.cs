using Microsoft.EntityFrameworkCore;
using Puc.BnccTeste.Domain.Entidade;
using Puc.BnccTeste.Infra.Data.Context;
using Puc.BnccTeste.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Infra.Data.Repositorio
{
    public class BnccMatematicaEfRepositorio : RepositorioBase<BnccMatematicaEf>, IBnccMatematicaEfRepositorio
    {
        protected Contexto _Db;
        protected DbSet<BnccMatematicaEf> _DbSet;

        public BnccMatematicaEfRepositorio(Contexto contexto)
            : base(contexto) 
        {
            _Db = contexto;
            _DbSet = _Db.Set<BnccMatematicaEf>();
        }

        public IList<BnccMatematicaEf> ListarAnosDaMateria(bool matematica, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            List<BnccMatematicaEf> lista = new List<BnccMatematicaEf>();
            try
            {            
               if(matematica)
                {
                    if(primeiroAno)
                    {
                        lista.Select(x => x.PrimeiroEf).ToList();
                    }
                    //lista = _DbSet.Where(x =>
                    //x.PrimeiroEf == primeiroAno ||
                    //x.SegundoEf == segundoAno ||
                    //x.TerceiroEf == terceiroAno ||
                    //x.QuartoEf == quartoAno ||
                    //x.QuintoEf == quintoAno ||
                    //x.SextoEf == sextoAno ||
                    //x.SetimoEf == setimoAno ||
                    //x.OitavoEf == oitavoAno ||
                    //x.NonoEf == nonoAno).ToList();
                }                    
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista;

        }
    }
}
