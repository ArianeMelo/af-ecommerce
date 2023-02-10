using AF.ECommerce.API.ViewModel;
using AF.ECommerce.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AF.ECommerce.API.ConfigurationMapper
{
    public class AutoMappeConfiguration : Profile
    {
        public AutoMappeConfiguration()
        {
           // CreateMap<Produto, ProdutoPostViewModel>().ReverseMap();     
        
        }
    }
}
