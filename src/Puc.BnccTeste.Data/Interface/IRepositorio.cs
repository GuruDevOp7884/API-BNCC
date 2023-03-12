using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Infra.Data.Interface
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> ListarTodos();         
        //IEnumerable<TEntity> ListarPorAno(bool primeiroAno, bool segundoAno, bool terceiroAno, bool quartoAno, bool quintoAno, bool sextoAno, bool setimoAno, bool oitavoAno, bool nonoAno);         
        IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate);
        TEntity ObterPeloId(int id);
        TEntity ObterPeloCodHab(string cod);

        //obter competencias por materias
    }
}
