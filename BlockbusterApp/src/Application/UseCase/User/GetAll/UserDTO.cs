﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockbusterApp.src.Application.UseCase.User.GetAll
{
    public class UserDTO
    {
        public string id ;
        public string email ;
        public string firstName ;
        public string lastName ;
        public string role ;

        public UserDTO(
            string id, 
            string email, 
            string firstName, 
            string lastName, 
            string role) 
        {
            this.id = id;
            this.email = email;
            this.firstName = firstName;
            this.lastName = lastName;
            this.role = role;                
        }        
    }
}