using Christ3D.Application.Interfaces;
using Christ3D.Application.Services;
using Christ3D.Domain.CommandHandler;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Commands.Student;
using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Interfaces;
using Christ3D.Infrastruct.Bus;
using Christ3D.Infrastruct.Context;
using Christ3D.Infrastruct.Repository;
using Christ3D.Infrastruct.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Christ3D.Test.Extensions
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // 注入 基础设施层 - 数据层
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<StudyContext>();
            //注入Application应用层
            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();
        }
    }
}
