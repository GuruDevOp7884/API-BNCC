using Microsoft.EntityFrameworkCore;
using Puc.BnccTeste.Domain.Entidade;
using Puc.BnccTeste.Infra.Data.Context;
using Puc.BnccTeste.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                
        public IList<BnccMatematicaEf> ListarAnosDaMateria(bool matematica, bool todos, bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno)
        {
            var lista = _Db.BnccMatematicaEfs.ToList();
            try
            {            
                if(matematica)
                {
                    var lista2 = lista;
                    if (todos)
                    {
                        return lista2;
                    }
                    if (primeiroAno)
                    {
                        lista2 = lista.Where(x => x.PrimeiroEf == primeiroAno).ToList();
                        return lista2;
                    }                                 
                    
                    if (segundoAno)
                    {
                        lista2 = lista.Where(x => x.SegundoEf == segundoAno).ToList();
                        return lista2;
                    }

                    if (terceiroAno)
                    {
                        lista2 = lista.Where(x => x.TerceiroEf == terceiroAno).ToList();
                        return lista2;
                    }
                    if (quartoAno)
                    {
                        lista2 = lista.Where(x => x.QuartoEf == quartoAno).ToList();
                        return lista2;
                    }
                    if (quintoAno)
                    {
                        lista2 = lista.Where(x => x.QuintoEf == quintoAno).ToList();
                        return lista2;
                    }
                    if (sextoAno)
                    {
                        lista2 = lista.Where(x => x.SextoEf == sextoAno).ToList();
                        return lista2;
                    } 
                    if (setimoAno)
                    {
                        lista2 = lista.Where(x => x.SetimoEf == setimoAno).ToList();
                        return lista2;
                    } 
                    if (oitavoAno)
                    {
                        lista2 = lista.Where(x => x.OitavoEf == oitavoAno).ToList();
                        return lista2;
                    }
                    if (nonoAno)
                    {
                        lista2 = lista.Where(x => x.NonoEf == nonoAno).ToList();
                        return lista2;
                    }
                    

                }
            }
            catch (Exception ex)
            {
                lista = null;
            }

            return lista = null;

        }
    }
}
//var lista = _Db.BnccMatematicaEfs.ToList();
//try
//{
//    if (matematica)
//    {
//        //if(primeiroAno)
//        //{
//        //    lista.Select(x => x.PrimeiroEf).ToList();
//        //                    
//        var lista2 = lista.Where(x => x.PrimeiroEf == true).ToList();
//        return lista2;