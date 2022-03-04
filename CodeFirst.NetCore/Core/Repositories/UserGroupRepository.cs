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
            var usergroup = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            if (usergroup == null)
                throw new ConflictException(ConflictCode.record_not_found, "User group detail not found");


            usergroup.Name = data.Name;

            userDBContext.UserGroups.Update(usergroup);

            await userDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usergroup = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            if (usergroup == null)
                throw new ConflictException(ConflictCode.record_not_found, "User group detail not found");


            userDBContext.UserGroups.Remove(usergroup);

            await userDBContext.SaveChangesAsync();
        }

        public  Task<UserGroup> GetAsync(int id)
        {
            var response = userDBContext.UserGroups.FirstOrDefault(item => item.Id == id);

            if (response == null)
                throw new ConflictException(ConflictCode.record_not_found, "User group detail not found");


            return Task.FromResult(response);
        }

        public async Task<IEnumerable<UserGroup>> GetListAsync()
        {
            var response = userDBContext.UserGroups.ToList();

            return await Task.FromResult(response.AsEnumerable());
        }

     
    }
}
