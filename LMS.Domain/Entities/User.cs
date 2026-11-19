using LMS.Domain.Enums;

namespace LMS.Domain.Entities;

public class User{

	public int Id {get; set;}

	public string FullName {get; set;} = string.Empty;

	public string Email {get; set;} = string.Empty;

	public string PasswordHash {get; set;} = string.Empty;

	public UserRole Role {get; set;} = UserRole.Student;

	public bool Active {get; set;} = true;

	public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

}
