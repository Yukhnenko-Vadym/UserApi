using System.ComponentModel.DataAnnotations;

namespace TestTask.Requests;

public class CreateUserRequest
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}