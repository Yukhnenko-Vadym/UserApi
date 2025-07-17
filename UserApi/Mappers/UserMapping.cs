using TestTask.Models;
using TestTask.Requests;

namespace TestTask.Mapping;

public static class UserMapping
{
    public static UserModel RequestBodyToUser(this CreateUserRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        return new UserModel(request.FullName, request.Email, request.DateOfBirth);
    }
}