﻿using Microsoft.EntityFrameworkCore;
using UltimateManager.Domain.Interfaces;
using UltimateManager.Domain.Models;

namespace UltimateManager.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UltimateManagerDbContext _context;
		public UserRepository(UltimateManagerDbContext context)
		{
			_context = context;
		}

		public async Task<List<User>> GetAllUsersAsync()
		{
			return await _context.Users.Include(u => u.Team).ToListAsync();
		}

		public async Task<User> GetUserByIdAsync(int userId)
		{
			return await _context.Users
				.Include(u => u.Team)
				.FirstOrDefaultAsync(u => u.Id == userId);
		}

		public async Task AddUserAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUserAsync(int userId)
		{
			var user = await _context.Users.FindAsync(userId);
			if(user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateUserAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}
	}
}
