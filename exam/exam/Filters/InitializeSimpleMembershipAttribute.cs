﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using exam.Models;
using System.Web.Security;
using DAL;

namespace exam.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Ensure ASP.NET Simple Membership is initialized only once per app start
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                Database.SetInitializer<SBContext>(null);

                try
                {
                    using (var context = new SBContext())
                    {
                        if (!context.Database.Exists())
                        {
                            // Create the SimpleMembership database without Entity Framework migration schema
                            ((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                        }
                    }

                    WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);

                    SimpleRoleProvider roles = (SimpleRoleProvider)Roles.Provider;
                    SimpleMembershipProvider membership = (SimpleMembershipProvider)Membership.Provider;

                    if (!roles.RoleExists("User"))
                        roles.CreateRole("User");

                    // Проверка наличия роли Admin
                    if (!roles.RoleExists("Admin"))
                        roles.CreateRole("Admin");

                    // Поиск пользователя с логином admin
                    if (membership.GetUser("admin", false) == null)
                    {
                        membership.CreateUserAndAccount("admin", "admin123"); // создание пользователя
                        roles.AddUsersToRoles(new[] { "admin" }, new[] { "Admin" }); // установка роли для пользователя
                    }
                    if (membership.GetUser("user", false) == null)
                    {
                        membership.CreateUserAndAccount("user", "user123");
                        roles.AddUsersToRoles(new[] { "user" }, new[] { "User" });
                    }
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}
