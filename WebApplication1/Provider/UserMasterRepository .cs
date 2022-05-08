using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using WebApplication1.Service;
using Service;
using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Provider
{
    public class UserMasterRepository: IDisposable
    {
        UserService context = new UserService();

        public UserM ValidateUser(string username, string password)
        {
            var UserD = context.ValidateUser(username, password);
            var UserM = new UserM()
            {
                UserID = UserD.UserID,
                UserEmailID = UserD.UserEmailID,
                UserPassword = UserD.UserPassword,
                UserName = UserD.UserName
            };
            return UserM;
        }
         public void Dispose()
        {
            context.Dispose();
        }
    }
}                                                                                           