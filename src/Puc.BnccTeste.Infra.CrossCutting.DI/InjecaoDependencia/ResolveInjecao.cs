using Puc.BnccTeste.Infra.Data.Interface;
using Puc.BnccTeste.Infra.Data.Repositorio;
using Puc.BnccTeste.Service.Interface;
using Puc.BnccTeste.Service.Service;
using SimpleInjector;

namespace Puc.BnccTeste.Infra.CrossCutting.DI.InjecaoDependencia
{
    public static class ResolveInjecao
    {
        public static void RegisterService(Container container)
        {
            //services.AddDbContext<Contexto>(
            //    (provider, options) => options.UseSqlServer(configuration.GetConnectionString("BnccTesteConnection")).UseInternalServiceProvider(provider));

            #region Repositorio
            container.Register<IBnccMatematicaEfRepositorio, BnccMatematicaEfRepositorio>(Lifestyle.Scoped);
            #endregion

            #region Services
            container.Register<IBnccMatematicaEfService, BnccMatematicaEfService>(Lifestyle.Scoped);
            #endregion
        }
    }
}
