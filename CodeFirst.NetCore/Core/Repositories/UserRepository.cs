using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDBContext userDBContext;

        public UserRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        public async Task AddAsync(User data)
        {
            userDBContext.Users.Add(data);

            await userDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = userDBContext.Users.FirstOrDefault(item => item.Id == id);

            userDBContext.Users.Remove(user);

            await userDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, User data)
        {
            var user = userDBContext.Users.FirstOrDefault(item => item.Id == id);

            user.FirstName = data.FirstName;

            user.LastName = data.LastName;

            user.UserGroupId = data.UserGroupId;

            userDBContext.Users.Update(user);

            await userDBContext.SaveChangesAsync();
        }

        public Task<User> GetAsync(int id)
        {
            var response = userDBContext.Users.FirstOrDefault(item => item.Id == id);

            return Task.FromResult(response);
        }

        public Task<IEnumerable<User>> GetListAsync()
        {
            var response = userDBContext.Users.ToList();

            return Task.FromResult(response.AsEnumerable());
        }

       
    }
}
