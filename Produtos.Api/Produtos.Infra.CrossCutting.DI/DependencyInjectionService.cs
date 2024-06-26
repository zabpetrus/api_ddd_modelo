using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Produtos.Application.Interfaces;
using Produtos.Application.AppServices;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Services;
using Produtos.Domain.Interfaces.Repository;
using Produtos.Infra.Data.EntityFramework.Repository;
using Produtos.Infra.Data.EntityFramework.Context;
using Produtos.Infra.Data.Context;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Http;
using Produtos.Infra.Data.UnitWork;
using Produtos.Infra.Data.EntityFramework.UnitWork;
using Produtos.Infra.CrossCutting.Security.Services;
using Microsoft.EntityFrameworkCore;

namespace Produtos.Infra.CrossCutting.DI
{
    public static class DependencyInjectionService
    {
        public static void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        {
            RegisterDatabase(configuration, services);
            RegisterRepositories(services);
            RegisterServices(services);
            RegisterApplicationServices(services);
            RegisterInfrastructures(services);
        }

        //public static void RegisterDependencies(IConfiguration configuration, IServiceCollection services)
        //{
        //    RegisterDatabase(configuration, services);
        //    RegisterRepositories(services);
        //    RegisterServices(services);
        //    RegisterApplicationServices(services);
        //    RegisterInfrastructures(services);
        //}

        private static void RegisterDatabase(IConfiguration configuration, IServiceCollection services)
        {
            // Banco de dados da aplicação
            var conexao = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<PureBrProductsContext>(options => options.UseSqlServer(conexao));
            services.AddEntityFrameworkSqlServer();
            services.AddSingleton(typeof(IDatabaseContext), typeof(PureBrProductsContext));
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IProdutoAppService), typeof(ProdutoAppService));
            //services.AddScoped(typeof(IAutenticacaoAppService), typeof(AutenticacaoAppService));
            //services.AddScoped(typeof(IUsuarioAppService), typeof(UsuarioAppService));
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped(typeof(IProdutoService), typeof(ProdutoService));
            //services.AddScoped(typeof(IProdutoService), typeof(ProdutoService));
            //    services.AddScoped(typeof(IMarketplaceService), typeof(MarketplaceService));
            //    services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
            //    services.AddScoped(typeof(IPerfilService), typeof(PerfilService));
            //    services.AddScoped(typeof(IItemCompraService), typeof(ItemCompraService));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped(typeof(IProdutoRepository), typeof(ProdutoRepository));
            //    services.AddScoped(typeof(IMarketplaceRepository), typeof(MarketplaceRepository));
            //    services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            //    services.AddScoped(typeof(IPerfilRepository), typeof(PerfilRepository));
        }

        private static void RegisterInfrastructures(IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.TryAddSingleton<IHostingEnvironment, HostingEnvironment>();
            services.AddScoped(typeof(IUnitWork), typeof(UnitWork));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
        }
    }
}
