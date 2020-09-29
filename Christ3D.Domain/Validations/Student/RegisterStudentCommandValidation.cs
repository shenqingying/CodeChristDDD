using Christ3D.Domain.Commands;

namespace Christ3D.Domain.Validations.Student
{
    public class RegisterStudentCommandValidation : StudentValidation<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateBirthDate();
            ValidatePhone();
        }
    }
}
