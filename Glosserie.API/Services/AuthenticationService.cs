﻿using Glosserie.API.Data.DataAccess;
using Glosserie.API.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glosserie.API.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly IPasswordHasher _passwordHasher; //add to DI

        public AuthenticationService(ISqlDataAccess sqlDataAccess, IPasswordHasher passwordHasher)
        {
            _sqlDataAccess = sqlDataAccess;
            _passwordHasher = passwordHasher;
        }

        //remove async
        public async Task<bool> Register(string email, string password, string confirmpassword)
        {
            bool success = false;
            if (password == confirmpassword)
            {
                //hash password

                string hashedPassword = _passwordHasher.HashPassword(password);

                UserInsertModel userInsertModel = new UserInsertModel() 
                { 
                    Email = email, 
                    Password = hashedPassword
                };
                //check if email already exists in database
                var records = _sqlDataAccess.LoadData<UserModel, dynamic>
                    ("ListeraDB.listerdb.spGetUserByEmail", new { email = userInsertModel.Email}, "GlosserieSSAuth");

                if (records == null)
                {
                    try
                    {
                        _sqlDataAccess.SaveData<UserInsertModel>
                            ("ListeraDB.listeradb.spInsertUser", userInsertModel, "GlosserieSSAuth");
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                        string stacktrace = ex.StackTrace;
                    } 
                }
            }

            return success;
        }
        //remove async
        public async Task<UserModel> Login(string email, string password)
        {
            try
            {
                var records = _sqlDataAccess.LoadData<UserModel, dynamic>
                           ("ListeraDB.listerdb.spGetUserByEmail", new { email = email }, "GlosserieSSAuth");

                if (records != null)
                {
                    PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(records[0].Password, password);
                    if (result == PasswordVerificationResult.Success)
                    {
                        UserModel user = new UserModel() 
                        {
                            UserID = records[0].UserID,
                            Email = records[0].Email,
                            Password = records[0].Password
                        };
                        return user;
                    }
                }
                return new UserModel() {Email = "UserAlreadyExists" };
            }
            catch (Exception ex)
            {
                string m = ex.Message;
                string s = ex.StackTrace;
                return new UserModel() { Email = "failed", UserID = 0, Password = "failed"};
            } 

            
        }
    }
}
