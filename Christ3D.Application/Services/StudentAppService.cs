using AutoMapper;
using Christ3D.Application.Interfaces;
using Christ3D.Application.ViewModels;
using Christ3D.Domain.Commands;
using Christ3D.Domain.Core.Bus;
using Christ3D.Domain.Interfaces;
using Christ3D.Domain.Models;
using System;
using System.Collections.Generic;

namespace Christ3D.Application.Services
{
    public class StudentAppService : IStudentAppService
    {
        //注意这里是要IoC依赖注入的，还没有实现
        private readonly IStudentRepository _studentRepository;
        //用来进行DTO
        private readonly IMapper _mapper;
        //中介者 总线
        private readonly IMediatorHandler Bus;

        public StudentAppService(IStudentRepository studentRepository, IMapper mapper, IMediatorHandler bus)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            Bus = bus;
        }


        public IEnumerable<StudentViewModel> GetAll()
        {
            //第一种写法
            return _mapper.Map<IEnumerable<StudentViewModel>>(_studentRepository.GetAll());
            //第二种写法
            // return (_studentRepository.GetAll()).ProjectTo<StudentViewModel>(_mapper.ConfigurationProvider);
        }

        public StudentViewModel GetById(Guid id)
        {
            return _mapper.Map<StudentViewModel>(_studentRepository.GetById(id));
        }

        public void Register(StudentViewModel StudentViewModel)
        {
            //这里引入领域设计中的写命令 还没有实现
            //请注意这里如果是平时的写法，必须要引入Student领域模型，会造成污染

            //_StudentRepository.Add(_mapper.Map<Student>(StudentViewModel));
            //_StudentRepository.SaveChanges();


            var registerCommand = _mapper.Map<RegisterStudentCommand>(StudentViewModel);
            Bus.SendCommand(registerCommand);

        }
        public void Update(StudentViewModel StudentViewModel)
        {
            _studentRepository.Update(_mapper.Map<Student>(StudentViewModel));
        }
        public void Remove(Guid id)
        {
            _studentRepository.Remove(id);
        }


        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
