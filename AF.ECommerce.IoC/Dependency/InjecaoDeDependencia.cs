using AF.ECommerce.Application;
using AF.ECommerce.Domain.Interfaces.Application;
using AF.ECommerce.Domain.Interfaces.Repository;
using AF.ECommerce.Domain.Validadores.Classe;
using AF.ECommerce.Domain.Validadores.Interface;
using AF.ECommerce.Repository;
using AF.ECommerce.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AF.ECommerce.IoC.Dependency
{
    public class InjecaoDeDependencia
    {
        public static void RegistrarInjecaoDependencia(IServiceCollection services)
        {
            Container.RegistrarMapeamentoDapper();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IPedidoItemRepository, PedidoItemRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IPedidoApplication, PedidoApplication>();
            services.AddScoped<IPedidoItemApplication, PedidoItemApplication>();
            services.AddScoped<ICategoriaApplication, CategoriaApplication>();
            services.AddScoped<ICep, Cep>();
            services.AddScoped<ICpf, Cpf>();
        }
       
    }
}
