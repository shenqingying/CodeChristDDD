using Christ3D.Domain.Core.Models;
using System;

namespace Christ3D.Domain.Models
{
    /// <summary>
    /// Student 领域对象
    /// </summary>
    public class Student : Entity
    {
        protected Student() { }
        public Student(Guid id, string name, string email, string phone, DateTime birthDate, Address address)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            BirthDate = birthDate;
            Address = address;
        }
        // public Guid Id { get; private set; }//模型的唯一标识
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; private set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 户籍
        /// </summary>
        public Address Address { get; private set; }
    }
}
