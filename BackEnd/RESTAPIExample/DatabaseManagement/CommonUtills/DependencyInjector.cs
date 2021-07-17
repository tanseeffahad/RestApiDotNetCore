using AutoMapper;
using DatabaseManagement.Interfaces;
using DatabaseManagement.Models;
using DatabaseManagement.Services;
using Microsoft.Extensions.DependencyInjection;


namespace DatabaseManagement.CommonUtills
{
    public static class DependencyInjector
    {
        public static void InjectDatabaseManagementService(this IServiceCollection services)
        {
            services.AddScoped<IAuthorization, SRVAuthorization>();
            services.AddScoped<ISRVUser, SRVUsers>();
            services.AddScoped<ISRVTasks, SRVTasks>();

        }
    }
}
