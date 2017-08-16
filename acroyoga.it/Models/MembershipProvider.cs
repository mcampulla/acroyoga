using acroyoga.it.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace acroyoga.it.Helpers
{

    class AcroyogaUserProvider : MembershipProvider
    {
        private string _applicationName;

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            if (config == null)
                throw new ArgumentNullException("config");
 
            if (name == null || name.Length == 0)
                name = "AcroyogaUserProvider";
 
            if (String.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "acroyoga custom user membership provider");
            }
 
            base.Initialize(name, config);

            _applicationName = "Acroyoga";
        }

        private string GetConfigValue(string configValue, string defaultValue)
        {
            if (string.IsNullOrEmpty(configValue))
                return defaultValue;

            return configValue;
        }

        #region Members
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                _applicationName = value;
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region methods (not used)
        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser user = null;
            Application a = new Application() { ApplicationID = Guid.NewGuid(), Name = "Acroyoga"  };
            User u = new User(){ Email=email, UserName=username, Password=password };
            Guid userid = MembershipHelper.SaveUser(u);
            if (userid != Guid.Empty)
            {
                user = new MembershipUser(Membership.Provider.Name, u.UserName,
                    userid, u.Email, string.Empty,
                    string.Empty, true, false, DateTime.Today,
                    DateTime.Today, DateTime.Today, DateTime.Today, DateTime.MinValue);
                status = MembershipCreateStatus.Success;
            }
            else
            {
                status = MembershipCreateStatus.ProviderError;
            }
            return user;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            User user = MembershipHelper.GetUser(username);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                MembershipHelper.ChangePassword(user, newPassword);
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region methods
        public override bool ValidateUser(string username, string password)
        {
            bool ret = MembershipHelper.ValidateUser(username, password);
            return ret;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            MembershipUser user = null;

            try
            {
                User useraccount = MembershipHelper.GetUser(username);
                user = new MembershipUser(Membership.Provider.Name, useraccount.UserName,
                    useraccount.UserID, useraccount.Email, string.Empty,
                    string.Empty, true, false, DateTime.Today,
                    DateTime.Today, DateTime.Today, DateTime.Today, DateTime.MinValue);
            }
            catch (Exception ex)
            {
            }

            return user;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return GetUser(providerUserKey.ToString(), userIsOnline);
        }

        public override string GetUserNameByEmail(string email)
        {
            return null;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection ret = new MembershipUserCollection();
            ret.Add(GetUser(emailToMatch, false));
            totalRecords = 1;
            return ret;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            MembershipUserCollection ret = new MembershipUserCollection();
            ret.Add(GetUser(usernameToMatch, false));
            totalRecords = 1;
            return ret;
        }
        #endregion
    }

    class AcroyogaRoleProvider : RoleProvider
    {
       

        #region Members
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        #endregion

        #region Methods (not used)
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Methods
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return MembershipHelper.GetRolesText();
        }

        public override string[] GetRolesForUser(string username)
        {
            return MembershipHelper.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return MembershipHelper.RoleExists(roleName);
        }
        #endregion
    }
}
