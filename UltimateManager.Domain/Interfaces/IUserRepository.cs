using UltimateManager.Domain.Models;

namespace UltimateManager.Domain.Interfaces
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(int userId);
		Task<List<User>> GetAllUsersAsync();
		Task AddUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(int userId);
	}
}
