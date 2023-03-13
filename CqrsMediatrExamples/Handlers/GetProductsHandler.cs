using CqrsMediatrExamples.Entities;
using CqrsMediatrExamples.Queries;
using MediatR;

namespace CqrsMediatrExamples.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IList<Product>>
    {
        new private readonly FakeDataStore _fakeDataStore;

        public GetProductsHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
        public async Task<IList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
            => await _fakeDataStore.GetAllProducts();

    }
}
