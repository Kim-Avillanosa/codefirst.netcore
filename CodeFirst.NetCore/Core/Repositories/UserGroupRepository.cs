using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.NetCore
{
    public class UserGroupRepository : IUserGroupRepository
    {
        private readonly UserDBContext userDBContext;

        public UserGroupRepository(UserDBContext userDBContext)
        {
            this.userDBContext = userDBContext;
        }

        public async Task AddAsync(UserGroup data)
        {
            userDBContext.UserGroups.Add(data);

            await userDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UserGroup data)
        {
            var user = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            user.Name = data.Name;

            userDBContext.UserGroups.Update(user);

            await userDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usergroup = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            userDBContext.UserGroups.Remove(usergroup);

            await userDBContext.SaveChangesAsync();
        }

        public  Task<UserGroup> GetAsync(int id)
        {
            var response = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            return Task.FromResult(response);
        }

        public async Task<IEnumerable<UserGroup>> GetListAsync()
        {
            var response = userDBContext.UserGroups.ToList();

            return await Task.FromResult(response.AsEnumerable());
        }

     
    }
}
