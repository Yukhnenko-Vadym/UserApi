using TestTask.Requests;

namespace TestTask.Models;

public class UserModel
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }

    public UserModel(string fullName, string email, DateTime dateOfBirth)
    {
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
    }
}
