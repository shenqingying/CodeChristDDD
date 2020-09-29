using Christ3D.Domain.Validations.Student;
using System;

namespace Christ3D.Domain.Commands
{
    public class RegisterStudentCommand : StudentCommand
    {

        public RegisterStudentCommand(string name, string email, DateTime birthdate, string phone, string province, string city, string county, string street)
        {
            Name = name;
            Email = email;
            BirthDate = birthdate;
            Phone = phone;
            Province = province;
            City = city;
            County = county;
            Street = street;
        }

        // 重写基类中的 是否有效 方法
        // 主要是为了引入命令验证 RegisterStudentCommandValidation。
        public override bool IsValid()
        {
            ValidationResult = new RegisterStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
