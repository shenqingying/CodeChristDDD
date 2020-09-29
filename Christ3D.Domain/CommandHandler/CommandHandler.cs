using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Core.Commands;
using Christ3D.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Christ3D.Domain.CommandHandler
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        // 注入工作单元
        private readonly IUnitOfWork _unitOfWork;
        // 注入中介处理接口（目前用不到，在领域事件中用来发布事件）
        private readonly IMediatorHandler _bus;
        // 注入缓存，用来存储错误信息（目前是错误方法，以后用领域通知替换）
        private readonly IMemoryCache _cache;
        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _bus = bus;
            _cache = cache;
        }
        //工作单元提交
        //如果有错误，下一步会在这里添加领域通知
        public bool Commit()
        {
            if (_unitOfWork.Commit())
                return true;
            return false;
        }

        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach(var error in message.ValidationResult.Errors)
            {
                errorInfo.Add(error.ErrorMessage);
            }
            //收集错误消息
            _cache.Set("ErrorDate", errorInfo);
        }
    }
}
