using System;

namespace JustGivingSDK.Contracts.Fundraising
{
    public class RememberedPerson 
    {
        /// <summary>
        /// The Id of the remembered person, 0 if new
        /// </summary>
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Gender type: Male, Female
        /// </summary>
        public Gender Gender { get; set; }

        public string Town { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }
    }
}