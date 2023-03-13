using CqrsMediatrExamples.Entities;
using MediatR;

namespace CqrsMediatrExamples.Queries
{
    public record GetProductsQuery : IRequest<IList<Product>>;

}
