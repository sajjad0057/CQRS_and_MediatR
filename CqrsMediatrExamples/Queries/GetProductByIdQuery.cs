using CqrsMediatrExamples.Entities;
using MediatR;

namespace CqrsMediatrExamples.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product>;

}
