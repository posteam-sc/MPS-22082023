using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;
using MPS.BusinessLogic.ViewModels;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class RoleController : IRole
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void RoleManagementDeleteByRoleID(string RoleID) {
            mBMSEntities.RoleManagement_DeleteByRoleID(RoleID);
            }
        public void SaveRoleMgtByRoleID(string ProgramName, string IsViewEditAdd, string RoleID, bool IsAllowed, string UserID) {
            if (IsViewEditAdd == "View") {
                CreateRoleFeatures(ProgramName + RoleManagementViewModel.View, IsAllowed, RoleID,UserID);
                }
            else if (IsViewEditAdd == "Edit") {
                CreateRoleFeatures(ProgramName + RoleManagementViewModel.EditOrDelete, IsAllowed, RoleID, UserID);
                }
            else if (IsViewEditAdd == "Add") {
                CreateRoleFeatures(ProgramName + RoleManagementViewModel.Add, IsAllowed, RoleID, UserID);
                }
            }

        private void CreateRoleFeatures(string feature,bool IsAllowed,string RoleID,string UserID) {
            RoleManagement rolemgtentity = new RoleManagement();
            rolemgtentity.RoleManagementID = Guid.NewGuid().ToString();
            rolemgtentity.Active = true;
            rolemgtentity.RoleFeatureName = feature;
            rolemgtentity.RoleID = RoleID;
            rolemgtentity.IsAllowed = IsAllowed;
            rolemgtentity.CreatedUserID = UserID;
            rolemgtentity.CratedDate = DateTime.Now;
            mBMSEntities.RoleManagements.Add(rolemgtentity);
            mBMSEntities.SaveChanges();
            }

        public void DeletedByRoleID(Role r)
        {
            Role role = mBMSEntities.Roles.Where(x => x.RoleID == r.RoleID).SingleOrDefault();
            role.Active = r.Active;
            role.DeletedDate = DateTime.Now;
            role.DeletedUserID = r.DeletedUserID;
            mBMSEntities.SaveChanges();

        }

        public void Save(Role r)
        {
            mBMSEntities.Roles.Add(r);
            mBMSEntities.SaveChanges();
        }

        public void UpdateByRoleID(Role r)
        {
            Role role = mBMSEntities.Roles.Where(x => x.RoleID == r.RoleID).SingleOrDefault();
            role.RoleName = r.RoleName;
            role.RoleLevel = r.RoleLevel;
            role.UpdatedDate = DateTime.Now;
            role.UpdatedUserID = r.UpdatedUserID;
            mBMSEntities.Roles.AddOrUpdate(role); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
