using TestTask.Models;

namespace TestTask.Data;

public static class UsersRepository
{
    private static readonly List<UserModel> _users = new();
    private static int _nextId = 1;
    private static readonly object _lock = new();

    public static Task<IEnumerable<UserModel>> GetUsers()
    {
        lock (_lock)
        {
            return Task.FromResult(_users.AsEnumerable());
        }
    }

    public static Task<UserModel> AddUser(UserModel user)
    {
        lock (_lock)
        {
            user.Id =  _nextId++;
            _users.Add(user);
            return Task.FromResult(user);
        }
    }

    public static Task<UserModel?> GetUserById(int id)
    {
        lock (_lock)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }
    }

    public static Task<bool> DeleteUser(int id)
    {
        lock (_lock)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return Task.FromResult(false);
            _users.Remove(user);
            return Task.FromResult(true);
        }
    }
}
