using Application.Dtos.Course;

namespace Application.Dtos.Student.Commands;

public class UpdateStudentCommandResponseDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public Guid StudentCode { get; set; }
    public DateTime BirthDate { get; set; }
    public List<CourseResponseDto> Courses { get; set; } = new();
}