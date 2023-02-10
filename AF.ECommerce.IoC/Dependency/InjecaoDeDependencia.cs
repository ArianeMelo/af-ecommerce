using AF.ECommerce.Application;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Domain.Validadores.Classe;
using AF.ECommerce.Domain.Validadores.Interface;
using AF.ECommerce.Repository;
using AF.ECommerce.Repository.Repository;
using AF.ECommerce.Repository.Repository.Base;
using Microsoft.Extensions.DependencyInjection;

namespace AF.ECommerce.IoC.Dependency
{
    public class InjecaoDeDependencia
    {
        public static void RegistrarInjecaoDependencia(IServiceCollection services)
        {
            Container.RegistrarMapeamentoDapper();

            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IPedidoApplication, PedidoApplication>();
            services.AddScoped<IPedidoItemApplication, PedidoItemApplication>();
            services.AddScoped<ICategoriaApplication, CategoriaApplication>();
            services.AddScoped<ICep, Cep>();
            services.AddScoped<ICpf, Cpf>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
           
            services.AddScoped<IUnityOfWork, UnitYOfWork>();
        }
       
    }
}
