using CqrsMediatrExamples.Entities;
using MediatR;

namespace CqrsMediatrExamples.Notifications
{
    public record ProductAddedNotification(Product product) : INotification;

}
