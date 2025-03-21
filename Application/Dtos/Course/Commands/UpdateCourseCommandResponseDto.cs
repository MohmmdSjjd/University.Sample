using Application.Dtos.Student;

namespace Application.Dtos.Course.Commands;

public class UpdateCourseCommandResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public ICollection<StudentDto> Students { get; set; }
}