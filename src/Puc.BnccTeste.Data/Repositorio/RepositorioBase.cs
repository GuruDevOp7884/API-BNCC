using Puc.BnccTeste.Infra.Data.Context;
using Puc.BnccTeste.Infra.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Puc.BnccTeste.Infra.Data.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        public RepositorioBase(Contexto contexto)
        {
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public TEntity ObterPeloId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
