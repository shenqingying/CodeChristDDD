using Christ3D.Domain.Commands.Student;

namespace Christ3D.Domain.Validations.Student
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
