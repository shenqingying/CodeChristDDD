using Christ3D.Domain.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Christ3D.Domain.Models
{
    //实体与值对象的区别:
    //1.实体拥有标识，而值对象没有。
    //2.相等性测试方式不同。实体根据标识判等，而值对象根据内部所有属性值判等。
    //3.实体允许变化，值对象不允许变化。
    //4.持久化的映射方式不同。实体采用单表继承、类表继承和具体表继承来映射类层次结构，而值对象使用嵌入值或序列化大对象方式映射。
    //简而言之 - 实体是具备唯一标识的可变的普通对象对象；值对像是没有唯一标识的不可变对象，可以降低实体的复杂度尤其是计算复杂度。
    [Owned]
    public class Address : ValueObject<Address>
    {
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; private set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// 区县
        /// </summary>
        public string County { get; private set; }
        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; private set; }


        public Address() { }

        public Address(string province, string city, string county, string street)
        {
            this.Province = province;
            this.City = city;
            this.County = county;
            this.Street = street;
        }
        public override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool EqualsCore(Address other)
        {
            throw new NotImplementedException();
        }
    }
}
