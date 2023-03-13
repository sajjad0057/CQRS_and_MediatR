using CqrsMediatrExamples.Entities;
using MediatR;

namespace CqrsMediatrExamples.Commands
{
    public record AddProductCommand(Product Product) : IRequest<Product>;
}
