using FitnessTracker.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserRecord> GetUserAsync(string username)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task RegisterUser(UserRecord user)
        {
            _appDbContext.Users.Add(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(UserRecord user)
        {
            _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(string userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId);
            if (user != null)
            {
                _appDbContext.Users.Remove(user);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
