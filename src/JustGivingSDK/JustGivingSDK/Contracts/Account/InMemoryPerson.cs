using System;

namespace JustGivingSDK.Contracts.Account
{
    public class InMemoryPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfDeath { get; set; }
    }
}