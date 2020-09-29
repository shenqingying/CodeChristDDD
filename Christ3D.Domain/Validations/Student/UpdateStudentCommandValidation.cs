using Christ3D.Domain.Commands.Student;

namespace Christ3D.Domain.Validations.Student
{
    public class UpdateStudentCommandValidation : StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation()
        {
            ValidateId();
            ValidateEmail();
            ValidateBirthDate();
            ValidateName();
            ValidatePhone();

        }
    }
}
