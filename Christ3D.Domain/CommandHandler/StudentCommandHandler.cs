using Christ3D.Domain.Commands;
using Christ3D.Domain.Commands.Student;
using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Christ3D.Domain.CommandHandler
{
    public class StudentCommandHandler : CommandHandler,
        IRequestHandler<RegisterStudentCommand, Unit>,
        IRequestHandler<UpdateStudentCommand, Unit>,
        IRequestHandler<RemoveStudentCommand, Unit>
    {
        // 注入仓储接口
        private readonly IStudentRepository _studentRepository;
        // 注入总线
        private readonly IMediatorHandler _bus;
        //注入缓存
        private readonly IMemoryCache _cache;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="studentRepository"></param>
        /// <param name="uow"></param>
        /// <param name="bus"></param>
        /// <param name="cache"></param>
        public StudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork uow,
            IMediatorHandler bus, IMemoryCache cache) : base(uow, bus, cache)
        {
            _studentRepository = studentRepository;
            _bus = bus;
            _cache = cache;
        }
        // RegisterStudentCommand命令的处理程序
        // 整个命令处理程序的核心都在这里
        // 不仅包括命令验证的收集，持久化，还有领域事件和通知的添加
        public Task<Unit> Handle(RegisterStudentCommand message, CancellationToken cancellationToken)
        {
            // 命令验证
            if (!message.IsValid())
            {
                //错误信息收集
                NotifyValidationErrors(message);
                return Task.FromResult(new Unit());
            }
            // 实例化领域模型，这里才真正的用到了领域模型
            // 注意这里是通过构造函数方法实现
            var address = new Address(message.Province, message.City,
              message.County, message.Street);
            var customer = new Student(Guid.NewGuid(), message.Name, message.Email, message.Phone, message.BirthDate, address);


            if (_studentRepository.GetByEmail(customer.Email) != null)
            {
                List<string> errorinfo = new List<string>() { "The customer e-mail has already been taken." };
                _cache.Set("ErrorDate", errorinfo);
                return Task.FromResult(new Unit());
            }
            //持久化
            _studentRepository.Add(customer);
            //统一提交
            if (Commit())
            {
                // 提交成功后，这里需要发布领域事件
                // 比如欢迎用户注册邮件呀，短信呀等

                // waiting....
            }
            return Task.FromResult(new Unit());
        }

        public Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    // 手动回收
    public void Dispose()
    {
        _studentRepository.Dispose();
    }
}


