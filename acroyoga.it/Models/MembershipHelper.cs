using acroyoga.it.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace acroyoga.it.Helpers
{
    public class MembershipHelper
    {
        AcroyogaContext ctx = new AcroyogaContext();

        public static bool ValidateUser(string userName, string password)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                User user = ctx.Users.Where(u => u.UserName == userName && u.Password == password).FirstOrDefault();               
                return user != null;
            }
        }

        public static IEnumerable<User> GetUsers()
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Users.Include("Roles").ToList();
            }
        }

        public static User GetUser(Guid userid)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Users.Include("Roles").Where(u => u.UserID == userid).FirstOrDefault();
            }
        }

        public static User GetUser(string userName)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Users.Where(u => u.UserName == userName).FirstOrDefault();
            }
        }

        public static bool RegisterUser(string userName, string password, string email, out string createStatus)
        {
            createStatus = "success";
            return true;
        }

        public static void ChangePassword(User user, string password)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                User dbuser = ctx.Users.Find(user.UserID);
                dbuser.Password = password;

                ctx.SaveChanges();
            }
        }

        public static Guid SaveUser(User user)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                if (user.UserID == Guid.Empty)
                {
                    ctx.Users.Add(user);
                }
                else
                {
                    User dbuser = ctx.Users.Find(user.UserID);

                    var deleted = dbuser.Roles.Except(user.Roles.Where(r => r.IsChecked), new RoleComparer()).ToList();

                    var added = user.Roles.Where(r => r.IsChecked).Except(dbuser.Roles, new RoleComparer()).ToList();

                    deleted.ForEach(c => dbuser.Roles.Remove(c));

                    //5- Add new courses
                    foreach (Role c in added)
                    {
                        if (ctx.Entry(c).State == System.Data.Entity.EntityState.Detached)
                            ctx.Roles.Attach(c);

                        //7- Add course in existing student's course collection
                        dbuser.Roles.Add(c);
                    }                    
                }

                ctx.SaveChanges();
                return user.UserID;
            }
        }

        public static bool DeleteUser(User user)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                try
                {
                    ctx.Users.Remove(user);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static IEnumerable<Role> GetRoles()
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Roles.Include("Users").ToList();
            }
        }


        public static string[] GetRolesText()
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Roles.Select(r => r.Name).ToArray();
            }
        }

        public static string[] GetRolesForUser(string username)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Users.Include("Roles").Where(u => u.UserName == username).FirstOrDefault().Roles.Select(r => r.Name).ToArray();
            }
        }

        public static bool RoleExists(string roleName)
        {
            using (AcroyogaContext ctx = new AcroyogaContext())
            {
                return ctx.Roles.Any(r => r.Name == roleName);
            }
        }

    }
}