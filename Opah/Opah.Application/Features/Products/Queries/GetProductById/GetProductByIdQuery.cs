using Opah.Application.Exceptions;
using Opah.Application.Interfaces.Repositories;
using Opah.Application.Wrappers;
using Opah.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opah.Application.Features.Products.Queries.GetProductById
{
    public class RetornarClienteQuery : IRequest<Response<Product>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<RetornarClienteQuery, Response<Product>>
        {
            private readonly IProductRepositoryAsync _productRepository;
            public GetProductByIdQueryHandler(IProductRepositoryAsync productRepository)
            {
                _productRepository = productRepository;
            }
            public async Task<Response<Product>> Handle(RetornarClienteQuery query, CancellationToken cancellationToken)
            {
                var product = await _productRepository.GetByIdAsync(query.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                return new Response<Product>(product);
            }
        }
    }
}
