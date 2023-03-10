using Microsoft.Extensions.DependencyInjection;
using Puc.BnccTeste.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Puc.BnccTeste.Infra.CrossCutting.DI.InjecaoDependencia
{
    public static class ResolveInjecao
    {
        public static void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Contexto>(
                options => options.UseSqlServer(configuration.GetConnectionString("BnccTesteConnection")));
        }
    }
}
