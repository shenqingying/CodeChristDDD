using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Christ3D.Infrastruct.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        /// <summary>
        /// 一个密封类，实现我们的中介记忆总线
        /// </summary>
        private readonly IMediator _mediator;
        //注入服务工厂
        private readonly ServiceFactory _serviceFactory;

        private readonly ConcurrentDictionary<Type, object> _requserHandler = new ConcurrentDictionary<Type, object>();
        public InMemoryBus(IMediator mediator, ServiceFactory serviceFactory)
        {
            _mediator = mediator;
            _serviceFactory = serviceFactory;
        }
        /// <summary>
        /// 实现我们在IMediatorHandler中定义的接口
        /// 没有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);//请注意 入参 的类型
        }

    }
}
