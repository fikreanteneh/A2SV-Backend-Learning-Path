
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using BlogApi.Application.Contracts.Persistence;
using BlogApi.Prersistance;
using BlogApi.Prersistance.Repositories;
using Microsoft.Extensions.Options;


namespace BlogApi.Persitance;
public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersitance(this IServiceCollection services, IConfiguration configuration){
        services.AddDbContext< BlogApiDbContext > (options => {
            options.UseNpgsql(configuration.GetConnectionString("BlogApi"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        return services;
    }
}