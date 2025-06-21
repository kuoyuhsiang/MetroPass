using MetroPass.Domain.Interfaces;
using MetroPass.Infrastructure.Repository;

namespace MetroPass.Presentation.Register;

public static class RepositoryRegister
{
    public static IServiceCollection AddRepositories(this IServiceCollection service)
    {
        service.AddSingleton<ICardRepository, InMemoryCardRepository>();
        return service;
    }
}