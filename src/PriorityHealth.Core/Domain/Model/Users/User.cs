//-----------------------------------------------------------------------
// <copyright file="User.cs" company="Spectrum Health">
//  Copyright (c) 2014 All Rights Reserved
//  <author>Joe Rivard</author>
// </copyright>
//-----------------------------------------------------------------------	  	  

namespace PriorityHealth.Core.Domain.Model.Users
{
    using DevOne.Security.Cryptography.BCrypt;
    using System;
    using System.Collections.Generic;
    
    public class User : EntityBase<User>
    {
        public virtual string Email { get; set; }

        public virtual string Name { get; set; }

        public virtual string Password { get; set; }

        public virtual void HashPassword()
        {
            var salt = BCryptHelper.GenerateSalt(10);
            Password = BCryptHelper.HashPassword(Password, salt);
        }

        public virtual void SetPassword(string password)
        {
            Password = password;
            HashPassword();
        }

        public virtual bool IsAuthenticated(string password)
        {
            return BCryptHelper.CheckPassword(password, Password);
        }
    }
}
