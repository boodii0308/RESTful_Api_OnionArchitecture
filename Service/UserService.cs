using Data;
using Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Service.Module;

namespace Service
{
    public class UserService
    {
        public UnitOfWork UnitWork { get; set; }

        public UserService()
        {
            DBEntities _entities = new DBEntities();
            UnitWork = new UnitOfWork(_entities);
        }


        public UserDTO ValidateUser(string username, string password)
        {
            var user = UnitWork.Users.GetAll();
            var retu = user.Where(x => x.UserName == username && x.UserPassword == password).Select(x => new UserDTO
            {
                UserID = x.UserID,
                UserEmailID = x.UserEmailID,
                UserPassword = x.UserPassword,
                UserName = x.UserName
            }).FirstOrDefault<UserDTO>();

            return retu;
        }
        public void Dispose()
        {
            UnitWork.Dispose();
        }
    }
}
