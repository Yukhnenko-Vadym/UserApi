using FluentValidation;
using TestTask.Data;
using TestTask.Mapping;
using TestTask.Models;
using TestTask.Requests;
using TestTask.Service.Interface;
using TestTask.Validation;

namespace TestTask.Service;

public class UsersService : IUsersService
{
    private readonly UserValidator _validator;

    public UsersService(UserValidator validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<IEnumerable<UserModel>> GetUsers()
    {
        return await UsersRepository.GetUsers();
    }

    public async Task<UserModel> CreateUser(CreateUserRequest createUserRequest)
    {
        var validationResult = await _validator.ValidateAsync(createUserRequest);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var user = UserMapping.RequestBodyToUser(createUserRequest);
        return await UsersRepository.AddUser(user);
    }

    public async Task<bool> DeleteUser(int userId)
    {
        return await UsersRepository.DeleteUser(userId);
    }
}