using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MasterSetUpController {
public    class UserController:IUser {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public void DeleteUserID(User u)
        {
            User user = mBMSEntities.Users.Where(x => x.UserID == u.UserID).SingleOrDefault();
            user.Active = u.Active;
            user.DeletedDate = DateTime.Now;
            user.DeletedUserID = u.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(User u)
        {
            mBMSEntities.Users.Add(u);
            mBMSEntities.SaveChanges();
        }

        public void UpdateUserID(User u)
        {
            //User user = mBMSEntities.Users.Where(x => x.UserID == u.UserID).SingleOrDefault();
            //user.UserName = u.UserName;
            //user.Password = u.Password;
            //user.RoleID = u.RoleID;
            //user.SecurityQuestion = u.SecurityQuestion;
            //user.SecurityAnswer = u.SecurityAnswer;
            //user.LastLoginDate = DateTime.Now;
            //user.UpdatedUserID = u.UpdatedUserID;
            //user.UpdatedDate = DateTime.Now;
            mBMSEntities.Users.AddOrUpdate(u);
            mBMSEntities.SaveChanges();
        }
    }
    
    }
