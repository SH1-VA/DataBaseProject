﻿namespace DataBase.Models
{
    public class CreateTeacherRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Hours    { get; set; }
    }
}
