using APIStreamFriends.domain.domain.Interfaces;
using APIStreamFriends.infra.Data.MSSQL.Context;
using APIStreamFriends.infra.Data.MSSQL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace APIStreamFriends.infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Repositories
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ISeguidorRepository, SeguidorRepository>();
            #endregion

            #region Validations
            //services.AddScoped<TransacaoCadastroValidations>();
            #endregion
            //sqlapistreamfriends
            services.AddDbContext<MSContext>(o => o.UseSqlServer("Server=localhost;Database=dbstreamfriends;User Id=sa;Password=sa@12345;"));
        }
    }
}
