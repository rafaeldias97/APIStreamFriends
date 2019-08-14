using APIStreamFriends.infra.Data.MSSQL.Context;
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
            //services.AddTransient<ITransacaoRepository, TransacaoRepository>();
            #endregion

            #region Validations
            //services.AddScoped<TransacaoCadastroValidations>();
            #endregion

            services.AddDbContext<MSContext>(o => o.UseSqlServer("Server=sqltransacao;Database=sqlapistreamfriends;User Id=sa;Password=sa@12345;"));
        }
    }
}
