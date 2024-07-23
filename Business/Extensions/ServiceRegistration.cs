using Business.Abstract;
using Business.Concrete;
using Business.Validations;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete.TableModels;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Business.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBlogDal, BlogDal>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IValidator<Blog>, BlogValidation>();

            return services;
        }
    }
}
