using Opah.Application.Features.Products.Commands.CreateProduct;
using Opah.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Opah.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();            
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();            
        }
    }
}
