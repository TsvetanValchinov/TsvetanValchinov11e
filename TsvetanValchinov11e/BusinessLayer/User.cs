using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
    {
    public class User
        {
        [Key]
        public int ID { get; private set; }
    
        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required, Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public IEnumerable<User> Friends { get; set; }

        public IEnumerable<Game> Games { get; set; }

        private User()
            {

            }

        public User(string  firstName, string lastName, int age, string username, string password, string email)
            {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            }
        }
    }
