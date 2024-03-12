using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Behaviours;
using Ordering.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //by putting Assembly.GetExecutingAssembly() is there any class is inherrited Profile
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //by putting Assembly.GetExecutingAssembly() is there any class is inherrited AbstractValidator
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //by putting Assembly.GetExecutingAssembly() is there any class is inherrited IRequest/IRequestHandler
            services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            return services;
        }
    }
}
