using TestTask.Models;
using TestTask.Requests;

namespace TestTask.Service.Interface;

public interface IUsersService
{
    Task<IEnumerable<UserModel>> GetUsers();
    
    Task<UserModel> CreateUser(CreateUserRequest createUserRequest);
    
    Task<bool> DeleteUser(int userId);
}