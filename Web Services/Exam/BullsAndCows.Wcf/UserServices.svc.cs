using BullsAndCows.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BullsAndCows.Wcf.DataModels;

namespace BullsAndCows.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserServices.svc or UserServices.svc.cs at the Solution Explorer and start debugging.
    public class UserServices : IUserServices
    {
        private IBullsAndCowsData data;

        public UserServices()
        {
            this.data = new BullsAndCowsData(BullsAndCowsDbContext.Create());
        }

        public IEnumerable<UserDataModels> GetUsers()
        {
            var users = this.data.Users.All()
                .OrderBy(u => u.UserName)
                .Select(UserDataModels.FromUser)
                .Take(10);

            return users;
        }

        public object GetUserDetails(string id)
        {
            var userById = this.data.Users.Find(id);

            if (userById == null)
            {
                return new { message = "User with the given Id doesn not exist!" };
            }

            return UserDetailsDataModel.GetDetailsFromUser(userById);
        }
    }
}
